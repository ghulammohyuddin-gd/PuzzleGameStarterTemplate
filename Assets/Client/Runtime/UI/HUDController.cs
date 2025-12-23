using PuzzleTemplate.Runtime;
using TMPro;
using UnityEngine;

namespace Client.Runtime.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _movesText;
        [SerializeField] private TMP_Text _levelNo;
        [SerializeField] private GameObject _winConditionCheckerRef;

        private IWinConditionChecker _winConditionChecker;

        private void Awake()
        {
            _winConditionChecker = _winConditionCheckerRef.GetComponent<IWinConditionChecker>();
            RegisterEvents();
        }

        private void OnDestroy() => UnregisterEvents();

        private void RegisterEvents()
        {
            EventBus.Subscribe<LevelStartedEvent>(HandleLevelStarted);
            _winConditionChecker.OnAdvance += UpdateRemainingText;
        }

        private void UnregisterEvents()
        {
            EventBus.Unsubscribe<LevelStartedEvent>(HandleLevelStarted);
            _winConditionChecker.OnAdvance -= UpdateRemainingText;
        }

        private void HandleLevelStarted(LevelStartedEvent @event)
        {
            UpdateLevelText();
            UpdateRemainingText();
        }

        private void UpdateRemainingText()
        {
            if (_winConditionChecker is TilePuzzleMovesWinCondition movesWinCondition)
            {
                _movesText.SetText($"Moves: {movesWinCondition.MovesLeft}");
                return;
            }

            if (_winConditionChecker is TilePuzzleTimeWinCondition timeWinCondition)
            {
                _movesText.SetText($"Time: {(int)timeWinCondition.SecondsLeft}");
                return;
            }
        }

        private void UpdateLevelText() => _levelNo.SetText($"Level: {PrefsManager.LoadLevel() + 1}");
    }
}
