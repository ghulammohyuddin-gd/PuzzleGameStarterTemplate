# Puzzle Game Starter Template

This repository contains a starter template for creating puzzle games in Unity. It provides a foundational framework with essential systems to help you focus on building your unique puzzle logic and game content.

The template is designed with a clean separation between the core, reusable framework and the specific game implementation, making it easy to extend and customize.

## Core Features

*   **Scene Management**: Pre-configured scenes for Main Menu, Loading, and Gameplay.
*   **Sequential Loading System**: An extensible, order-dependent loading system in the `Loading` scene to prevent race conditions during bootstrap.
*   **UI State Machine**: A state machine to manage UI view states (e.g., switching between different panels in the main menu).
*   **Event Bus**: A decoupled event system for communication between different game components.
*   **Abstract Puzzle System**: A set of core interfaces (`IPuzzle`, `IPuzzleData`, `IPuzzleGenerator`, `IWinConditionChecker`) to build any kind of puzzle logic.
*   **Level Management**: A `LevelManager` to handle level loading, progression, and setup.
*   **Prefs Management**: A `PrefsManager` for basic data persistence.
*   **Modular Project Structure**: A clear distinction between the reusable `PuzzleTemplate` framework and the game-specific `Client` code.
*   **Safe Area**: A `Safe Area Handler` for UI handling across different mobile devices.

## Architecture

The template's architecture is built on the principle of separating reusable, generic systems from the specific game logic.

### Separation of Concerns: `PuzzleTemplate` vs. `Client`

*   **`Assets/PuzzleTemplate`**: This is the core framework. It contains all the domain-agnostic systems that can be reused across different puzzle games. It includes the `Bootstrap` logic, `EventBus`, `StateMachine` for UI, and abstract `Puzzle` definitions. You should generally not need to modify the code in this directory.

*   **`Assets/Client`**: This is your game. It contains the concrete implementation of your puzzle, including specific game logic, prefabs (`PuzzleTile.prefab`), scenes (`GamePlay.unity`), and managers (`LevelManager.cs`). This is where you will spend most of your development time.

### Application Flow

1.  **Bootstrap (Loading Scene)**: The game starts from the `Loading` scene, which contains an `AppLoader`. This loader runs a sequence of loading steps assigned in the Inspector. This ensures that systems initialize in the correct order without race conditions. The final loading step transitions the game to the `MainMenu` scene.

2.  **UI Navigation (Main Menu)**: In the `MainMenu` scene, a `StateMachineViewsController` manages switching between different UI panels (views). Each view is a state in the UI state machine. Views are switched using a unique key, which can be assigned in the view's prefab (inheriting from `UIComponent`).

3.  **Starting Gameplay**: When the player presses the "Play" button on the main menu's home view, the `GamePlay` scene is loaded.

4.  **Puzzle Generation**: In the `GamePlay` scene, your puzzle is created. A class implementing the `IPuzzleGenerator` interface takes an `IPuzzleData` object and generates the puzzle instance (`IPuzzle`). These dependencies are injected where needed.

5.  **Gameplay & Win/Lose Conditions**: The player interacts with the puzzle elements. A custom class that implements `IWinConditionChecker` monitors the puzzle state. Based on your game's rules, it will raise `OnWin` or `OnLose` events. These events can be subscribed to by other systems (like the UI or `LevelManager`) to trigger a victory screen, a lose screen, or load the next level.

## How to Extend the Template

This template is designed to be easily extended.

### 1. Add a New Loading Step

- Create a new C# class that implements the `ILoadingStep` interface.
- In the `Loading` scene, select the GameObject with the `AppLoader` component.
- Add your new loading step to the list in the Inspector. Remember that the order matters.

### 2. Add a New UI View to the Main Menu

- Create a new UI panel/view as a prefab.
- Create a script for your view that inherits from `UIComponent` and assign a unique `key` in the prefab.
- Create a new "State View" script for your view logic.
- In the `MainMenu` scene, add your new state view to the `StateMachineViewsController` in the Inspector.

### 3. Create Your Puzzle Logic

-   **Define Puzzle Data**: Create a class that implements `IPuzzleData` to hold the configuration for a puzzle.
-   **Create a Puzzle Generator**: Create a class that implements `IPuzzleGenerator`. This class will take your `IPuzzleData` and create the actual puzzle grid and pieces.
-   **Implement Win/Lose Conditions**: Create a class that implements `IWinConditionChecker`. This class will check the state of your puzzle and fire `OnWin` or `OnLose` events.

## Project Structure

```
.
+-- Assets
�   +-- Client/               # Your game-specific implementation
�   �   +-- Runtime
�   �   �   +-- LevelManager.cs # Manages level loading and progression
�   �   �   +-- ...
�   �   +-- Prefabs/            # Game element prefabs (e.g., PuzzleTile)
�   �   +-- Scenes/             # Game scenes (e.g., GamePlay, MainMenu)
�   �
�   +-- PuzzleTemplate/       # The core, reusable framework
�       +-- Runtime
�       �   +-- Bootstrap/      # Application entry point & initialization
�       �   +-- EventBus/       # Global event system
�       �   +-- StateMachine/   # Game state management
�       �   +-- Puzzle/         # Abstract puzzle definitions
�       +-- ...
�
+-- ProjectSettings/          # Unity project settings
+-- Packages/                 # Package manifests
```
