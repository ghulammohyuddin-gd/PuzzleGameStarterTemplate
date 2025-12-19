using Client.Runtime;
using PuzzleTemplate.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Client.Runtime.UI
{
    public class HUDController : MonoBehaviour
    {
        public TextMeshProUGUI movesText;
        public TextMeshProUGUI levelNo;

        void OnEnable()
        {
            EventBus.Subscribe<MovesChangedEvent>(UpdateMoves);
            EventBus.Subscribe<LevelChangedEvent>(UpdateLevelText);
        }

        void OnDisable()
        {
            EventBus.Unsubscribe<MovesChangedEvent>(UpdateMoves);
            EventBus.Unsubscribe<LevelChangedEvent>(UpdateLevelText);
        }

        void UpdateMoves(MovesChangedEvent ev)
        {
            if (movesText != null)
                movesText.text = "Moves: " + ev.MovesLeft;
        }

        void UpdateLevelText(LevelChangedEvent ev)
        {
            if (levelNo != null)
                levelNo.text = "Level: " + (ev.CurrentLevelIdx + 1); // +1 to show 1-based
        }
    }
}
