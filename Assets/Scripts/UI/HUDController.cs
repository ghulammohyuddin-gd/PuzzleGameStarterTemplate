using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI movesText;
    public TextMeshProUGUI levelNo;

    void OnEnable()
    {
        GameEvents.OnMovesChanged += UpdateMoves;
        GameEvents.OnLevelChanged += UpdateLevelText;
    }

    void OnDisable()
    {
        GameEvents.OnMovesChanged -= UpdateMoves;
        GameEvents.OnLevelChanged -= UpdateLevelText;
    }

    void UpdateMoves(int moves)
    {
        if (movesText != null)
            movesText.text = "Moves: " + moves;
    }

    void UpdateLevelText(int level)
    {
        if (levelNo != null)
            levelNo.text = "Level: " + (level + 1); // +1 to show 1-based
    }
}
