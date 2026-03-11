#include "AgSTG.h"
using namespace AgSTG;
void STGArea::Stage6(){
  static int LX1;
  if(Ticks >=100 && Ticks < 160){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0, (Ticks-100)*2+25+rand()%8-4, 40+rand()%8-4, 16,0.15,rand()%360)->WaveID=1;
    }
  }
  else if(Ticks >=350 && Ticks < 410){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0, 170-((Ticks-350)*2+25+rand()%8-4), 40+rand()%8-4, 16,0.15,rand()%360)->WaveID=1;
    }
  }
  else if(Ticks >=600 && Ticks < 660){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0,(Ticks-600)*2+25+rand()%8-4 , 40+rand()%8-4, 16,0.15,rand()%360)->WaveID=1;
    }
  }
  else if(Ticks >=1000 && Ticks<1060){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0, -16, 40+rand()%8-4, 7, 2, 90)->WaveID=2;
    }
  }
  else if(Ticks >=1300 && Ticks<1360){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0, 186, 40+rand()%8-4, 8, 2, 270)->WaveID=2;
    }
  }
  else if(Ticks >=1500 && Ticks <1560){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(1,(Ticks-1500)*2+25+rand()%8-4 , 40+rand()%8-4, 10,0.1,rand()%360)->WaveID=3;
    }
  }
  else if(Ticks >=1800 && Ticks <1860){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(1,170-((Ticks-1800)*2+25+rand()%8-4) , 40+rand()%8-4, 10,0.1,rand()%360)->WaveID=3;
    }
  }
  else if(Ticks >= 2200 && Ticks <2300){
    if(Ticks % 50 == 0){
      LX1=rand()%170;
    }
    for(int i = 0;i<10;i+=2){
      if(Ticks % 50 == i){
        STG.CreateBullet(2,LX1,0,3,180);
      }
    }
  }
  else if(Ticks >= 2300 && Ticks <2400){
    if(Ticks % 25 == 0){
      LX1=rand()%170;
    }
    for(int i = 0;i<10;i+=2){
      if(Ticks % 25 == i){
        STG.CreateBullet(2,LX1,0,3,180);
      }
    }
  }
  else if(Ticks >= 2400 && Ticks <2500){
    if(Ticks % 20 == 0){
      LX1=rand()%170;
    }
    for(int i = 0;i<10;i+=2){
      if(Ticks % 20 == i){
        STG.CreateBullet(2,LX1,0,3,180);
      }
    }
  }
  else if(Ticks >= 2500 && Ticks <2800){
    if(Ticks % 10 == 0){
      LX1=rand()%170;
    }
    for(int i = 0;i<10;i+=2){
      if(Ticks % 10 == i){
        STG.CreateBullet(2,LX1,0,3,180);
      }
    }
  }
  else if(Ticks >= 2800 && Ticks <3500){
    if(Ticks % 8 == 0){
      LX1=rand()%170;
    }
    for(int i = 0;i<10;i+=2){
      if(Ticks % 8 == i){
        STG.CreateBullet(2,LX1,0,3,180);
      }
    }
    if(Ticks % 25 == 0){
      STG.CreateBullet(3,rand()%170,-2,4);
    }
  }
  else if(Ticks >=3600 && Ticks < 3660){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0, (Ticks-3600)*2+25+rand()%8-4, 40+rand()%8-4, 16,0.15,rand()%360)->WaveID=1;
    }
  }
  else if(Ticks >=3850 && Ticks < 3910){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0, 170-((Ticks-3850)*2+25+rand()%8-4), 40+rand()%8-4, 16,0.15,rand()%360)->WaveID=1;
    }
  }
  else if(Ticks >=4100 && Ticks < 4160){
    if(Ticks % 5 == 0){
      STG.CreateEnemy(0,(Ticks-4100)*2+25+rand()%8-4 , 40+rand()%8-4, 16,0.15,rand()%360)->WaveID=1;
    }
  }
  else if(Ticks == 4500){
    STG.CreateEnemy(100, 85, 64, 1000,0,0)->WaveID=100;
  }
}
void Enemy::Wave1(){
  if(Ticks >= 200){
    Direction = 0;
    Speed  = 0.8;
  }
  else if(Ticks % 20 ==0){
    Direction = rand()%360;
  }
}
void Enemy::Wave2(){
  if(Ticks %5==0&&rand()%32==0){
    STG.CreateBullet(0,X,Y,2.5);
  }
}
void Enemy::Wave3(){
  if(Ticks >= 200){
    Direction = 0;
    Speed = 0.8;
  }
  else if(Ticks % 20 ==0){
    Direction = rand()%360;
    if(rand() % 3 ==0){
      STG.CreateBullet(1,X,Y,1.5,170+rand()%20);
    }
  }
}
void Enemy::Boss0(){
  int dx,dy,dr;
  if(Ticks%30==0){
    dr = rand()%360;
    dx = rand()%32-16;
    dy = rand()%32-16;
    for(int i=0;i<360;i+=20){
      STG.CreateBullet(4,X+dx,Y+dy,1.5,dr+i);
    }
  }
  if(HP<750){
    dr = rand()%360;
    dx = rand()%32-16;
    dy = rand()%32-16;
    if(Ticks%90==0){
      for(int i=0;i<360;i+=40){
        STG.CreateBullet(5,X+dx-20,Y+dy,1.5,dr+i);
      }
    }
    dr = rand()%360;
    dx = rand()%32-16;
    dy = rand()%32-16;
    if(Ticks%90==0){
      for(int i=0;i<360;i+=40){
        STG.CreateBullet(5,X+dx+20,Y+dy,1.5,dr+i);
      }
    }
  }
  if(HP<500){
    dr = rand()%360;
    dx = rand()%32-16;
    dy = rand()%32-16;
    if(Ticks%120==0){
      for(int i=0;i<360;i+=15){
        STG.CreateBullet(6,X+dx-40,Y+dy,1.5,dr+i);
      }
    }
    dr = rand()%360;
    dx = rand()%32-16;
    dy = rand()%32-16;
    if(Ticks%120==0){
      for(int i=0;i<360;i+=15){
        STG.CreateBullet(6,X+dx+40,Y+dy,1.5,dr+i);
      }
    }
  }
  if(HP<250){
    if(Ticks % 10 == 0){
      for(int i = 15;i<360;i+=30){
        STG.CreateBullet(5,X,Y,3,i);
      }
    }
  }
}