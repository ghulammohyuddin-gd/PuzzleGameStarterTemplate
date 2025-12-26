using System;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    [Serializable]
    public class GameSettingsData : IData
    {
        [SerializeField] protected string _id;
        [SerializeField] protected string _winConstraint;

        public string Id => _id;

        public WinConstraint WinConstraint => Enum.TryParse<WinConstraint>(_winConstraint, out var obj) ? obj : default;
    }
}
