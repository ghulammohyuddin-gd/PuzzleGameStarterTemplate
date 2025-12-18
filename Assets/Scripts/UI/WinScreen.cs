using UnityEngine;
using UnityEngine.UI;
using PuzzleGameStarterTemplate.Controllers;
using PuzzleGameStarterTemplate.Core;

namespace PuzzleGameStarterTemplate.UI
{
    public class WinScreen : MonoBehaviour
    {
        [Header("Buttons")]
        public Button nextLevelButton;
        public Button homeButton; // NEW

        private LevelManager levelManager;

        void Awake()
        {
            // Cache LevelManager reference
            levelManager = LevelManager.Instance;
        }

        void OnEnable()
        {
            // Add listeners
            if (nextLevelButton != null)
                nextLevelButton.onClick.AddListener(OnNextLevelClicked);

            if (homeButton != null)
                homeButton.onClick.AddListener(OnHomeClicked);
        }

        void OnDisable()
        {
            // Remove listeners
            if (nextLevelButton != null)
                nextLevelButton.onClick.RemoveListener(OnNextLevelClicked);

            if (homeButton != null)
                homeButton.onClick.RemoveListener(OnHomeClicked);
        }

        private void OnNextLevelClicked()
        {
            gameObject.SetActive(false);
            if (levelManager != null)
                levelManager.LoadNextLevel();
        }

        private void OnHomeClicked()
        {
            gameObject.SetActive(false);
            GameFlowManager.Instance?.GoToMainMenu();

        }
    }
}
