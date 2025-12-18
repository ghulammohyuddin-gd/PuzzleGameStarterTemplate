using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Runtime.UI
{
    public class PlayButtonHandler : MonoBehaviour
    {
        public void OnPlayClicked()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
