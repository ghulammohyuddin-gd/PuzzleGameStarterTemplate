using System;
using Template.Runtime.Generation;
using UnityEngine;

namespace Template.Runtime.Core
{
    public static class GameEvents
    {
        public static Action OnLevelWin;
        public static Action OnLevelLose;
        public static Action<int> OnMovesChanged;
        public static Action<int> OnLevelChanged;       // Level number update for HUD
        public static Action<LevelData> OnLevelGenerated; // Fires when a new level is generated
    }
}
