using UnityEngine.UI;
using Client.Runtime.Controllers;
using PuzzleTemplate.Runtime.UI;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class LoseView : UIComponent
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;

        public override void OnEnter()
        {
            base.OnEnter();
            _restartButton.onClick.AddListener(OnRestartClicked);
            _homeButton.onClick.AddListener(OnHomeClicked);
        }

        public override void OnExit()
        {
            base.OnExit();
            _restartButton.onClick.RemoveListener(OnRestartClicked);
            _homeButton.onClick.RemoveListener(OnHomeClicked);
        }

        private void OnRestartClicked()
        {
            gameObject.SetActive(false);
            LevelManager.Instance.RestartLevel();
        }

        private void OnHomeClicked()
        {
            gameObject.SetActive(false);
            Statics.GoToMainMenu();
        }
    }
}
