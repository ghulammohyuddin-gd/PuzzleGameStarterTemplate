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
        private int _level;

        public void SetPuzzle(IPuzzle puzzle)
        {
            _puzzle = (TilePuzzle)puzzle;
            _level = PrefsManager.LoadLevel() + 1;
        }

        private void OnEnable()
        {
            if (_puzzle == null) return;

            _puzzle.OnAdvance += UpdateMoves;

            EventBus.Subscribe<LoadNextLevelEvent>(UpdateLevelText);
        }

        private void OnDisable()
        {
            if (_puzzle == null) return;

            _puzzle.OnAdvance -= UpdateMoves;

            EventBus.Unsubscribe<LoadNextLevelEvent>(UpdateLevelText);
        }

        private void UpdateMoves() => _movesText.text = "Moves: " + _puzzle.MovesLeft;

        private void UpdateLevelText(LoadNextLevelEvent ev) => _levelNo.text = "Level: " + _level;
    }
}
