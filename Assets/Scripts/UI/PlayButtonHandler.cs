using UnityEngine;
using UnityEngine.SceneManagement;

namespace PuzzleGameStarterTemplate.UI
{
    public class PlayButtonHandler : MonoBehaviour
    {
        public void OnPlayClicked()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
