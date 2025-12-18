using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime.UI
{
    public class PlayButtonHandler : MonoBehaviour
    {
        public void OnPlayClicked()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
