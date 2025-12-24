using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    /// <summary>
    /// A generic singleton base class for MonoBehaviours.
    /// </summary>
    /// <typeparam name="T">The type of the singleton.</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected bool _dontDestroyOnLoad = true;

        private static T _instance;
        private static readonly object _lock = new object();
        private static bool _applicationIsQuitting = false;

        public static T Instance
        {
            get
            {
                // Prevent creating new instances while the application is quitting
                if (_applicationIsQuitting)
                {
                    Debug.LogWarning($"[Singleton] Instance of {typeof(T)} already destroyed. Returning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        // 1. Try to find the instance in the scene
                        _instance = (T)FindObjectOfType(typeof(T));

                        // 2. If it doesn't exist, create a new GameObject to host it
                        if (_instance == null)
                        {
                            GameObject singletonObject = new GameObject();
                            _instance = singletonObject.AddComponent<T>();
                            singletonObject.name = $"{typeof(T)} (Singleton)";
                        }
                    }

                    return _instance;
                }
            }
        }

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                SetDontDestroyOnLoad();
            }
            else if (_instance != this)
            {
                Debug.LogWarning($"[Singleton] Instance of {typeof(T)} already exists. Destroying duplicate on {gameObject.name}");
                Destroy(gameObject);
            }
        }

        protected virtual void OnApplicationQuit()
        {
            _applicationIsQuitting = true;
        }

        protected virtual void OnDestroy()
        {
            // If this specific instance is destroyed, ensure we reset the reference
            if (_instance == this)
            {
                _instance = null;
            }
        }

        protected virtual void SetDontDestroyOnLoad()
        {
            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}