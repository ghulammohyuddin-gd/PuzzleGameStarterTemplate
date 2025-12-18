using PuzzleGameStarterTemplate.Core;
using PuzzleGameStarterTemplate.Generation;
using PuzzleGameStarterTemplate.Persistance;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PuzzleGameStarterTemplate.Controllers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        [Header("References (Scene Objects)")]
        public PuzzleController puzzleController;
        public MoveCounter moveCounter;
        public ProceduralLevelGenerator levelGenerator;

        private int currentLevelIndex = 0;
        private LevelData currentLevel;

        private void Awake()
        {
            // Singleton setup
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Listen for scene load
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        // Called whenever a new scene is loaded
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "GamePlay")
            {
                // Reassign scene-specific references
                if (puzzleController == null)
                    puzzleController = FindObjectOfType<PuzzleController>();
                if (moveCounter == null)
                    moveCounter = FindObjectOfType<MoveCounter>();
                if (levelGenerator == null)
                    levelGenerator = FindObjectOfType<ProceduralLevelGenerator>();

                // Initialize level if references are ready
                if (puzzleController != null && moveCounter != null && levelGenerator != null)
                    InitializeLevelManager();
                else
                    Debug.LogError("LevelManager: Scene references not found in Gameplay!");
            }
        }

        /// <summary>
        /// Explicit initialization for starting or restarting a session.
        /// Call this whenever entering Gameplay scene.
        /// </summary>
        /// <param name="startLevelIndex">Optional start level index, default -1 loads last saved</param>
        public void InitializeLevelManager(int startLevelIndex = -1)
        {
            currentLevelIndex = startLevelIndex >= 0 ? startLevelIndex : ProgressManager.LoadLevel();
            LoadNextLevel();
        }

        public void LoadNextLevel()
        {
            if (puzzleController == null || moveCounter == null || levelGenerator == null)
            {
                Debug.LogError("LevelManager: References not set!");
                return;
            }

            // Save progress
            ProgressManager.SaveLevel(currentLevelIndex);

            // Generate level data
            currentLevel = levelGenerator.GenerateLevel(currentLevelIndex);

            // Generate tiles
            puzzleController.GenerateGrid(currentLevel);

            // Initialize moves
            moveCounter.Initialize(puzzleController.TotalGreenTiles + 1);

            // Fire events
            GameEvents.OnLevelChanged?.Invoke(currentLevelIndex);
            GameEvents.OnLevelGenerated?.Invoke(currentLevel);

            currentLevelIndex++;
        }

        public void RestartLevel()
        {
            if (currentLevelIndex > 0)
                currentLevelIndex--;
            LoadNextLevel();
        }

        public void ResetGame()
        {
            currentLevelIndex = 0;
            puzzleController?.ResetController();
            moveCounter?.Initialize(0);
        }

        public int GetCurrentLevelIndex() => currentLevelIndex;
    }
}
