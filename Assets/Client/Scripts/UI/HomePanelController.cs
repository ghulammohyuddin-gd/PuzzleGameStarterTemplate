using Template.Runtime.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Template.Runtime.UI
{
    public class HomePanelController : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        void OnEnable()
        {
            playButton.onClick.AddListener(OnPlayClicked);
        }

        void OnDisable()
        {
            playButton.onClick.RemoveListener(OnPlayClicked);
        }

        void OnPlayClicked()
        {
            // Reset game and load Gameplay scene
            GameFlowManager.Instance?.StartGameplay();
        }
    }
}
