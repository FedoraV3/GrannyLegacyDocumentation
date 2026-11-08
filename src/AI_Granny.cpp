// Image: Assembly-CSharp.dll
/// @brief Granny's AI: patrol, search, chase, weapons, traps.
class AI_Granny : public UnityEngine::MonoBehaviour // TypeDefIndex: 54
{
    // Fields
public:
    AI_Grandpa* Ally; // 0x20
    Animation* Anim; // 0x28
    AnimationClip* Idle; // 0x30
    AnimationClip* WalkAnim; // 0x38
    AnimationClip* JumpscarePlayer; // 0x40
    AnimationClip* UnderBed; // 0x48
    AnimationClip* Tranquilized; // 0x50
    AnimationClip* Search; // 0x58
    AnimationClip* Pepper; // 0x60
    AnimationClip* Frozen; // 0x68
    AudioSource* JumpscareHit; // 0x70
    AudioSource* JumpscareHitNM; // 0x78
    AudioSource* JumpscareBed; // 0x80
    AudioSource* HitSound; // 0x88
    float DistanceJumpscare; // 0x90
    float Walk_Speed; // 0x94
    float Run_Speed; // 0x98
    float Walk_Anim; // 0x9C
    float Run_Anim; // 0xA0
    NavMeshAgent* Agent; // 0xA8
    Vector3 CurrentTarget; // 0xB0
    int CurrentWaypoint; // 0xBC
    List<Transform*>* Waypoints; // 0xC0
    int WaypointNumb; // 0xC8
    Transform* Player; // 0xD0
    BoneController* BC; // 0xD8
    Transform* PlayerHead; // 0xE0
    PlayerStatus* PlayerStatus; // 0xE8
    WindowJumping* WJ; // 0xF0
    Furniture* Furni; // 0xF8
    bool UnSeenPlayer; // 0x100
    Eyes_Granny* EnemyVision; // 0x108
    bool IsInSauna; // 0x110
    bool SaunaLocked; // 0x111
    float TimerInSauna; // 0x114
    float TimerInDangerSauna; // 0x118
    float TimerSaunaMax; // 0x11C
    Transform* SaunaPoint; // 0x120
    Transform* SaunaPoint2; // 0x128
    SaunaDeath* Sdeath; // 0x130
    bool IsDying; // 0x138
    GameObject* Crossbow; // 0x140
    GameObject* Spray; // 0x148
    GameObject* Bats; // 0x150
    bool UsingWeaponProjectile; // 0x158
    float TimerShoot; // 0x15C
    float TimerMaxShoot; // 0x160
    bool IsBlind; // 0x164
    float BlindTimer; // 0x168
    GameObject* EyeLock; // 0x170
    bool PepperedEnemy; // 0x178
    GameObject* SensorSprayKill; // 0x180
    bool CaughtPlayer; // 0x188
    bool IsOpeningDoor; // 0x189
    bool IsSearching; // 0x18A
    bool IsAngry; // 0x18B
    bool IsFollowingSound; // 0x18C
    bool IsChasing; // 0x18D
    bool IsWalking; // 0x18E
    bool IsIdle; // 0x18F
    float TimerNearNoise; // 0x190
    float TimerMaxNoise; // 0x194
    float TimerMaxNewNav; // 0x198
    float TimerChoosing; // 0x19C
    float SearchTimer; // 0x1A0
    float MaxSearch; // 0x1A4
    AudioSource* GrannyVoiceSource; // 0x1A8
    Array<AudioClip*>* VoiceLinesEnemy; // 0x1B0
    float DistanceFromNav; // 0x1B8
    float DistanceFromPlayer; // 0x1BC
    bool PlayerClose; // 0x1C0
    float DoorDistance; // 0x1C4
    float TimerDoorOpening; // 0x1C8
    float TimerMaxDoor; // 0x1CC
    bool CanOpenClosets; // 0x1D0
    float LockedDoorAttempts; // 0x1D4
    AudioClip* LockedDoor; // 0x1D8
    TeddyHunt* TH; // 0x1E0
    GameObject* NoiseObj; // 0x1E8
    Transform* OpenDoorRay; // 0x1F0
    System::String* NoiseObjectTag; // 0x1F8
    BGManager* MusicBG; // 0x200
    ScreenEffects* ScreenEffects; // 0x208
    bool TrapPregnant; // 0x210
    float TimerDropTrap; // 0x214
    float TimerMaxTrap; // 0x218
    float TimerAfterSearchTrap; // 0x21C
    float TimerAfterSearchTrapMax; // 0x220
    GameObject* BearTrap; // 0x228
    GameObject* BearTrapNM; // 0x230
    Transform* PointTrap; // 0x238
    float MaxTraps; // 0x240
    Array<GameObject*>* traps; // 0x248
    bool PlacingTrap; // 0x250
    bool NeedsToBirthTrap; // 0x251
    float DistanceRayPL; // 0x254
    Transform* RayCheckP; // 0x258
    bool PlayerTouchedRay; // 0x260
    LayerMask LayerExP; // 0x264
    Transform* BedCam1; // 0x268
    Transform* BedCam2; // 0x270
    Transform* BedCam3; // 0x278
    float TimerBedCaught; // 0x280
    float MaxBedCaughtTimer; // 0x284
    Vector3 PlayerPos; // 0x288
    Transform* PlayerSpot; // 0x298
    EnemyController* EC; // 0x2A0
    Paused* Pause; // 0x2A8
    AudioSource* FootstepS; // 0x2B0
    LayerMask LayerEx; // 0x2B8
    Vector3 DefaultRaycastDoors; // 0x2BC
    Transform* BackyardDoorTransform; // 0x2C8
    bool ChooseWeapon; // 0x2D0
    GameObject* DishesDone; // 0x2D8
    AnimationClip* WashingDishes; // 0x2E0
    Transform* SP_Dishes; // 0x2E8
    float TimerWashingDishes; // 0x2F0
    float TimerMaxDishes; // 0x2F4
    bool AtDishes; // 0x2F8

