---
title: GameInputManager
has_children: true
nav_order: 4
---
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

# Purpose
It's main purpose is to check whether the user owns the game or not by using the C# wrapper that calls the native steam_api64.dll, found at path\to\Granny Legacy_Data\Plugins\x86_64. Might be named GameInputManager just as bait so that people will skip it while trying to crack it. 

I deliberately left out the other functions as they do not serve any purpose, GameInputManager$$Update just has il2cpp noise, but just calls:
> Steamworks.SteamClient$$RunCallbacks(method: nullptr);
