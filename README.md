# Puzzle Game Starter Template

This repository contains a starter template for creating puzzle games in Unity. It provides a foundational framework with essential systems to help you focus on building your unique puzzle logic and game content.

The template is designed with a clean separation between the core, reusable framework and the specific game implementation, making it easy to extend and customize.

## Core Features

*   **Scene Management**: Pre-configured scenes for Main Menu, Loading, and Gameplay.
*   **State Machine**: A robust state machine to manage high-level game states (e.g., `MainMenu`, `GamePlay`).
*   **Event Bus**: A decoupled event system for communication between different game components, reducing dependencies and improving modularity.
*   **Level Management**: A `LevelManager` to handle level loading, progression, and setup.
*   **Prefs Management**: A `PrefsManager` for basic data persistence (e.g., saving and loading player settings).
*   **Modular Project Structure**: A clear distinction between the reusable `PuzzleTemplate` framework and the game-specific `Client` code.

## Architecture

The template's architecture is built on the principle of separating reusable, generic systems from the specific game logic.

### Separation of Concerns: `PuzzleTemplate` vs. `Client`

*   **`Assets/PuzzleTemplate`**: This is the core framework. It contains all the domain-agnostic systems that can be reused across different puzzle games. It includes the `Bootstrap`, `EventBus`, `StateMachine`, and abstract `Puzzle` definitions. You should generally not need to modify the code in this directory.

*   **`Assets/Client`**: This is your game. It contains the concrete implementation of your puzzle, including specific game logic, prefabs (`PuzzleTile.prefab`), scenes (`GamePlay.unity`), and managers (`LevelManager.cs`). This is where you will spend most of your development time.

### Application Flow

1.  **Bootstrap**: The game starts from the `Loading` scene, where a `Bootstrap` script initializes core systems like the `EventBus` and `StateMachine`.
2.  **State Machine**: The `StateMachine` then transitions to the `MainMenuState`, loading the `MainMenu` scene.
3.  **User Interaction**: When the player clicks a 'Play' button, a UI event is fired via the `EventBus`.
4.  **Level Management**: The `LevelManager` listens for this event and proceeds to load the `GamePlay` scene, setting up the puzzle for the first level.
5.  **Gameplay**: The player interacts with puzzle elements. These interactions trigger events on the `EventBus`, which are handled by your puzzle logic within the `Client`.
6.  **Puzzle Completion**: When a puzzle is solved, a `PuzzleSolvedEvent` can be fired, allowing the `LevelManager` or UI to react by loading the next level or showing a victory screen.

## How to Extend the Template

This template is designed to be easily extended. Here are the common steps for building your own puzzle game.

### 1. Create Your Puzzle Logic

*   Inherit from the base puzzle classes/interfaces found in `Assets/PuzzleTemplate/Runtime/Puzzle`.
*   Implement your specific game rules and logic inside a new script within the `Assets/Client/Runtime/Puzzle` directory.
*   Create new prefabs for your puzzle pieces in `Assets/Client/Prefabs/` and associate your new scripts with them.

### 2. Create New Levels

*   The `LevelManager.cs` (`Assets/Client/Runtime/LevelManager.cs`) is responsible for loading level data.
*   You can extend it to load level data from ScriptableObjects, JSON files, or any other source.
*   Add your level configuration data and register it with the `LevelManager`.

### 3. Customize the UI

*   Modify the UI prefabs located in `Assets/Client/Prefabs/Views/`.
*   Connect your new UI elements to the `EventBus` to send and receive events. For example, a new button in the main menu could fire a `StartNewGameModeEvent`.

## Project Structure

```
.
+-- Assets
¦   +-- Client/               # Your game-specific implementation
¦   ¦   +-- Runtime
¦   ¦   ¦   +-- LevelManager.cs # Manages level loading and progression
¦   ¦   ¦   +-- ...
¦   ¦   +-- Prefabs/            # Game element prefabs (e.g., PuzzleTile)
¦   ¦   +-- Scenes/             # Game scenes (e.g., GamePlay, MainMenu)
¦   ¦
¦   +-- PuzzleTemplate/       # The core, reusable framework
¦       +-- Runtime
¦       ¦   +-- Bootstrap/      # Application entry point & initialization
¦       ¦   +-- EventBus/       # Global event system
¦       ¦   +-- StateMachine/   # Game state management
¦       ¦   +-- Puzzle/         # Abstract puzzle definitions
¦       +-- ...
¦
+-- ProjectSettings/          # Unity project settings
+-- Packages/                 # Package manifests
```
