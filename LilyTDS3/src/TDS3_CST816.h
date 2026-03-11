#include <Arduino.h>

#ifndef TDS3_CST816_H
#define TDS3_CST816_H

#define CST816_ADDRESS     0x15

enum GESTURE {
  NONE = 0x00,
  SWIPE_DOWN = 0x01,   
  SWIPE_UP = 0x02, 
  SWIPE_LEFT = 0x03,
  SWIPE_RIGHT = 0x04,
  SINGLE_CLICK = 0x05,
  DOUBLE_CLICK = 0x0B,
  LONG_PRESS = 0x0C
};

struct data_struct {
  byte gestureID; // Gesture ID.
  byte points;  // Number of touch points.
  byte event; // Event (0 = Down, 1 = Up, 2 = Contact).
  uint16_t x; // Display X coordinate (0 to 170).
  uint16_t y; // Display Y coordinate (0 to 255). Goes back to 0 when sector = 1.
  uint16_t full_y; // Real display Y coordinate (0 to 359). Use this parameter for touch inputs. full_y = y + (sector * 255)
  uint16_t sector; // Screen division in sectors. 0: Y <= 255; 1: Y > 255.
  bool radial_button; //Display radial button. true: y = 104 or full_y = 359
  uint8_t version;
  uint8_t versionInfo[3];
};



class TDS3_CST816 {
  public:
    TDS3_CST816(int sda, int scl, int rst, int irq);
    void begin(int interrupt = RISING);
    void sleep();
    bool available();
    data_struct data;
    String gesture();

  private:
    int _sda;
    int _scl;
    int _rst;
    int _irq;
    bool _event_available;
    void IRAM_ATTR handleISR();
    void read_touch();
    uint8_t i2c_read(uint16_t addr, uint8_t reg_addr, uint8_t * reg_data, uint32_t length);
    uint8_t i2c_write(uint8_t addr, uint8_t reg_addr, const uint8_t * reg_data, uint32_t length);
};

#endif

/*
MIT License

Copyright (c) 2023 Bruno Bortoletto
Copyright (c) 2021 Felix Biego

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/