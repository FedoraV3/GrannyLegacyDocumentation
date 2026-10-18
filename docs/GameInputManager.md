---
title: GameInputManager
nav_order: 2
---
**Reminder that using offsets is much more worser, get into the game assemblies to find them more reliably!**


# Class Definition

```csharp
public class GameInputManager : UnityEngine.MonoBehaviour // TypeDefIndex: 91
{
    // Fields
    public bool TouchedScreen; // 0x20
    public static GameInputManager Instance; // 0x0

    // Constructors
    public void .ctor() {}

    // Methods
    private void Awake() {}
    private void Start() {}
    private void Update() {}
    private void OnApplicationQuit() {}
}
```

# Decompiled Code And Notes
**GameInputManager$$Start**:
```cpp
void GameInputManager$$Start(GameInputManager_o *this, const MethodInfo *method)
{
  Steamworks_SteamClient_c *steam_client; // rcx
  __int64 v3; // rax
  Il2CppExceptionWrapper *exception_0; // rdi
  __int64 v5; // [rsp+20h] [rbp-18h] BYREF
  Il2CppExceptionWrapper *exception; // [rsp+28h] [rbp-10h] BYREF

  if ( byte_CE7537 == 0 )
  {
    il2cpp_codegen_initialize_runtime_metadata();
    il2cpp_codegen_initialize_runtime_metadata();
    byte_CE7537 = 1;
  }
  try
  {
    steam_client = Steamworks.SteamClient_TypeInfo;
    if ( Steamworks.SteamClient_TypeInfo->_2.cctor_finished == 0 )
    {
      j_il2cpp_runtime_class_init(a1: Steamworks.SteamClient_TypeInfo);
      steam_client = Steamworks.SteamClient_TypeInfo;
    }

    if ( byte_CE755B == 0 )
    {
      il2cpp_codegen_initialize_runtime_metadata();
      byte_CE755B = 1;
      steam_client = Steamworks.SteamClient_TypeInfo;
    }

    if ( steam_client->_2.cctor_finished == 0 )
    {
      j_il2cpp_runtime_class_init(a1: steam_client);
      steam_client = Steamworks.SteamClient_TypeInfo;
    }

    if ( !steam_client->static_fields->initialized )
    {
      if ( steam_client->_2.cctor_finished == 0 )
        j_il2cpp_runtime_class_init(a1: steam_client);

      Steamworks.SteamClient$$Init(appid: 962400u, asyncCallbacks: true, method: nullptr);
      steam_client = Steamworks.SteamClient_TypeInfo;
    }

    if ( steam_client->_2.cctor_finished == 0 )
      j_il2cpp_runtime_class_init(a1: steam_client);
  }
  catch ( Il2CppExceptionWrapper *exception )
  {
    exception_0 = exception;
    il2cpp_codegen_resolve_runtime_metadata(a1: &System.Exception_TypeInfo);
    if ( j_il2cpp_class_is_assignable_from() == 0 )
    {
      v5 = *exception_0;
      throw &v5;
    }
    v3 = il2cpp_codegen_resolve_runtime_metadata(a1: &UnityEngine.Application_TypeInfo);
    if ( *(v3 + 224) == 0 )
      j_il2cpp_runtime_class_init(a1: v3);
    UnityEngine.Application$$Quit_7329808(method: nullptr);
  }
}
```

**Behaviour**
- **Uses a try and catch clause, to catch errors, mostly from Steamworks.SteamClient$$Init**
- **If it catches an error it ungracefully closes the game**
- **Spawned in the MainMenu scene**

