#include "Arduino.h"
#include <Wire.h>
#include <FunctionalInterrupt.h>
#include "TDS3_CST816.h"

/*!
  \brief  Constructor for TDS3_CST816
	\param	sda i2c data pin
	\param	scl i2c clock pin
	\param	rst touch reset pin
	\param	irq touch interrupt pin
*/
TDS3_CST816::TDS3_CST816(int sda, int scl, int rst, int irq) {
  _sda = sda;
  _scl = scl;
  _rst = rst;
  _irq = irq;
}

void TDS3_CST816::read_touch() {
  /*!
    \brief read touch data
  */
  byte data_raw[8];
  i2c_read(CST816_ADDRESS, 0x01, data_raw, 6);

  data.gestureID = data_raw[0];
  data.points = data_raw[1];
  data.event = data_raw[2] >> 6;
  data.sector = data_raw[4];
  data.x = data_raw[3];
  data.y = data_raw[5];
  data.full_y = data_raw[5] + (data_raw[4] * 255);
  if(data.y == 104) data.radial_button = true;
  else data.radial_button = false;
}

/*!
  \brief  handle interrupts
*/
void IRAM_ATTR TDS3_CST816::handleISR(void) {
  _event_available = true;

}

/*!
  \brief  initialize the touch screen
	\param	interrupt type of interrupt FALLING, RISING..
*/
void TDS3_CST816::begin(int interrupt) {
  Wire.begin(_sda, _scl);

  pinMode(_irq, INPUT);
  pinMode(_rst, OUTPUT);

  digitalWrite(_rst, HIGH );
  delay(50);
  digitalWrite(_rst, LOW);
  delay(5);
  digitalWrite(_rst, HIGH );
  delay(50);

  i2c_read(CST816_ADDRESS, 0x15, &data.version, 1);
  delay(5);
  i2c_read(CST816_ADDRESS, 0xA7, data.versionInfo, 3);

  attachInterrupt(_irq, std::bind(&TDS3_CST816::handleISR, this), interrupt);
}

/*! \brief  check for a touch event */
bool TDS3_CST816::available() {
  if (_event_available) {
    read_touch();
    _event_available = false;
    return true;
  }
  return false;
}

/*!
  \brief  put the touch screen in standby mode
*/
void TDS3_CST816::sleep() {
  digitalWrite(_rst, LOW);
  delay(5);
  digitalWrite(_rst, HIGH );
  delay(50);
  byte standby_value = 0x03;
  i2c_write(CST816_ADDRESS, 0xA5, &standby_value, 1);
}

/*!
  \brief  get the gesture event name
*/
String TDS3_CST816::gesture() {
  switch (data.gestureID) {
    case NONE:
      return "NONE";
      break;
    case SWIPE_DOWN:
      return "SWIPE DOWN";
      break;
    case SWIPE_UP:
      return "SWIPE UP";
      break;
    case SWIPE_LEFT:
      return "SWIPE LEFT";
      break;
    case SWIPE_RIGHT:
      return "SWIPE RIGHT";
      break;
    case SINGLE_CLICK:
      return "SINGLE CLICK";
      break;
    case DOUBLE_CLICK:
      return "DOUBLE CLICK";
      break;
    case LONG_PRESS:
      return "LONG PRESS";
      break;
    default:
      return "UNKNOWN";
      break;
  }
}

/*!
  \brief  read data from i2c
	\param	addr i2c device address
	\param	reg_addr device register address
	\param	reg_data array to copy the read data
	\param	length length of data
*/
uint8_t TDS3_CST816::i2c_read(uint16_t addr, uint8_t reg_addr, uint8_t *reg_data, uint32_t length)
{
  Wire.beginTransmission(addr);
  Wire.write(reg_addr);
  if ( Wire.endTransmission(true))return -1;
  Wire.requestFrom(addr, length, true);
  for (int i = 0; i < length; i++) {
    *reg_data++ = Wire.read();
  }
  return 0;
}

/*!
  \brief  write data to i2c
	\brief  read data from i2c
	\param	addr i2c device address
	\param	reg_addr device register address
	\param	reg_data data to be sent
	\param	length length of data
*/
uint8_t TDS3_CST816::i2c_write(uint8_t addr, uint8_t reg_addr, const uint8_t *reg_data, uint32_t length)
{
  Wire.beginTransmission(addr);
  Wire.write(reg_addr);
  for (int i = 0; i < length; i++) {
    Wire.write(*reg_data++);
  }
  if ( Wire.endTransmission(true))return -1;
  return 0;
}

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