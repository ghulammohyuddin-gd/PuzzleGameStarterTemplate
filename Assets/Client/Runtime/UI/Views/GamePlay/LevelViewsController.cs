using PuzzleTemplate.Runtime;
using PuzzleTemplate.Runtime.UI;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class LevelViewsController : ViewsController
    {
        [SerializeField] private string _winViewKey;
        [SerializeField] private string _loseViewKey;

        protected override void Awake()
        {
            base.Awake();
            EventBus.Subscribe<LevelWinEvent>(OnLevelWin);
            EventBus.Subscribe<LevelLoseEvent>(OnLevelLose);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<LevelWinEvent>(OnLevelWin);
            EventBus.Unsubscribe<LevelLoseEvent>(OnLevelLose);
        }

        private void OnLevelWin(LevelWinEvent @event) => SwitchView(_winViewKey);

        private void OnLevelLose(LevelLoseEvent @event) => SwitchView(_loseViewKey);
    }
}
