using Template.Runtime.Core;
using UnityEngine;

namespace Template.Runtime.UI
{
    public class UIManager : MonoBehaviour
    {
        public GameObject winPanel;
        public GameObject losePanel;

        void OnEnable()
        {
            GameEvents.OnLevelWin += ShowWin;
            GameEvents.OnLevelLose += ShowLose;
        }

        void OnDisable()
        {
            GameEvents.OnLevelWin -= ShowWin;
            GameEvents.OnLevelLose -= ShowLose;
        }

        void ShowWin()
        {
            if (winPanel != null)
                winPanel.SetActive(true);
        }

        void ShowLose()
        {
            if (losePanel != null)
                losePanel.SetActive(true);
        }
    }
}
