---
title: Start
parent: GameInputManager
nav_order: 1
---

# Start

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
