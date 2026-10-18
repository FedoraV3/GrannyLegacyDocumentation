---
title: Awake
parent: GameInputManager
nav_order: 2
---

# Awake

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
