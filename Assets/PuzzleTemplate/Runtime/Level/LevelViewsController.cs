using log4net.Core;
using UnityEngine;

namespace PuzzleTemplate.Runtime.UI
{
    public class LevelViewsController : ViewsController
    {
        [SerializeField] protected string _winViewKey;
        [SerializeField] protected string _loseViewKey;

        protected override void Start()
        {
            base.Start();
            var winConditionChecker = LevelManager.Instance.WinConditionChecker;
            winConditionChecker.OnWin += OnLevelWin;
            winConditionChecker.OnLose += OnLevelLose;
        }

        protected virtual void OnDestroy()
        {
            var levelManager = LevelManager.Instance;
            if (levelManager != null)
            {
                var winConditionChecker = levelManager.WinConditionChecker;
                winConditionChecker.OnWin -= OnLevelWin;
                winConditionChecker.OnLose -= OnLevelLose;
            }
        }

        protected virtual void OnLevelWin() => SwitchView(_winViewKey);

        protected virtual void OnLevelLose() => SwitchView(_loseViewKey);
    }
}
