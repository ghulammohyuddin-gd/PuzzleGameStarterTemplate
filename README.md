# 🧩 Puzzle Game Starter Template (Unity)

## 🎯 Overview

This Unity template provides a fully functional **starter system for procedural puzzle games**, including:

- Level-based progression with procedural grid generation.
- Move-based gameplay logic.
- Win and Lose UI.
- Audio system for SFX and Music.
- Loading system with **Command Pattern** for initializing static data, player progress, and services.
- Flexible structure allowing any type of puzzle (tiles, blocks, logic puzzles, car blocks, etc.).

This template is designed as a **starting point** so developers can quickly create new puzzle games.

---

## 🏞 Scenes

### 1️⃣ Loading Scene
- Displays **progress bar** while loading game systems.
- Uses **commands** to initialize systems:
  - `LoadStaticDataCommand`: Loads static assets or placeholder stubs.
  - `LoadPlayerProgressCommand`: Loads saved progress.
  - `LoadAudioCommand`: Initializes AudioManager and default audio setup.
  - `LoadServiceCommand`: Additional service initialization.
- **LoadingUIController** updates the progress bar and status text.

### 2️⃣ MainMenu Scene
- **MainMenuCanvas**
  - Panels: Home, Store, Leaderboard, Map, Settings.
  - Bottom navigation buttons to switch panels.
- **MainMenuUIManager** handles panel switching and Play button logic.
- Play button calls:  
```csharp
GameFlowManager.Instance.StartGameplay();



3️⃣ Gameplay Scene
HUDCanvas: Displays moves and current level.

ResultCanvas: WinScreen and LoseScreen panels.

LevelManager (Singleton, DontDestroyOnLoad)

Coordinates level generation, moves, and progression.

PuzzleController: Generates puzzle elements (tiles, blocks, etc.) based on LevelData.

MoveCounter: Tracks moves and triggers lose condition.

TileInputHandler: Handles mouse/touch input for puzzle elements.

📁 Folder Structure
less
Copy code
Assets/
├── Audio/
│   ├── AudioManager.cs
│   ├── AudioSettings.cs
│   └── Prefab: AudioSystem (with MusicSource & SFX AudioSource)
├── Controllers/
│   ├── LevelManager.cs
│   ├── MoveCounter.cs
│   ├── PuzzleController.cs
│   └── PuzzleTile.cs
├── Core/
│   ├── GameEvents.cs
│   └── GameFlowManager.cs
├── Generation/
│   ├── LevelConfig.cs
│   ├── LevelData.cs
│   └── ProceduralLevelGenerator.cs
├── Input/
│   └── TileInputHandler.cs
├── Loading/
│   ├── Core/
│   │   ├── ILoadingCommand.cs
│   │   ├── LoadingCommandBase.cs
│   │   └── LoadingManager.cs
│   ├── Commands/
│   │   ├── LoadStaticDataCommand.cs
│   │   ├── LoadPlayerProgressCommand.cs
│   │   ├── LoadAudioCommand.cs
│   │   └── LoadServiceCommand.cs
│   └── UI/
│       └── LoadingUIController.cs
├── Persistance/
│   └── ProgressManager.cs
├── UI/
│   ├── HUDController.cs
│   ├── HomePanelController.cs
│   ├── LeaderBoardPanelController.cs
│   ├── LoseScreen.cs
│   ├── MainMenuUIManager.cs
│   ├── MapPanelController.cs
│   ├── NavigationPanelController.cs
│   ├── PlayButtonHandler.cs
│   ├── SettingsPanelController.cs
│   ├── StorePanelController.cs
│   ├── UIManager.cs
│   └── WinScreen.cs
├── Prefabs/
│   ├── PuzzleTile.prefab
│   ├── AudioSystem.prefab
│   └── UI prefabs (HUDCanvas, LoadingCanvas, WinScreenPanel, LoseScreenPanel, MainMenuCanvas)
└── ScriptableObjects/
    └── LevelConfig.asset
⚡ Commands
Commands are executed sequentially in the Loading Scene using a command queue:

Command	Purpose
LoadStaticDataCommand	Loads static assets or placeholder stubs.
LoadPlayerProgressCommand	Loads saved player progress (level index, unlocked content).
LoadAudioCommand	Initializes AudioManager and default audio sources.
LoadServiceCommand	Initializes other services or SDKs required by the game.

✅ Tip: Commands can be dragged in LoadingManager inspector as a list. This allows adding new commands without modifying code.

🧩 Prefabs
PuzzleTile.prefab → Base prefab for generating puzzle elements (green/red tile or custom block).

AudioSystem.prefab → Contains MusicSource and SFX AudioSource. Add audio clips in editor.

UI Prefabs:

HUDCanvas (Moves & Level display)

LoadingCanvas (Progress bar)

WinScreenPanel / LoseScreenPanel

MainMenuCanvas

🛠 How to Add a New Puzzle
Supports any type of puzzle, not only tiles:

Create Puzzle Prefab(s)

Blocks, tiles, car pieces, logic elements, etc.

Add colliders if interaction is needed.

Create Puzzle Controller

Similar to PuzzleController.cs.

Responsibilities:

Generate puzzle elements based on LevelData.

Track puzzle progress (completion/fail condition).

Notify LevelManager or fire events:

csharp
Copy code
GameEvents.OnLevelWin?.Invoke();
GameEvents.OnLevelLose?.Invoke();
Integrate Move System (Optional)

csharp
Copy code
MoveCounter.Instance.UseMove();
HUD updates automatically via OnMovesChanged event.

LevelManager Integration

LevelManager.Instance.LoadNextLevel() will call your puzzle controller generation.

Tracks level, progress, and resets state as needed.

UI Integration

Win/Lose panels respond automatically to events.

Home button: GameFlowManager.Instance.GoToMainMenu()

Play button: GameFlowManager.Instance.StartGameplay()

Audio Integration

csharp
Copy code
AudioManager.Instance.PlaySFX(clip);
AudioManager.Instance.PlayMusic(musicClip);
🔑 Key idea: Your puzzle only needs to notify LevelManager or fire events. All progression, moves, and UI are handled by the template.

🛤 Scenes & Flow
Loading Scene → Initializes commands (audio, progress, services) → Loads MainMenu.

MainMenu Scene → Navigate panels → Play button starts Gameplay.

Gameplay Scene → LevelManager generates level → PuzzleController generates puzzle → MoveCounter tracks moves → UIManager handles HUD & Win/Lose screens.

GameFlowManager → Singleton that handles scene transitions and resets gameplay state.

🚀 Getting Started
Open project in Unity.

Assign audio clips to AudioSystem prefab.

Assign PuzzleTile prefab in PuzzleController.

Open LevelConfig.asset to configure level settings.

Play Loading Scene → initializes all systems → loads MainMenu.

Press Play in MainMenu → first level is generated with moves and UI.

✨ Extending Template
Add new commands: Inherit from LoadingCommandBase → drag into LoadingManager inspector.

Add new puzzle type: Create PuzzleController and prefab → fire events to link with existing LevelManager & UI.

Reuse MoveCounter and UIManager to minimize boilerplate.

✅ Summary
Flexible template for procedural puzzles.

Commands ensure modular initialization.

UI, audio, moves, and levels are ready to use.

Developers can replace puzzle logic without modifying core systems.
