using UnityEngine;

/// <summary>
/// Handles saving and loading player progress (current level, etc.)
/// </summary>
public static class ProgressManager
{
    private const string LEVEL_KEY = "CurrentLevel";

    /// <summary>
    /// Save the current level index
    /// </summary>
    /// <param name="levelIndex"></param>
    public static void SaveLevel(int levelIndex)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, levelIndex);
        PlayerPrefs.Save();
        Debug.Log($"Progress saved: Level {levelIndex + 1}");
    }

    /// <summary>
    /// Load the last saved level index
    /// </summary>
    /// <returns>Level index (0-based)</returns>
    public static int LoadLevel()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY, 0); // default to first level
    }

    /// <summary>
    /// Reset all saved progress
    /// </summary>
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteKey(LEVEL_KEY);
        Debug.Log("Progress reset");
    }
}
