using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzleTimeWinCondition : MonoBehaviour, IWinConditionChecker
    {
        public event Action OnWin;
        public event Action OnLose;
        public event Action OnAdvance;

        private TilePuzzle _puzzle;
        private bool _isActive;
        private float _oneSecondTimer;

        public float SecondsLeft { get; private set; }

        public void Initialise(IPuzzle puzzle)
        {
            _puzzle = (TilePuzzle)puzzle;
            SecondsLeft = _puzzle.Seconds;
            _isActive = true;
        }

        public void Reset()
        {
            _isActive = false;
            SecondsLeft = 0;
            _puzzle = null;
        }

        private void Update()
        {
            if (!_isActive || _puzzle == null) return;

            if (IsWinConditionMet())
            {
                _isActive = false;
                OnWin.SafeInvoke();
                return;
            }

            SecondsLeft -= Time.deltaTime;
            _oneSecondTimer += Time.deltaTime;

            if (_oneSecondTimer >= 1f)
            {
                _oneSecondTimer -= 1f;
                OnAdvance.SafeInvoke();
            }

            if (IsLoseConditionMet())
            {
                _isActive = false;
                OnLose.SafeInvoke();
            }
        }

        private bool IsWinConditionMet() => _puzzle.CurrentGreenTiles <= 0 && SecondsLeft > 0;

        private bool IsLoseConditionMet() => SecondsLeft <= 0;
    }
}