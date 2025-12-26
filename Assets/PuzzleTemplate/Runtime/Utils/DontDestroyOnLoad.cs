using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(gameObject);
    }
}