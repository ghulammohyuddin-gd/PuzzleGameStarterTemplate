using UnityEngine;

namespace Template.Runtime.UI
{
    public class MainMenuUIManager : MonoBehaviour
    {
        [Header("Panels")]
        [SerializeField] private GameObject homePanel;
        [SerializeField] private GameObject storePanel;
        [SerializeField] private GameObject leaderboardPanel;
        [SerializeField] private GameObject mapPanel;
        [SerializeField] private GameObject settingsPanel;

        private void Start()
        {
            ShowHome();
        }

        public void ShowHome() => ShowPanel(homePanel);
        public void ShowStore() => ShowPanel(storePanel);
        public void ShowLeaderboard() => ShowPanel(leaderboardPanel);
        public void ShowMap() => ShowPanel(mapPanel);
        public void ShowSettings() => ShowPanel(settingsPanel);

        private void ShowPanel(GameObject panel)
        {
            homePanel.SetActive(false);
            storePanel.SetActive(false);
            leaderboardPanel.SetActive(false);
            mapPanel.SetActive(false);
            settingsPanel.SetActive(false);

            panel.SetActive(true);
        }
    }
}
