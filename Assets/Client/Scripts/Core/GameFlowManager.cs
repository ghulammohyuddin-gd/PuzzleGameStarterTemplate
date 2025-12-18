using Template.Runtime.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;
using Template.Runtime.Core;
using PuzzleTemplate.Runtime;
using System; // Added for Singleton<T> - ensuring it's there

namespace Template.Runtime.Core
{
    public class GameFlowManager : Singleton<GameFlowManager> // Changed inheritance
    {
        // Removed: public static GameFlowManager Instance { get; private set; }

        protected override void Awake() // Changed to protected override
        {
            base.Awake(); // Call base Singleton Awake logic

            // Existing custom logic
            // Subscribe to scene loaded to initialize LevelManager
            SceneManager.sceneLoaded += OnSceneLoaded;
            EventBus.Subscribe<LoadingCompletedEvent>(HandleLoadingCompleted);
        }

        private void HandleLoadingCompleted(LoadingCompletedEvent @event)
        {
            GoToMainMenu();
        }


        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "GamePlay")
            {
                // Initialize LevelManager explicitly for this scene
                LevelManager.Instance?.InitializeLevelManager();
            }
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void StartGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
