using PuzzleTemplate.Runtime;
using TMPro;
using UnityEngine;

namespace Client.Runtime.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _movesText;
        [SerializeField] private TMP_Text _levelNo;

        private void Start() => RegisterEvents();

        private void OnDestroy() => UnregisterEvents();

        private void RegisterEvents()
        {
            EventBus.Subscribe<LevelStartedEvent>(HandleLevelStarted);
            var winConditionChecker = LevelManager.Instance.WinConditionChecker;
            winConditionChecker.OnAdvance += UpdateRemainingText;
        }

        private void UnregisterEvents()
        {
            EventBus.Unsubscribe<LevelStartedEvent>(HandleLevelStarted);
            var winConditionChecker = LevelManager.Instance.WinConditionChecker;
            winConditionChecker.OnAdvance -= UpdateRemainingText;
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
