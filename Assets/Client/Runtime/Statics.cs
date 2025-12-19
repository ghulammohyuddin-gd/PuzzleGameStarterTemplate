using UnityEngine.SceneManagement;

namespace Client.Runtime
{
    public static class Statics
    {
        public static void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public static void GoToGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}