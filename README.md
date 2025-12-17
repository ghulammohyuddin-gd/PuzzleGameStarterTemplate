# Puzzle Game Starter Template

## Overview
This Unity template provides a **starter foundation** for building procedural puzzle games. It includes scene setup, UI, audio, level generation, move management, and a flexible command-based loading system.

The template is designed so developers can reuse or extend scripts, prefabs, and UI to quickly implement new puzzle types.

---

## Project Structure
```
Assets/
├── Prefabs/
│   ├── AudioSystem.prefab
│   │    ├── MusicSource
│   │    └── SFXSource
│   ├── PuzzleTile.prefab
│   └── UI Prefabs (HUDCanvas, LoadingCanvas, LoseScreenPanel, MainMenuCanvas, WinScreenPanel)
├── ScriptableObjects/
│   └── LevelConfig.asset
├── Scripts/
│   ├── Audio/
│   │    ├── AudioManager.cs
│   │    └── AudioSettings.cs
│   ├── Controllers/
│   │    ├── LevelManager.cs
│   │    ├── MoveCounter.cs
│   │    ├── PuzzleController.cs
│   │    └── PuzzleTile.cs
│   ├── Core/
│   │    ├── GameEvents.cs
│   │    └── GameFlowManager.cs
│   ├── Generation/
│   │    ├── LevelConfig.cs
│   │    ├── LevelData.cs
│   │    └── ProceduralLevelGenerator.cs
│   ├── Input/
│   │    └── TileInputHandler.cs
│   ├── Loading/
│   │    ├── Commands/
│   │    │    ├── LoadAudioCommand.cs
│   │    │    ├── LoadPlayerProgressCommand.cs
│   │    │    ├── LoadServiceCommand.cs
│   │    │    └── LoadStaticDataCommand.cs
│   │    ├── Core/
│   │    │    ├── ILoadingCommand.cs
│   │    │    ├── LoadingCommandBase.cs
│   │    │    └── LoadingManager.cs
│   │    └── UI/
│   │         └── LoadingUIController.cs
│   ├── Persistence/
│   │    └── ProgressManager.cs
│   └── UI/
│        ├── HomePanelController.cs
│        ├── HUDController.cs
│        ├── LeaderboardPanelController.cs
│        ├── LoseScreen.cs
│        ├── MainMenuUIManager.cs
│        ├── MapPanelController.cs
│        ├── NavigationPanelController.cs
│        ├── PlayButtonHandler.cs
│        ├── SettingsPanelController.cs
│        ├── StorePanelController.cs
│        ├── UIManager.cs
│        └── WinScreen.cs
```

---

## Scenes
- **LoadingScene**: Handles loading commands sequentially with a progress bar.
- **MainMenu**: Bottom navigation buttons, panels for Home, Store, Leaderboard, Map, Settings.
- **Gameplay**: Procedural puzzle grid, move counter, HUD, Win/Lose screens.

---

## Key Scripts & Responsibilities
### Core
- `GameFlowManager.cs` → Manages scene transitions and resetting game state.
- `GameEvents.cs` → Event system for level changes, moves updates, win/lose.

### Controllers
- `LevelManager.cs` → Singleton. Loads/Generates levels, manages move count, handles Restart/Next Level.
- `PuzzleController.cs` → Singleton. Generates tiles, tracks green tile clicks.
- `MoveCounter.cs` → Singleton. Tracks moves remaining, triggers lose event.
- `PuzzleTile.cs` → Handles individual tile behavior and clicks.

### Audio
- `AudioManager.cs` → Singleton. Manages Music and SFX sources.
- `AudioSettings.cs` → Configurable settings for volume, mute, etc.

### Generation
- `ProceduralLevelGenerator.cs` → Generates LevelData based on level index.
- `LevelData.cs` → Stores grid size and tile info.
- `LevelConfig.cs` → ScriptableObject for configuring levels.

### Input
- `TileInputHandler.cs` → Detects clicks/taps on tiles and forwards to `PuzzleTile`.

### Loading System
**Command Pattern** is used to load services in sequence:
- `LoadStaticDataCommand` → Placeholder for static data.
- `LoadServiceCommand` → Initialize any required services.
- `LoadPlayerProgressCommand` → Loads saved level progress.
- `LoadAudioCommand` → Initializes AudioManager.

**LoadingManager.cs** → Runs commands sequentially and updates `LoadingUIController`.

### UI
- Each Panel has its own controller (e.g., `HomePanelController.cs`) to handle children.
- `UIManager.cs` → Shows/Hides Win/Lose screens, updates HUD.
- `WinScreen.cs` & `LoseScreen.cs` → Handle button events: Next Level, Restart, Home.

---

## Prefabs & Scene Objects
- **AudioSystem.prefab** → Contains MusicSource & SFXSource. Assign clips in editor.
- **PuzzleTile.prefab** → Base prefab for any puzzle tile. Can be extended for different puzzle types.
- **UI Prefabs** → HUDCanvas, LoadingCanvas, LoseScreenPanel, MainMenuCanvas, WinScreenPanel.

> All scene objects are already setup. Developers only need to assign audio clips or add new puzzle visuals.

---

## How to Extend for Custom Puzzle
1. **Tile-based Puzzles**:
    - Extend `PuzzleTile` for new behaviors (e.g., CarBlockTile, NumberTile).
    - Use `PuzzleController` to generate grid for any tile prefab.
2. **Non-tile Puzzles**:
    - Create your puzzle prefab and manager.
    - Call `GameEvents.OnLevelWin?.Invoke()` when puzzle is solved.
    - Use `MoveCounter.Instance.UseMove()` to decrement moves if needed.
3. **Linking**:
    - Gameplay scene references (PuzzleController, MoveCounter, LevelGenerator) are automatically linked.
    - LevelManager remains singleton; only assign scene-specific references once in scene.

> This template is designed to be modular. Developers can reuse `MoveCounter`, `PuzzleController`, `LevelManager` for any new puzzle type without rewriting core logic.

---

## Getting Started
1. Open `MainMenu` scene.
2. Ensure `AudioSystem.prefab` has Music & SFX clips assigned.
3. Click **Play** → Gameplay scene will load.
4. Tile clicks reduce moves. Green tiles completion triggers WinScreen. Moves exhausted triggers LoseScreen.
5. Navigation buttons allow returning Home, Store, Map, Settings.

---

## Notes
- `LevelManager` is singleton and persists between scenes.
- `PuzzleController` & `MoveCounter` are scene objects. Their references are registered to `LevelManager` on scene load.
- Commands in LoadingScene can be extended by adding new classes implementing `ILoadingCommand`.
- Developers can adjust grid size, number of green tiles, or add special tile types via `ProceduralLevelGenerator` and `LevelData`.

---

## Summary
This template provides a **flexible foundation** for any puzzle game, allowing you to focus on creating unique puzzles without re-implementing core systems like level generation, UI, audio, or scene management.

