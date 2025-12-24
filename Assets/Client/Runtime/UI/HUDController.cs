using log4net.Core;
using PuzzleTemplate.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _movesText;
        [SerializeField] private TMP_Text _levelNo;
        [SerializeField] private Button _undoBtn;

        private void Start()
        {
            RegisterEvents();
            var status = LevelManager.Instance.WinConditionChecker is TilePuzzleWinWinCondition;
            _undoBtn.gameObject.SetActive(status);
            _movesText.gameObject.SetActive(!status);
        }

        private void OnDestroy() => UnregisterEvents();

        private void RegisterEvents()
        {
            EventBus.Subscribe<LevelStartedEvent>(HandleLevelStarted);
            var winConditionChecker = LevelManager.Instance.WinConditionChecker;
            winConditionChecker.OnAdvance += UpdateRemainingText;
            _undoBtn.onClick.AddListener(HandleUndo);
        }

        private void UnregisterEvents()
        {
            EventBus.Unsubscribe<LevelStartedEvent>(HandleLevelStarted);
            var levelManager = LevelManager.Instance;
            if (levelManager != null)
            {
                levelManager.WinConditionChecker.OnAdvance -= UpdateRemainingText;
            }
            _undoBtn.onClick.RemoveListener(HandleUndo);
        }

        private void HandleUndo()
        {
            if (LevelManager.Instance.WinConditionChecker is not TilePuzzleWinWinCondition winCondition) return;
            winCondition.Invoker.UndoOnce();
        }

        private void HandleLevelStarted(LevelStartedEvent @event)
        {
            UpdateLevelText();
            UpdateRemainingText();
        }

        private void UpdateRemainingText()
        {
            if (LevelManager.Instance.WinConditionChecker is TilePuzzleMovesWinCondition movesWinCondition)
            {
                _movesText.SetText($"Moves: {movesWinCondition.MovesLeft}");
                return;
            }

            if (LevelManager.Instance.WinConditionChecker is TilePuzzleTimeWinCondition timeWinCondition)
            {
                _movesText.SetText($"Time: {(int)timeWinCondition.SecondsLeft}");
                return;
            }
        }

        private void UpdateLevelText() => _levelNo.SetText($"Level: {PrefsManager.LoadLevel() + 1}");
    }
}
