#include "AgSTG.h"
using namespace AgSTG;
using namespace DirectE;

void GameObject::Show(){
  Texture->Push((uint16_t)X-Width/2,(uint16_t)Y-Height/2,&RA);
}
void GameObject::Hide(){
  RA.Fill((uint16_t)X-Width/2,(uint16_t)Y-Height/2,Width,Height,0);
}
void GameObject::Move(){
  X += Speed*sin(Direction*pi/180);
  Y -= Speed*cos(Direction*pi/180);
  if(X<-32||X>202||Y<-32||Y>252){
    Clear();
  }
}
void GameObject::Move(double DeltaX,double DeltaY){
  X+= DeltaX;
  Y+= DeltaY;
  if(X<8){
    X=8;
  }
  if(X>162){
    X=162;
  }
  if(Y<16){
    Y=16;
  }
  if(Y>204){
    Y=204;
  }
}
void GameObject::Clear(){
  Hide();
  delete STG.Objects[ID];
  STG.Objects[ID] = nullptr;
}
bool GameObject::Judge(GameObject * Target){
  return HitboxSize+Target->HitboxSize>=sqrt(pow(X-Target->X,2)+pow(Y-Target->Y,2));
}
