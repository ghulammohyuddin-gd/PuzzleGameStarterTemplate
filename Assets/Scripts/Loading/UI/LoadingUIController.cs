using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Template.Runtime.Core;

namespace Template.Runtime.Loading.UI
{
    public class LoadingUIController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Slider progressBar;
        [SerializeField] private TextMeshProUGUI progressText; // optional, can leave empty

        /// <summary>
        /// Updates the slider and text
        /// </summary>
        /// <param name="value">0 to 1</param>
        public void UpdateProgress(float value)
        {
            if (progressBar != null)
                progressBar.value = value;

            if (progressText != null)
                progressText.text = $"{Mathf.RoundToInt(value * 100)}%";
        }

        /// <summary>
        /// Called when all commands are executed
        /// </summary>
        public void OnLoadingComplete()
        {
            // Example: Load MainMenu
            GameFlowManager.Instance.GoToMainMenu();
        }
    }
}
