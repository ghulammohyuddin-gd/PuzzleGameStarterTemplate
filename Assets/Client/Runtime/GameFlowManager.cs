using PuzzleTemplate.Runtime;
using Client.Runtime.Controllers;
using UnityEngine.SceneManagement;

namespace Client.Runtime
{
    public class GameFlowManager : Singleton<GameFlowManager>
    {
        protected override void Awake()
        {
            base.Awake();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "GamePlay")
            {
                LevelManager.Instance.InitializeLevelManager();
            }
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void StartGameplay()
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