    // Constructors
    AI_Granny() {}

    // Methods
private:
    /// @brief Applies difficulty and weapon chosen in the main menu.
    /// @details Behaviour:
    /// - Nested if loops that set Granny's stats to their according difficulty.
    /// - Sets the weapon of Granny if the Extras option, "Granny's weapon" is set to something else other than the weapon, "Bat" in the main menu.
    /// - "Bats" becomes inactive if the weapon is set something other than itself.
    void Start()
    {
        // IDA: void AI_Granny$$Start(AI_Granny_o *this, const MethodInfo *method)
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
    void FixedUpdate() {}
public:
    /// @brief Resets Granny when she is killed.
    /// @details Behaviour:
    /// - Triggered when granny is killed
    /// - Resets her state to the same state she was in when the game started, except IsDying is true
    void DeadDisable()
    {
        // IDA: void AI_Granny$$DeadDisable(AI_Granny_o *this, const MethodInfo *method)
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
    void StopAI() {}
    void ResetAIDecision() {}
    void ShootDart() {}
    void FrozenEnemy() {}
    void PepperHit() {}
private:
    IEnumerator* UsageProjectile() {}
    IEnumerator* PepperedTimer() {}
    IEnumerator* FreezeProcess() {}
    IEnumerator* DartProcess() {}
public:
    void SensorPlayer() {}
    void ChaseAction() {}
    void StopChase() {}
    void LookAtThings(GameObject* ThatThing, float RotateSpeed) {}
    void SpeakEnemy() {}
    void MurderNoiseObjs() {}
    void ResetCertainTimer() {}
    void ChooseWaypoint() {}
private:
    IEnumerator* SmackTimer() {}
    void OnTriggerStay(Collider* other) {}
    void OnTriggerExit(Collider* other) {}
};
