using PuzzleTemplate.Runtime;
using TMPro;
using UnityEngine;

namespace Client.Runtime.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _movesText;
        [SerializeField] private TMP_Text _levelNo;

        private TilePuzzle _puzzle;

        public void Reset()
        {
            _puzzle.OnAdvance -= UpdateMoves;
        }

        private void Awake() => RegisterEvents();

        private void OnDestroy() => UnregisterEvents();

        private void RegisterEvents() => EventBus.Subscribe<LevelStartedEvent>(HandleLevelStarted);

        private void UnregisterEvents()
        {
            EventBus.Unsubscribe<LevelStartedEvent>(HandleLevelStarted);
            if (_puzzle != null)
            {
                _puzzle.OnAdvance -= UpdateMoves;
            }
        }

        private void HandleLevelStarted(LevelStartedEvent @event)
        {
            if (_puzzle != null)
            {
                _puzzle.OnAdvance -= UpdateMoves;
            }

            _puzzle = (TilePuzzle)@event.Puzzle;
            _puzzle.OnAdvance += UpdateMoves;
            UpdateLevelText();
            UpdateMoves();
        }

        private void UpdateMoves() => _movesText.SetText($"Moves: {_puzzle.MovesLeft}");

        private void UpdateLevelText() => _levelNo.SetText($"Level: {PrefsManager.LoadLevel() + 1}");
    }
}
