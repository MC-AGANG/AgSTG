#include "LilyTDS3.h"
LilyTDS3::LilyTDS3(){

}
void LilyTDS3::Begin(){
    Screen.init();
    Screen.fillScreen(0);
    Touch.begin();
    
}
LilyTDS3 Lily;