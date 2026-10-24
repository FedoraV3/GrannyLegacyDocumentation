---
parent: AI Granny
title: DeadDisable
---
# DeadDisable

```cpp
void AI_Granny$$DeadDisable(AI_Granny_o *this, const MethodInfo *method)
{
  UnityEngine_Behaviour_o *BoneController; // rcx
  BGManager_o *MusicBG; // rax
  Eyes_Granny_o *EnemyVision; // rax
  ScreenEffects_o *ScreenEffects; // rax
  UnityEngine_Transform_o *v7; // rax
  UnityEngine_Vector3_o *v8; // rax
  float z; // ecx
  UnityEngine_Behaviour_o *Agent; // rcx
  UnityEngine_Vector3_o v11; // [rsp+20h] [rbp-18h] BYREF

  AI_Granny$$MurderNoiseObjs(this, method: nullptr);
  BoneController = this->fields.BoneController;
  this->fields.TimerNearNoise = 0.0;

  if ( BoneController == nullptr )
    goto TRIGGER_NULL_REFERENCE_EXCEPTION;

  UnityEngine.Behaviour$$set_enabled(this: BoneController, value: false, method: nullptr);
  MusicBG = this->fields.MusicBG;

  if ( MusicBG == nullptr )
    goto TRIGGER_NULL_REFERENCE_EXCEPTION;

  MusicBG->fields.GrannyHunting = false;
  EnemyVision = this->fields.EnemyVision;

  if ( EnemyVision == nullptr )
    goto TRIGGER_NULL_REFERENCE_EXCEPTION;

  EnemyVision->fields.IsChasing = false;
  ScreenEffects = this->fields.ScreenEffects;

  this->fields.IsChasing = false;
  this->fields.IsSearching = false;
  if ( ScreenEffects == nullptr
    || (ScreenEffects->fields.NormalSee = false,
        (v7 = UnityEngine.Component$$get_transform(this, method: nullptr)) == nullptr)
    || (v8 = UnityEngine.Transform$$get_position(retstr: &v11, this: v7, method: nullptr),
        z = v8->fields.z,
        *&this->fields.CurrentTarget.fields.x = *&v8->fields.x,
        this->fields.CurrentTarget.fields.z = z,
        (Agent = this->fields.Agent) == nullptr) )
  {
TRIGGER_NULL_REFERENCE_EXCEPTION:
    il2cpp_codegen_raise_null_reference_exception();
  }
  UnityEngine.Behaviour$$set_enabled(this: Agent, value: false, method: nullptr);
  this->fields.PepperedEnemy = false;
  this->fields.AtDishes = false;
  this->fields.IsDying = true;
  this->fields.UsingWeaponProjectile = false;
}
```
**Behaviour**:
- Triggered when granny is killed
- Resets her state to the same state she was in when the game started, except IsDying is true
