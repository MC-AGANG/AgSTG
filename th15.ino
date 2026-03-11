#include "DirectE.h"
#include "AgSTG.h"
#include <LilyTDS3.h>
#include "esp32-hal-cpu.h"
void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  setCpuFrequencyMhz(240);
  Lily.Begin();
  STG.Begin();
}

void Render(){
  static uint32_t LastScore = 0;
  for(int i=0;i<1024;i++){
    if(STG.Objects[i]!=nullptr&&STG.Objects[i]->Type==3){
      STG.Objects[i]->Show();
    }
  }
  for(int i=0;i<1024;i++){
    if(STG.Objects[i]!=nullptr&&STG.Objects[i]->Type==2){
      STG.Objects[i]->Show();
    }
  }
  for(int i=0;i<1024;i++){
    if(STG.Objects[i]!=nullptr&&STG.Objects[i]->Type==1){
      STG.Objects[i]->Show();
    }
  }
  for(int i=0;i<1024;i++){
    if(STG.Objects[i]!=nullptr&&STG.Objects[i]->Type==4){
      STG.Objects[i]->Show();
    }
  }
  RA.Draw(&LA);
  if(STG.Score!= LastScore){
    Lily.Screen.drawString("Score:"+String(STG.Score),0,220,2);
    LastScore=STG.Score;
  }
}
void loop() {
  // put your main code here, to run repeatedly:
  int starttime = millis();
  for(int i=0;i<1024;i++){
    if(STG.Objects[i]!=nullptr){
      STG.Objects[i]->Hide();
    }
  }
  STG.Loop();
  Render();
  int endtime = millis();
  if(endtime -starttime <16){
    delay(16-endtime+starttime);
  }
}
