using PuzzleTemplate.Runtime.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.UI
{
    public sealed class HomeView : UIComponent
    {
        [SerializeField] private Button playButton;

        public override void OnEnter()
        {
            base.OnEnter();
            playButton.onClick.AddListener(OnPlayClicked);
            Debug.Log("HomeView: OnEnter");
        }

        public override void OnExit()
        {
            base.OnExit();
            playButton.onClick.RemoveListener(OnPlayClicked);
            Debug.Log("HomeView: OnExit");
        }

        private void OnPlayClicked()
        {
            GameFlowManager.Instance.StartGameplay();
        }
    }
}
