using PuzzleTemplate.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _remainingTmp;
        [SerializeField] private TMP_Text _levelNo;
        [SerializeField] private Button _undoBtn;

        private void Start() => RegisterEvents();

        private void OnDestroy() => UnregisterEvents();

        private void RegisterEvents()
        {
            EventBus.Subscribe<LevelStartedEvent>(HandleLevelStarted);
            var winConditionChecker = Locator.Get<IWinConditionChecker>();
            winConditionChecker.OnAdvance += UpdateRemainingText;
            _undoBtn.onClick.AddListener(HandleUndo);
        }

        private void UnregisterEvents()
        {
            EventBus.Unsubscribe<LevelStartedEvent>(HandleLevelStarted);
            var winConditionChecker = Locator.Get<IWinConditionChecker>();
            winConditionChecker.OnAdvance -= UpdateRemainingText;
            _undoBtn.onClick.RemoveListener(HandleUndo);
        }

        private void HandleUndo()
        {
            if (Locator.Get<IWinConditionChecker>() is not TilePuzzleWinWinCondition winCondition) return;
            winCondition.UndoMove();
            _undoBtn.interactable = winCondition.UndosLeft > 0;
        }

        private void HandleLevelStarted(LevelStartedEvent @event)
        {
            UpdateUndoUI();
            UpdateLevelText();
            UpdateRemainingText();
        }

        private void UpdateUndoUI()
        {
            if (Locator.Get<IWinConditionChecker>() is TilePuzzleWinWinCondition winCondition)
            {
                _undoBtn.gameObject.SetActive(true);
                _undoBtn.interactable = winCondition.UndosLeft > 0;
            }
            else
            {
                _undoBtn.gameObject.SetActive(false);
            }
        }

        private void UpdateRemainingText()
        {
            var checker = Locator.Get<IWinConditionChecker>();

            _remainingTmp.text = checker switch
            {
                TilePuzzleMovesWinCondition moves => $"Moves: {moves.MovesLeft}",
                TilePuzzleTimeWinCondition time => $"Time: {(int)time.SecondsLeft}",
                TilePuzzleWinWinCondition win => $"Undos: {win.UndosLeft}",
                _ => string.Empty
            };
        }

        private void UpdateLevelText() => _levelNo.SetText($"Level: {PrefsManager.LoadLevel() + 1}");
    }
}
