using UnityEditor;
using UnityEngine;

namespace Client.Runtime
{
    public static class PrefsManager
    {
        private const string LEVEL_KEY = "CurrentLevel";

        public static void SaveLevel(int levelIndex)
        {
            PlayerPrefs.SetInt(LEVEL_KEY, levelIndex);
            PlayerPrefs.Save();
            Debug.Log($"Progress saved: Level {levelIndex + 1}");
        }

        public static int LoadLevel()
        {
            return PlayerPrefs.GetInt(LEVEL_KEY, 0); // default to first level
        }

        [MenuItem("Debug/Reset Progress")]
        public static void ResetProgress()
        {
            PlayerPrefs.DeleteKey(LEVEL_KEY);
            Debug.Log("Progress reset");
        }
    }
}
