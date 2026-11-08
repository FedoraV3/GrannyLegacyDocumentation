// Image: Assembly-CSharp.dll
/// @brief Granny's AI: patrol, search, chase, weapons, traps.
public class AI_Granny : UnityEngine.MonoBehaviour // TypeDefIndex: 54
{
    // Fields
    public AI_Grandpa Ally; // 0x20
    public Animation Anim; // 0x28
    public AnimationClip Idle; // 0x30
    public AnimationClip WalkAnim; // 0x38
    public AnimationClip JumpscarePlayer; // 0x40
    public AnimationClip UnderBed; // 0x48
    public AnimationClip Tranquilized; // 0x50
    public AnimationClip Search; // 0x58
    public AnimationClip Pepper; // 0x60
    public AnimationClip Frozen; // 0x68
    public AudioSource JumpscareHit; // 0x70
    public AudioSource JumpscareHitNM; // 0x78
    public AudioSource JumpscareBed; // 0x80
    public AudioSource HitSound; // 0x88
    public float DistanceJumpscare; // 0x90
    public float Walk_Speed; // 0x94
    public float Run_Speed; // 0x98
    public float Walk_Anim; // 0x9C
    public float Run_Anim; // 0xA0
    public NavMeshAgent Agent; // 0xA8
    public Vector3 CurrentTarget; // 0xB0
    public int CurrentWaypoint; // 0xBC
    public List<Transform> Waypoints; // 0xC0
    public int WaypointNumb; // 0xC8
    public Transform Player; // 0xD0
    public BoneController BC; // 0xD8
    public Transform PlayerHead; // 0xE0
    public PlayerStatus PlayerStatus; // 0xE8
    public WindowJumping WJ; // 0xF0
    public Furniture Furni; // 0xF8
    public bool UnSeenPlayer; // 0x100
    public Eyes_Granny EnemyVision; // 0x108
    public bool IsInSauna; // 0x110
    public bool SaunaLocked; // 0x111
    public float TimerInSauna; // 0x114
    public float TimerInDangerSauna; // 0x118
    public float TimerSaunaMax; // 0x11C
    public Transform SaunaPoint; // 0x120
    public Transform SaunaPoint2; // 0x128
    public SaunaDeath Sdeath; // 0x130
    public bool IsDying; // 0x138
    public GameObject Crossbow; // 0x140
    public GameObject Spray; // 0x148
    public GameObject Bats; // 0x150
    public bool UsingWeaponProjectile; // 0x158
    public float TimerShoot; // 0x15C
    public float TimerMaxShoot; // 0x160
    public bool IsBlind; // 0x164
    public float BlindTimer; // 0x168
    public GameObject EyeLock; // 0x170
    public bool PepperedEnemy; // 0x178
    public GameObject SensorSprayKill; // 0x180
    public bool CaughtPlayer; // 0x188
    public bool IsOpeningDoor; // 0x189
    public bool IsSearching; // 0x18A
    public bool IsAngry; // 0x18B
    public bool IsFollowingSound; // 0x18C
    public bool IsChasing; // 0x18D
    public bool IsWalking; // 0x18E
    public bool IsIdle; // 0x18F
    public float TimerNearNoise; // 0x190
    public float TimerMaxNoise; // 0x194
    public float TimerMaxNewNav; // 0x198
    public float TimerChoosing; // 0x19C
    public float SearchTimer; // 0x1A0
    public float MaxSearch; // 0x1A4
    public AudioSource GrannyVoiceSource; // 0x1A8
    public AudioClip[] VoiceLinesEnemy; // 0x1B0
    public float DistanceFromNav; // 0x1B8
    public float DistanceFromPlayer; // 0x1BC
    public bool PlayerClose; // 0x1C0
    public float DoorDistance; // 0x1C4
    public float TimerDoorOpening; // 0x1C8
    public float TimerMaxDoor; // 0x1CC
    public bool CanOpenClosets; // 0x1D0
    public float LockedDoorAttempts; // 0x1D4
    public AudioClip LockedDoor; // 0x1D8
    public TeddyHunt TH; // 0x1E0
    public GameObject NoiseObj; // 0x1E8
    public Transform OpenDoorRay; // 0x1F0
    public string NoiseObjectTag; // 0x1F8
    public BGManager MusicBG; // 0x200
    public ScreenEffects ScreenEffects; // 0x208
    public bool TrapPregnant; // 0x210
    public float TimerDropTrap; // 0x214
    public float TimerMaxTrap; // 0x218
    public float TimerAfterSearchTrap; // 0x21C
    public float TimerAfterSearchTrapMax; // 0x220
    public GameObject BearTrap; // 0x228
    public GameObject BearTrapNM; // 0x230
    public Transform PointTrap; // 0x238
    public float MaxTraps; // 0x240
    public GameObject[] traps; // 0x248
    public bool PlacingTrap; // 0x250
    public bool NeedsToBirthTrap; // 0x251
    public float DistanceRayPL; // 0x254
    public Transform RayCheckP; // 0x258
    public bool PlayerTouchedRay; // 0x260
    public LayerMask LayerExP; // 0x264
    public Transform BedCam1; // 0x268
    public Transform BedCam2; // 0x270
    public Transform BedCam3; // 0x278
    public float TimerBedCaught; // 0x280
    public float MaxBedCaughtTimer; // 0x284
    public Vector3 PlayerPos; // 0x288
    public Transform PlayerSpot; // 0x298
    public EnemyController EC; // 0x2A0
    public Paused Pause; // 0x2A8
    public AudioSource FootstepS; // 0x2B0
    public LayerMask LayerEx; // 0x2B8
    public Vector3 DefaultRaycastDoors; // 0x2BC
    public Transform BackyardDoorTransform; // 0x2C8
    public bool ChooseWeapon; // 0x2D0
    public GameObject DishesDone; // 0x2D8
    public AnimationClip WashingDishes; // 0x2E0
    public Transform SP_Dishes; // 0x2E8
    public float TimerWashingDishes; // 0x2F0
    public float TimerMaxDishes; // 0x2F4
    public bool AtDishes; // 0x2F8

