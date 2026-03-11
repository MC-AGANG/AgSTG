#include "DirectE.h"
using namespace DirectE;
Bitmap::Bitmap(uint16_t Width,uint16_t Height,uint16_t* Data){
  this->Width = Width;
  this->Height = Height;
  this->Data = Data;
}
void Bitmap::Push(int16_t X, int16_t Y, GMem* Target){
  uint16_t* p = Data;
  for(int16_t y = 0; y < Height; y++){
    for(int16_t x = 0; x < Width; x++){
      if(X+x < 170 && Y+y<220&&X+x>=0&&Y+y>=0&&*p!=0x7E0){
        Target->Data[X+x][Y+y] = *p;
      }
      p++;
    }
  }
}
GMem::GMem(){
  Fill(0);
}
void GMem::Fill(uint16_t Color){
  for(uint16_t y = 0; y < 220; y++){
    for(uint16_t x = 0; x < 170; x++){
      Data[x][y] = Color;
    }
  }
}
void GMem::Fill(int16_t X,int16_t Y,int16_t Width, int16_t Height, uint16_t Color){
  for(int16_t y = Y; y < Y+Height; y++){
    for(int16_t x = X; x < X+Width; x++){
      if(x>=0&&x<170&&y>=0&&y<220){
        Data[x][y] = Color;
      }
    }
  }
}
void GMem::Draw(){
  for(int16_t y = 0; y < 220; y++){
    for(int16_t x = 0; x < 170; x++){
      Lily.Screen.drawPixel(x,y,Data[x][y]);
    }
  }
}
void GMem::Draw(GMem* Last){
  for(int16_t y = 0; y < 220; y++){
    for(int16_t x = 0; x < 170; x++){
      if (Data[x][y] != Last->Data[x][y]){
        Lily.Screen.drawPixel(x,y,Data[x][y]);
        Last->Data[x][y]=Data[x][y];
      }
      
    }
  }
}
GMem RA = GMem();
GMem LA = GMem();