**GameInputManager$$Awake**:
```cpp
void GameInputManager$$Awake(GameInputManager_o *this, const MethodInfo *method)
{
  const MethodInfo *method_1; // rdx
  const MethodInfo *method_2; // rdx
  const MethodInfo *method_3; // rdx
  const MethodInfo *method_4; // rdx
  const MethodInfo *method_5; // rdx
  const MethodInfo *method_6; // rdx
  const MethodInfo *method_7; // rdx
  System_String_o *Granny_Legacy_Data_Path; // rbx
  System_String_o *string_result; // rbx
  System_String_o *string_result_1; // rbp
  System_String_o *string_result_2; // rdi
  System_IO_FileInfo_o *v14; // rbx
  UnityEngine_Object_o *Instance; // rbx

  if ( byte_CE7536 == 0 )
  {
    // a2 is just a method, NULL is passed into them
    il2cpp_codegen_initialize_runtime_metadata(a1: &UnityEngine.Application_TypeInfo, method);
    il2cpp_codegen_initialize_runtime_metadata(a1: &System.IO.FileInfo_TypeInfo, method: method_1);
    il2cpp_codegen_initialize_runtime_metadata(a1: &GameInputManager_TypeInfo, method: method_2);
    il2cpp_codegen_initialize_runtime_metadata(a1: &UnityEngine.Object_TypeInfo, method: method_3);
    il2cpp_codegen_initialize_runtime_metadata(a1: &System.IO.Path_TypeInfo, method: method_4);
    il2cpp_codegen_initialize_runtime_metadata(a1: &str_x86_64, method: method_5);
    il2cpp_codegen_initialize_runtime_metadata(a1: &str_steam_api64.dll, method: method_6);
    il2cpp_codegen_initialize_runtime_metadata(a1: &str_plugins, method: method_7);
    byte_CE7536 = 1;
  }
  if ( UnityEngine.Application_TypeInfo->_2.cctor_finished == 0 )
    j_il2cpp_runtime_class_init(a1: UnityEngine.Application_TypeInfo);
  Granny_Legacy_Data_Path = UnityEngine.Application$$get_dataPath(method: nullptr);
  if ( System.IO.Path_TypeInfo->_2.cctor_finished == 0 )
    j_il2cpp_runtime_class_init(a1: System.IO.Path_TypeInfo);
  // renamed the ambigious string_literal structs to what their string corresponds to
  // this forms the string path to the steam_api64.dll
  string_result = System.IO.Path$$Combine(path1: Granny_Legacy_Data_Path, path2: str_plugins, method: nullptr);
  string_result_1 = System.IO.Path$$Combine(path1: string_result, path2: str_x86_64, method: nullptr);
  string_result_2 = System.IO.Path$$Combine(path1: string_result_1, path2: str_steam_api64.dll, method: nullptr);
  if ( !System.IO.Directory$$Exists(path: string_result, method: nullptr)
    || !System.IO.Directory$$Exists(path: string_result_1, method: nullptr)
    || !System.IO.File$$Exists(path: string_result_2, method: nullptr) )
  {
    goto QUIT_GAME;
  }
  v14 = sub_EFA30(a1: System.IO.FileInfo_TypeInfo);
  System.IO.FileInfo$$.ctor_4394640(this: v14, fileName: string_result_2, method: nullptr);
  if ( v14 == nullptr )
    il2cpp_codegen_raise_null_reference_exception();
  // lol
  if ( System.IO.FileInfo$$get_Length(this: v14, method: nullptr) == 262944 )
  {
    Instance = GameInputManager_TypeInfo->static_fields->Instance;
    if ( UnityEngine.Object_TypeInfo->_2.cctor_finished == 0 )
      j_il2cpp_runtime_class_init(a1: UnityEngine.Object_TypeInfo);
    if ( UnityEngine.Object$$op_Equality(x: Instance, y: nullptr, method: nullptr) )
      GameInputManager_TypeInfo->static_fields->Instance = this;
  }
  else
  {
QUIT_GAME:
    if ( UnityEngine.Application_TypeInfo->_2.cctor_finished == 0 )
      j_il2cpp_runtime_class_init(a1: UnityEngine.Application_TypeInfo);
    UnityEngine.Application$$Quit_7329808(method: nullptr);
  }
}
```

**Behaviour**
- Forms a string to the path: "\path\to\grannylegacy_data\plugins\x86_64\steam_api64.dll"
- Checks if the size is exactly 262944 bytes, otherwise it force closes the game (byte patching easily bypasses this because you have to nop out to align with the entire bytes of a program, so that offsets still work and the program too)

**Notes**
- This doesn't do anything or handle anything about game inputs. It is a simple protection implemented into the game scene, MainMenu.

# Purpose
It's main purpose is to check whether the user owns the game or not by using the C# wrapper that calls the native steam_api64.dll, found at path\to\Granny Legacy_Data\Plugins\x86_64. Might be named GameInputManager just as bait so that people will skip it while trying to crack it.