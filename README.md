# Puzzle Game Starter Template

Welcome to the **Puzzle Game Starter Template** for Unity. This project provides a robust starting point for any tile-based or puzzle game, with procedural levels, UI, audio, and game flow management.

---

## 📂 Project Structure

### Scenes

- **Loading Scene**
  - **LoadingCanvas**: Displays progress bar for loading commands.
  - **LoadingManager**: Executes commands sequentially (LoadStaticDataCommand, LoadPlayerProgressCommand, LoadAudioCommand, etc.).
  - **AudioSystem**: Contains MusicSource and SFXSource (assign clips in the Inspector).
  - **GameFlowManager**: Handles scene transitions and game state resets.

- **MainMenu Scene**
  - **MainMenuCanvas**: Root canvas for main menu UI.
    - Panels: HomePanel, StorePanel, LeaderboardPanel, MapPanel, SettingsPanel.
    - **PlayButtonHandler**: Handles play button input.
    - **NavigationPanelController**: Handles bottom navigation buttons.
  - **TileInputHandler**: Handles global tile input for gameplay scene.
  - **UI Root**: Contains HUDCanvas and ResultCanvas.
    - **UIManager**: Manages HUD, WinScreen, LoseScreen.

- **Gameplay Scene**
  - **PuzzleController**: Generates grid based on procedural level.
  - **LevelManager**: Singleton managing level progression.
  - **MoveCounter**: Tracks moves for current level.
  - **ProceduralLevelGenerator**: Generates LevelData for each level.
  - **PuzzleTile Prefabs**: Tiles for gameplay grid.
  - **HUDCanvas / ResultCanvas**: Display HUD and Win/Lose screens.

### Scripts

#### Audio
- `AudioManager.cs`: Handles playing music and SFX.
- `AudioSettings.cs`: Configuration for audio.

#### Controllers
- `LevelManager.cs`: Handles level progression, singleton.
- `PuzzleController.cs`: Handles grid generation and tile interactions.
- `MoveCounter.cs`: Tracks and manages moves.
- `PuzzleTile.cs`: Individual tile behavior.

#### Core
- `GameFlowManager.cs`: Manages scene transitions and game resets.
- `GameEvents.cs`: Event system for level updates.

#### Generation
- `LevelConfig.cs`: ScriptableObject for level settings.
- `LevelData.cs`: Holds level-specific data.
- `ProceduralLevelGenerator.cs`: Procedural generation logic.

#### Input
- `TileInputHandler.cs`: Captures player input for tile clicks.

#### Loading
- **Core**
  - `ILoadingCommand.cs`: Interface for loading commands.
  - `LoadingCommandBase.cs`: Base class for loading commands.
  - `LoadingManager.cs`: Executes loading commands sequentially.
- **Commands**
  - `LoadStaticDataCommand.cs`: Loads static game data.
  - `LoadPlayerProgressCommand.cs`: Loads saved progress.
  - `LoadAudioCommand.cs`: Loads AudioSystem.
- **UI**
  - `LoadingUIController.cs`: Updates progress bar and loading text.

#### Persistence
- `ProgressManager.cs`: Save/load player progress using PlayerPrefs.

#### UI
- `HomePanelController.cs`
- `HUDController.cs`
- `LeaderBoardPanelController.cs`
- `LoseScreen.cs`
- `MainMenuUIManager.cs`
- `MapPanelController.cs`
- `NavigationPanelController.cs`
- `PlayButtonHandler.cs`
- `SettingsPanelController.cs`
- `StorePanelController.cs`
- `UIManager.cs`
- `WinScreen.cs`

### Prefabs
- **AudioSystem**: Contains MusicSource and SFXSource.
- **Tiles**: PuzzleTile prefab.
- **UI**: HUDCanvas, LoadingCanvas, LoseScreenPanel, MainMenuCanvas, WinScreenPanel.

### ScriptableObjects
- **LevelConfig**: Configure procedural level settings.

---

## 🚀 Getting Started

1. **Open `Loading` Scene** first.
2. Ensure **AudioSystem** has MusicSource and SFXSource clips assigned.
3. Run scene: LoadingManager will execute commands and show progress.
4. After loading, **MainMenu Scene** appears.
5. Tap **Play** → loads Gameplay Scene.

---

## ⚡ Usage Guide

### Adding Custom Puzzle Logic

- **Custom Puzzle Type**: Any puzzle (tile-based, car blocks, numbers, etc.)
- **Starting Point**: `PuzzleController.cs` handles grid and tile logic.
- **Tile Behavior**: Extend `PuzzleTile.cs` or replace tile prefab for custom behavior.
- **Level Generation**: Modify or extend `ProceduralLevelGenerator.cs` to create procedural or static level patterns.
- **Move Tracking**: Use `MoveCounter.cs` to track moves.
- **Level Management**: Use `LevelManager.cs` for progression, `GameFlowManager.cs` for scene transitions.

### Linking Custom Puzzle

1. Replace `tilePrefab` in `PuzzleController` with your custom prefab.
2. Update `ProceduralLevelGenerator` to generate your custom tiles.
3. Use `PuzzleTile` or your custom tile script to handle click/interactions.
4. `MoveCounter` and `LevelManager` will integrate automatically for level win/lose logic.

### Commands Execution

- **LoadStaticDataCommand**: Load all static assets/data.
- **LoadPlayerProgressCommand**: Loads saved level index.
- **LoadAudioCommand**: Prepares audio system.
- Commands run sequentially in **LoadingManager** and update `LoadingUIController`.

### UI Handling

- `UIManager.cs` controls HUD, WinScreen, LoseScreen.
- Each panel has its own controller for buttons and functionality.
- **Home button**: Uses `GameFlowManager.Instance.GoToMainMenu()`
- **Play button**: Uses `GameFlowManager.Instance.StartGameplay()`

---

## 📝 Notes

- **Singletons**: LevelManager, PuzzleController, MoveCounter are singletons.
- **Scene Flow**: Loading Scene → MainMenu → Gameplay.
- **Extensibility**: This template allows easy addition of new puzzle types by modifying `PuzzleController` and `ProceduralLevelGenerator`.

---

## 📌 Summary

- Template handles procedural levels, moves, win/lose logic.
- Commands system ensures sequential loading of game systems.
- UI is modular and reusable.
- Audio system is included.
- Users can replace or extend tile types and level logic without changing core systems.

This template is designed to provide a **plug-and-play s
