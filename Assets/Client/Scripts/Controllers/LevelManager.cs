using Client.Runtime.Controllers.Interfaces;
using Client.Runtime.Generation;
using Client.Runtime.Persistance;
using UnityEngine;
using UnityEngine.SceneManagement;
using PuzzleTemplate.Runtime;
using Client.Runtime;

namespace Client.Runtime.Controllers
{
    /// <summary>Manages level progression, initialization, and state transitions.</summary>
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField]
        private PuzzleController puzzleController;

        [SerializeField]
        private MoveCounter moveCounter;

        [SerializeField]
        private ProceduralLevelGenerator levelGenerator;

        private int currentLevelIndex = 0;
        private LevelData currentLevel;

        protected override void Awake()
        {
            base.Awake();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        /// <summary>Called whenever a new scene is loaded to reassign scene-specific references.</summary>
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "GamePlay")
            {
                if (puzzleController == null)
                    puzzleController = FindFirstObjectByType<PuzzleController>();
                if (moveCounter == null)
                    moveCounter = FindFirstObjectByType<MoveCounter>();
                if (levelGenerator == null)
                    levelGenerator = FindFirstObjectByType<ProceduralLevelGenerator>();

                if (puzzleController != null && moveCounter != null && levelGenerator != null)
                    InitializeLevelManager();
                else
                    Debug.LogError("LevelManager: Scene references not found in Gameplay!");
            }
        }

        /// <summary>Initializes the level manager for a new gameplay session.</summary>
        public void InitializeLevelManager(int startLevelIndex = -1)
        {
            currentLevelIndex = startLevelIndex >= 0 ? startLevelIndex : ProgressManager.LoadLevel();
            LoadNextLevel();
        }

        /// <summary>Loads and initializes the next level.</summary>
        public void LoadNextLevel()
        {
            if (puzzleController == null || moveCounter == null || levelGenerator == null)
            {
                Debug.LogError("LevelManager: References not set!");
                return;
            }

            ProgressManager.SaveLevel(currentLevelIndex);
            currentLevel = levelGenerator.GenerateLevel(currentLevelIndex);
            puzzleController.InitializePuzzle(currentLevel);

            IGridManager gridManager = puzzleController.GridManager;
            if (gridManager != null)
            {
                moveCounter.Initialize(gridManager.TotalGreenTiles + 1);
            }

            EventBus.Raise(new LevelChangedEvent(currentLevelIndex));
            EventBus.Raise(new LevelGeneratedEvent(currentLevel));

            currentLevelIndex++;
        }

        /// <summary>Restarts the current level.</summary>
        public void RestartLevel()
        {
            if (currentLevelIndex > 0)
                currentLevelIndex--;
            LoadNextLevel();
        }

        /// <summary>Resets the game to the initial state.</summary>
        public void ResetGame()
        {
            currentLevelIndex = 0;
            puzzleController?.ResetPuzzle();
            moveCounter?.Initialize(0);
        }

        /// <summary>Gets the current level index.</summary>
        public int GetCurrentLevelIndex() => currentLevelIndex;
    }
}
