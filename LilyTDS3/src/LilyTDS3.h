#ifndef _Lily_
#define _Lily_
#include <TFT_eSPI.h>
#include "TDS3_CST816.h"

class LilyTDS3{
    public:
    LilyTDS3();
    TFT_eSPI Screen = TFT_eSPI();
    TDS3_CST816 Touch = TDS3_CST816(18, 17, 21, 16);
    void Begin();
};
extern LilyTDS3 Lily;
#endif