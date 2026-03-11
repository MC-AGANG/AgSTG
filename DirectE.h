#ifndef _DirectE_
#define _DirectE_
#include <LilyTDS3.h>
#define pi 3.1415926535
namespace DirectE{
  class GMem{
    public:
    GMem();
    uint16_t Data[170][220];
    void Draw();
    void Draw(GMem*);
    void Fill(uint16_t);
    void Fill(int16_t,int16_t,int16_t,int16_t,uint16_t);
  };
  class Bitmap{
    public:
    Bitmap(uint16_t,uint16_t,uint16_t*);
    uint16_t Width;
    uint16_t Height;
    uint16_t* Data;
    void Push(int16_t,int16_t,GMem*);
  };
}
using namespace DirectE;
extern GMem RA;
extern GMem LA;
#endif