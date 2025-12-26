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
            var winConditionChecker = Locator.Get<IWinConditionChecker>();
            winConditionChecker.OnWin += OnLevelWin;
            winConditionChecker.OnLose += OnLevelLose;
        }

        protected virtual void OnDestroy()
        {

            var winConditionChecker = Locator.Get<IWinConditionChecker>();
            winConditionChecker.OnWin -= OnLevelWin;
            winConditionChecker.OnLose -= OnLevelLose;
        }

        protected virtual void OnLevelWin() => SwitchView(_winViewKey);

        protected virtual void OnLevelLose() => SwitchView(_loseViewKey);
    }
}
