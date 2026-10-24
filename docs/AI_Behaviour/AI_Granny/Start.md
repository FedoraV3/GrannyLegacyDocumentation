---
title: Start
parent: AI Granny
---
# Start
```cpp
void AI_Granny$$Start(AI_Granny_o *this, const MethodInfo *method)
{
  const MethodInfo *v3; // rdx
  UnityEngine_GameObject_o *Bats_1; // rcx
  UnityEngine_GameObject_o *Weapon; // rcx
  UnityEngine_GameObject_o *Bats; // rcx

  if ( byte_CE7498 == 0 )
  {
    il2cpp_codegen_initialize_runtime_metadata(a1: &str_Difficulty, method);
    il2cpp_codegen_initialize_runtime_metadata(a1: &str_GrannyWeapon, method: v3);
    byte_CE7498 = 1;
  }
  // Can be optimized by a mod if:
  // Called the playerprefs function in a switch, then handle there, it is not that hard to re-create the function
  if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) != 0 )
  {
    // normal
    if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 1 )
    {
      this->fields.Run_Speed = 3.8f;
      this->fields.Run_Anim = 1.9f;
      this->fields.TimerMaxShoot = 1.4f;
    }
    // hard
    else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 2 )
    {
      this->fields.Run_Speed = 5.0;
      this->fields.Run_Anim = 2.5;
      this->fields.TimerMaxShoot = 0.9f;
    }
    // extreme
    else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 3 )
    {
      this->fields.Run_Speed = 8.5;
      this->fields.Run_Anim = 4.25;
      this->fields.TimerMaxShoot = 0.5;
    }
    // impossible
    else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 4 )
    {
      this->fields.Run_Speed = 12.0;
      this->fields.Run_Anim = 5.0;
      this->fields.DistanceJumpscare = 3.5;
      this->fields.TimerSaunaMax = 5.0;
      this->fields.TimerMaxShoot = 0.2f;
    }
    // hollow
    else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 5 )
    {
      this->fields.Run_Speed = 14.0;
      this->fields.Run_Anim = 5.6f;
      this->fields.DistanceJumpscare = 4.0;
      this->fields.TimerSaunaMax = 5.0;
      this->fields.TimerMaxShoot = 0.1f;
    }
  }
  else                                          // easy
  {
    this->fields.Run_Speed = 2.5;
    this->fields.Run_Anim = 1.25;
    this->fields.TimerMaxShoot = 1.8f;
  }
  if ( !this->fields.ChooseWeapon )
  {
    this->fields.ChooseWeapon = true;
    // crossbow
    if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_GrannyWeapon, method: nullptr) == 1 )
    {
      Bats = this->fields.Bats;
      if ( Bats != nullptr )
      {
        UnityEngine.GameObject$$SetActive(this: Bats, value: false, method: nullptr);
        Weapon = this->fields.Crossbow;
SET_GRANNY_WEAPON_CROSSBOW:
        if ( Weapon != nullptr )
        {
          UnityEngine.GameObject$$SetActive(this: Weapon, value: true, method: nullptr);
          return;
        }
      }
ERR_NULL_REFERENCE_EXCEPTION:
      il2cpp_codegen_raise_null_reference_exception();
    }
    // pepper spray
    if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_GrannyWeapon, method: nullptr) == 2 )
    {
      Bats_1 = this->fields.Bats;
      if ( Bats_1 == nullptr )
        goto ERR_NULL_REFERENCE_EXCEPTION;
      UnityEngine.GameObject$$SetActive(this: Bats_1, value: false, method: nullptr);
      Weapon = this->fields.Spray;
      goto SET_GRANNY_WEAPON_CROSSBOW;
    }
  }
}
```

**Behaviour**:
- Nested if loops that set Granny's stats to their according difficulty.
- Sets the weapon of Granny if the Extras option, "Granny's weapon" is set to something else other than the weapon, "Bat" in the main menu.
- "Bats" becomes inactive if the weapon is set something other than itself. 