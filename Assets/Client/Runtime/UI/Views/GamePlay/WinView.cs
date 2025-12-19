using UnityEngine;
using UnityEngine.UI;
using Client.Runtime.Controllers;
using PuzzleTemplate.Runtime.UI;

namespace Client.Runtime.UI
{
    public sealed class WinView : UIComponent
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _homeButton;

        public override void OnEnter()
        {
            base.OnEnter();
            _nextLevelButton.onClick.AddListener(OnNextButtonClicked);
            _homeButton.onClick.AddListener(OnHomeClicked);
        }

        public override void OnExit()
        {
            base.OnExit();
            _nextLevelButton.onClick.RemoveListener(OnNextButtonClicked);
            _homeButton.onClick.RemoveListener(OnHomeClicked);
        }

        private void OnNextButtonClicked()
        {
            gameObject.SetActive(false);
            LevelManager.Instance.LoadNextLevel();
        }

        private void OnHomeClicked()
        {
            gameObject.SetActive(false);
            GameFlowManager.Instance.GoToMainMenu();
        }
    }
}
