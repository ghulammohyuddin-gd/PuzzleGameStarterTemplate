using System;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    [Serializable]
    public class GameSettingsData : IData
    {
        [SerializeField] protected string _id;
        [SerializeField] protected WinConstraint _winConstraint;

        public string Id => _id;
        public WinConstraint WinConstraint => _winConstraint;
    }
}
