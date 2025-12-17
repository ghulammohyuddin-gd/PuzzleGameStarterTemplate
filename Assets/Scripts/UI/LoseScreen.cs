using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    [Header("Buttons")]
    public Button restartButton;
    public Button homeButton; // NEW

    private LevelManager levelManager;

    void Awake()
    {
        // Cache LevelManager reference
        levelManager = LevelManager.Instance;
    }

    void OnEnable()
    {
        // Add listeners
        if (restartButton != null)
            restartButton.onClick.AddListener(OnRestartClicked);

        if (homeButton != null)
            homeButton.onClick.AddListener(OnHomeClicked);
    }

    void OnDisable()
    {
        // Remove listeners
        if (restartButton != null)
            restartButton.onClick.RemoveListener(OnRestartClicked);

        if (homeButton != null)
            homeButton.onClick.RemoveListener(OnHomeClicked);
    }

    private void OnRestartClicked()
    {
        gameObject.SetActive(false);
        if (levelManager != null)
            levelManager.RestartLevel();
    }

    private void OnHomeClicked()
    {
        gameObject.SetActive(false);
        // Reset gameplay state
        GameFlowManager.Instance?.GoToMainMenu();
    }
}
