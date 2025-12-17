using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonHandler : MonoBehaviour
{
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