    // Constructors
    public void .ctor() { }

    // Methods
    /// @brief Applies difficulty and weapon chosen in the main menu.
    /// @details Decompiled (IDA):
    /// @code{.cpp}
    /// void AI_Granny$$Start(AI_Granny_o *this, const MethodInfo *method)
    /// {
    ///   const MethodInfo *v3; // rdx
    ///   UnityEngine_GameObject_o *Bats_1; // rcx
    ///   UnityEngine_GameObject_o *Weapon; // rcx
    ///   UnityEngine_GameObject_o *Bats; // rcx
    ///
    ///   if ( byte_CE7498 == 0 )
    ///   {
    ///     il2cpp_codegen_initialize_runtime_metadata(a1: &str_Difficulty, method);
    ///     il2cpp_codegen_initialize_runtime_metadata(a1: &str_GrannyWeapon, method: v3);
    ///     byte_CE7498 = 1;
    ///   }
    ///   // Can be optimized by a mod if:
    ///   // Called the playerprefs function in a switch, then handle there, it is not that hard to re-create the function
    ///   if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) != 0 )
    ///   {
    ///     // normal
    ///     if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 1 )
    ///     {
    ///       this->fields.Run_Speed = 3.8f;
    ///       this->fields.Run_Anim = 1.9f;
    ///       this->fields.TimerMaxShoot = 1.4f;
    ///     }
    ///     // hard
    ///     else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 2 )
    ///     {
    ///       this->fields.Run_Speed = 5.0;
    ///       this->fields.Run_Anim = 2.5;
    ///       this->fields.TimerMaxShoot = 0.9f;
    ///     }
    ///     // extreme
    ///     else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 3 )
    ///     {
    ///       this->fields.Run_Speed = 8.5;
    ///       this->fields.Run_Anim = 4.25;
    ///       this->fields.TimerMaxShoot = 0.5;
    ///     }
    ///     // impossible
    ///     else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 4 )
    ///     {
    ///       this->fields.Run_Speed = 12.0;
    ///       this->fields.Run_Anim = 5.0;
    ///       this->fields.DistanceJumpscare = 3.5;
    ///       this->fields.TimerSaunaMax = 5.0;
    ///       this->fields.TimerMaxShoot = 0.2f;
    ///     }
    ///     // hollow
    ///     else if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_Difficulty, method: nullptr) == 5 )
    ///     {
    ///       this->fields.Run_Speed = 14.0;
    ///       this->fields.Run_Anim = 5.6f;
    ///       this->fields.DistanceJumpscare = 4.0;
    ///       this->fields.TimerSaunaMax = 5.0;
    ///       this->fields.TimerMaxShoot = 0.1f;
    ///     }
    ///   }
    ///   else                                          // easy
    ///   {
    ///     this->fields.Run_Speed = 2.5;
    ///     this->fields.Run_Anim = 1.25;
    ///     this->fields.TimerMaxShoot = 1.8f;
    ///   }
    ///   if ( !this->fields.ChooseWeapon )
    ///   {
    ///     this->fields.ChooseWeapon = true;
    ///     // crossbow
    ///     if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_GrannyWeapon, method: nullptr) == 1 )
    ///     {
    ///       Bats = this->fields.Bats;
    ///       if ( Bats != nullptr )
    ///       {
    ///         UnityEngine.GameObject$$SetActive(this: Bats, value: false, method: nullptr);
    ///         Weapon = this->fields.Crossbow;
    /// SET_GRANNY_WEAPON_CROSSBOW:
    ///         if ( Weapon != nullptr )
    ///         {
    ///           UnityEngine.GameObject$$SetActive(this: Weapon, value: true, method: nullptr);
    ///           return;
    ///         }
    ///       }
    /// ERR_NULL_REFERENCE_EXCEPTION:
    ///       il2cpp_codegen_raise_null_reference_exception();
    ///     }
    ///     // pepper spray
    ///     if ( UnityEngine.PlayerPrefs$$GetInt_7508944(key: str_GrannyWeapon, method: nullptr) == 2 )
    ///     {
    ///       Bats_1 = this->fields.Bats;
    ///       if ( Bats_1 == nullptr )
    ///         goto ERR_NULL_REFERENCE_EXCEPTION;
    ///       UnityEngine.GameObject$$SetActive(this: Bats_1, value: false, method: nullptr);
    ///       Weapon = this->fields.Spray;
    ///       goto SET_GRANNY_WEAPON_CROSSBOW;
    ///     }
    ///   }
    /// }
    /// @endcode
    /// Behaviour:
    /// - Nested if loops that set Granny's stats to their according difficulty.
    /// - Sets the weapon of Granny if the Extras option, "Granny's weapon" is set to something else other than the weapon, "Bat" in the main menu.
    /// - "Bats" becomes inactive if the weapon is set something other than itself.
    private void Start() { }
    private void FixedUpdate() { }
    /// @brief Resets Granny when she is killed.
    /// @details Decompiled (IDA):
    /// @code{.cpp}
    /// void AI_Granny$$DeadDisable(AI_Granny_o *this, const MethodInfo *method)
    /// {
    ///   UnityEngine_Behaviour_o *BoneController; // rcx
    ///   BGManager_o *MusicBG; // rax
    ///   Eyes_Granny_o *EnemyVision; // rax
    ///   ScreenEffects_o *ScreenEffects; // rax
    ///   UnityEngine_Transform_o *v7; // rax
    ///   UnityEngine_Vector3_o *v8; // rax
    ///   float z; // ecx
    ///   UnityEngine_Behaviour_o *Agent; // rcx
    ///   UnityEngine_Vector3_o v11; // [rsp+20h] [rbp-18h] BYREF
    ///
    ///   AI_Granny$$MurderNoiseObjs(this, method: nullptr);
    ///   BoneController = this->fields.BoneController;
    ///   this->fields.TimerNearNoise = 0.0;
    ///
    ///   if ( BoneController == nullptr )
    ///     goto TRIGGER_NULL_REFERENCE_EXCEPTION;
    ///
    ///   UnityEngine.Behaviour$$set_enabled(this: BoneController, value: false, method: nullptr);
    ///   MusicBG = this->fields.MusicBG;
    ///
    ///   if ( MusicBG == nullptr )
    ///     goto TRIGGER_NULL_REFERENCE_EXCEPTION;
    ///
    ///   MusicBG->fields.GrannyHunting = false;
    ///   EnemyVision = this->fields.EnemyVision;
    ///
    ///   if ( EnemyVision == nullptr )
    ///     goto TRIGGER_NULL_REFERENCE_EXCEPTION;
    ///
    ///   EnemyVision->fields.IsChasing = false;
    ///   ScreenEffects = this->fields.ScreenEffects;
    ///
    ///   this->fields.IsChasing = false;
    ///   this->fields.IsSearching = false;
    ///   if ( ScreenEffects == nullptr
    ///     || (ScreenEffects->fields.NormalSee = false,
    ///         (v7 = UnityEngine.Component$$get_transform(this, method: nullptr)) == nullptr)
    ///     || (v8 = UnityEngine.Transform$$get_position(retstr: &v11, this: v7, method: nullptr),
    ///         z = v8->fields.z,
    ///         *&this->fields.CurrentTarget.fields.x = *&v8->fields.x,
    ///         this->fields.CurrentTarget.fields.z = z,
    ///         (Agent = this->fields.Agent) == nullptr) )
    ///   {
    /// TRIGGER_NULL_REFERENCE_EXCEPTION:
    ///     il2cpp_codegen_raise_null_reference_exception();
    ///   }
    ///   UnityEngine.Behaviour$$set_enabled(this: Agent, value: false, method: nullptr);
    ///   this->fields.PepperedEnemy = false;
    ///   this->fields.AtDishes = false;
    ///   this->fields.IsDying = true;
    ///   this->fields.UsingWeaponProjectile = false;
    /// }
    /// @endcode
    /// Behaviour:
    /// - Triggered when granny is killed
    /// - Resets her state to the same state she was in when the game started, except IsDying is true
    public void DeadDisable() { }
    public void StopAI() { }
    public void ResetAIDecision() { }
    public void ShootDart() { }
    public void FrozenEnemy() { }
    public void PepperHit() { }
    private IEnumerator UsageProjectile() { }
    private IEnumerator PepperedTimer() { }
    private IEnumerator FreezeProcess() { }
    private IEnumerator DartProcess() { }
    public void SensorPlayer() { }
    public void ChaseAction() { }
    public void StopChase() { }
    public void LookAtThings(GameObject ThatThing, float RotateSpeed) { }
    public void SpeakEnemy() { }
    public void MurderNoiseObjs() { }
    public void ResetCertainTimer() { }
    public void ChooseWaypoint() { }
    private IEnumerator SmackTimer() { }
    private void OnTriggerStay(Collider other) { }
    private void OnTriggerExit(Collider other) { }
}
