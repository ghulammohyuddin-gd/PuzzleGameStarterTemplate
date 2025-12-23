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

        public void Initialise(IPuzzle puzzle)
        {
            _puzzle = (TilePuzzle)puzzle;
            _puzzle.OnAdvance += UpdateMoves;
            UpdateLevelText();
            UpdateMoves();
        }

        public void Reset()
        {
            _puzzle.OnAdvance -= UpdateMoves;
        }

        private void UpdateMoves() => _movesText.SetText($"Moves: {_puzzle.MovesLeft}");

        private void UpdateLevelText() => _levelNo.SetText($"Level: {PrefsManager.LoadLevel() + 1}");
    }
}
