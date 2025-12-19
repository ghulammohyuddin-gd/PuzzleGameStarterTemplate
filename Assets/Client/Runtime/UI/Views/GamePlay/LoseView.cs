using UnityEngine.UI;
using PuzzleTemplate.Runtime.UI;
using UnityEngine;
using PuzzleTemplate.Runtime;

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
            EventBus.Raise(new RestartLevelEvent());
        }

        private void OnHomeClicked()
        {
            gameObject.SetActive(false);
            Statics.GoToMainMenu();
        }
    }
}
