using System;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    [Serializable]
    public class WinCondition
    {
        [SerializeField] private WinConstraint _constraint;
        [SerializeField] private GameObject _conditionRef;

        public WinConstraint Constraint => _constraint;
        public IWinConditionChecker ConditionChecker => _conditionRef.GetComponent<IWinConditionChecker>();
    }
}