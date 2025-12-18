using Client.Runtime;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        public GameObject winPanel;
        public GameObject losePanel;

        void OnEnable()
        {
            EventBus.Subscribe<LevelWinEvent>(ShowWin);
            EventBus.Subscribe<LevelLoseEvent>(ShowLose);
        }

        void OnDisable()
        {
            EventBus.Unsubscribe<LevelWinEvent>(ShowWin);
            EventBus.Unsubscribe<LevelLoseEvent>(ShowLose);
        }

        void ShowWin(LevelWinEvent ev)
        {
            if (winPanel != null)
                winPanel.SetActive(true);
        }

        void ShowLose(LevelLoseEvent ev)
        {
            if (losePanel != null)
                losePanel.SetActive(true);
        }
    }
}
