using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class ViewSwitchHandler : MonoBehaviour
    {
        [SerializeField] private ViewsController _viewsController;
        [SerializeField] private string _winViewKey;
        [SerializeField] private string _loseViewKey;

        private void Awake()
        {
            EventBus.Subscribe<LevelWinEvent>(OnLevelWin);
            EventBus.Subscribe<LevelLoseEvent>(OnLevelLose);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe<LevelWinEvent>(OnLevelWin);
            EventBus.Unsubscribe<LevelLoseEvent>(OnLevelLose);
        }

        private void OnLevelWin(LevelWinEvent @event) => _viewsController.SwitchView(_winViewKey);

        private void OnLevelLose(LevelLoseEvent @event) => _viewsController.SwitchView(_loseViewKey);
    }
}
