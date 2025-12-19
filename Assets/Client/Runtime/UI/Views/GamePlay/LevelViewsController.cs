using PuzzleTemplate.Runtime;
using PuzzleTemplate.Runtime.UI;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class LevelViewsController : ViewsController
    {
        [SerializeField] private string _winViewKey;
        [SerializeField] private string _loseViewKey;

        private IWinConditionChecker _checker;

        public void SetWinConditionChecker(IWinConditionChecker checker) => _checker = checker;

        protected override void Awake()
        {
            base.Awake();
            _checker.OnWin += OnLevelWin;
            _checker.OnLose += OnLevelLose;
        }

        private void OnDestroy()
        {
            _checker.OnWin -= OnLevelWin;
            _checker.OnLose -= OnLevelLose;
        }

        private void OnLevelWin() => SwitchView(_winViewKey);

        private void OnLevelLose() => SwitchView(_loseViewKey);
    }
}
