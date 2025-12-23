using UnityEngine;

namespace PuzzleTemplate.Runtime.UI
{
    public class LevelViewsController : ViewsController
    {
        [SerializeField] protected string _winViewKey;
        [SerializeField] protected string _loseViewKey;
        [SerializeField] protected GameObject _winConditionCheckerRef;

        protected IWinConditionChecker _winConditionChecker;

        protected override void Awake()
        {
            base.Awake();
            _winConditionChecker = _winConditionCheckerRef.GetComponent<IWinConditionChecker>();
            _winConditionChecker.OnWin += OnLevelWin;
            _winConditionChecker.OnLose += OnLevelLose;
        }

        protected virtual void OnDestroy()
        {
            _winConditionChecker.OnWin -= OnLevelWin;
            _winConditionChecker.OnLose -= OnLevelLose;
        }

        protected virtual void OnLevelWin() => SwitchView(_winViewKey);

        protected virtual void OnLevelLose() => SwitchView(_loseViewKey);
    }
}
