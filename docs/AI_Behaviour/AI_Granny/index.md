---
title: AI Granny
parent: AI Behaviour
nav_order: 1
has_children: true
---
# Class Definition:
```csharp
// Image: Assembly-CSharp.dll
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
    private void Start() { }
    private void FixedUpdate() { }
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
```

