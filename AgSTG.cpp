#include "AgSTG.h"
using namespace AgSTG;

STGArea::STGArea(){

}
void STGArea::Begin(){
  Objects[0] = new Player();
  Lily.Screen.drawString("Score:0",0,220,2);
  Lily.Screen.drawString("Life:8",0,236,2);
}
void STGArea::Loop(){
  Stage6();
  for (uint16_t i=0;i<1024;i++){
    if (Objects[i]!= nullptr){
      Objects[i]->Loop();
    }
  }
  Ticks++;
}
void STGArea::GetID(){
  while(Objects[Objectn]!=nullptr){
    Objectn++;
    if(Objectn >= 1024){
      Objectn = 16;
    }
  }
}
Enemy* STGArea::CreateEnemy(char Type, double X, double Y, int HP,double Speed = 0,int Direction = 0){
  GetID();
  Objects[Objectn] = new Enemy(Type,X,Y,HP,Speed,Direction);
  Objects[Objectn]->ID = Objectn;
  return static_cast<Enemy*>(Objects[Objectn]);
}
Bullet* STGArea::CreateBullet(char Type,double X,double Y,double Speed,int Direction){
  GetID();
  Objects[Objectn] = new Bullet(Type,X,Y,Speed,Direction);
  Objects[Objectn]->ID = Objectn;
  return static_cast<Bullet*>(Objects[Objectn]);
}
Bullet* STGArea::CreateBullet(char Type,double X,double Y,double Speed){
  GetID();
  Objects[Objectn] = new Bullet(Type,X,Y,Speed);
  Objects[Objectn]->ID = Objectn;
  return static_cast<Bullet*>(Objects[Objectn]);
}
void STGArea::ClearBullet(){
  for(int i=1;i<1024;i++){
    if(Objects[i]!=nullptr&&Objects[i]->Type==4){
      Objects[i]->Clear();
    }
  }
}
STGArea STG = STGArea();