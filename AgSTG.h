#ifndef _AgSTG_
#define _AgSTG_
#include "DirectE.h"
#include <math.h>
using namespace DirectE;

namespace AgSTG{
  class GameObject{
    public:
    char Type;
    uint16_t ID;
    double X;
    double Y;
    double Speed=0;
    double Direction=0;
    double HitboxSize;
    uint16_t Height;
    uint16_t Width;
    uint16_t Ticks = 0;
    virtual void Loop();
    bool Judge(GameObject*);
    void Clear();
    void Move();
    void Move(double,double);
    void Show();
    void Hide();
    Bitmap* Texture;
  };
  class Player:public GameObject{
    public:
    Player();
    void Miss();
    void Shoot();
    void Loop() override;
    void Spell();
  };
  class PlayerBullet:public GameObject{
    public:
    PlayerBullet(double,double);
    void Loop() override;
  };
  class Enemy:public GameObject{
    public:
    int HP;
    char EnemyType;
    char WaveID = 0;
    Enemy(char,double,double,int,double,int);
    void Wave1();
    void Wave2();
    void Wave3();
    void Boss0();
    void Init();
    void Loop() override;
    void Damage(int);
  };
  class Bullet:public GameObject{
    public:
    Bullet(char,double,double,double,int);
    Bullet(char,double,double,double);
    char BulletType;
    void Loop() override;
    void Init();
  };
  class STGArea{
    public:
    STGArea();
    uint16_t Ticks = 0;
    uint32_t Score = 0;
    uint8_t Life = 8;
    void Begin();
    void Loop();
    void ClearBullet();
    void UpdateState();
    void GameOver();
    void StageClear();
    uint16_t Objectn = 16;
    GameObject* Objects[1024];
    void GetID();
    Enemy* CreateEnemy(char,double,double,int,double,int);
    Bullet* CreateBullet(char,double,double,double,int);
    Bullet* CreateBullet(char,double,double,double);
    void Stage6();
  };
}
using namespace AgSTG;
extern STGArea STG;
#endif