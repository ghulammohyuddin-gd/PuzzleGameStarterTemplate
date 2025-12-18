using UnityEngine;
using UnityEngine.UI;

namespace PuzzleGameStarterTemplate.UI
{
    public class NavigationPanelController : MonoBehaviour
    {
        [Header("Bottom Navigation Buttons")]
        [SerializeField] private Button homeButton;
        [SerializeField] private Button storeButton;
        [SerializeField] private Button leaderboardButton;
        [SerializeField] private Button mapButton;
        [SerializeField] private Button settingsButton;

        [Header("UI Manager Reference")]
        [SerializeField] private MainMenuUIManager uiManager;

        private void Awake()
        {
            // Assign button click listeners
            homeButton.onClick.AddListener(() => uiManager.ShowHome());
            storeButton.onClick.AddListener(() => uiManager.ShowStore());
            leaderboardButton.onClick.AddListener(() => uiManager.ShowLeaderboard());
            mapButton.onClick.AddListener(() => uiManager.ShowMap());
            settingsButton.onClick.AddListener(() => uiManager.ShowSettings());
        }
    }
}
