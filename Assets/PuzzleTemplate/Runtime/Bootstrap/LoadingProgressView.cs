using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PuzzleTemplate.Runtime
{
    public class LoadingProgressView : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] protected Slider _progressBar;
        [SerializeField] protected TextMeshProUGUI _progressText;

        protected virtual void Start() => RegisterEvents();

        protected virtual void OnDestroy() => UnRegisterEvents();

        protected virtual void RegisterEvents()
        {
            EventBus.Subscribe<LoadingStepExecutedEvent>(UpdateProgress);
            EventBus.Subscribe<LoadingCompletedEvent>(OnLoadingCompleted);
        }

        protected virtual void UnRegisterEvents()
        {
            EventBus.Unsubscribe<LoadingStepExecutedEvent>(UpdateProgress);
            EventBus.Unsubscribe<LoadingCompletedEvent>(OnLoadingCompleted);
        }

        protected virtual void UpdateProgress(LoadingStepExecutedEvent @event)
        {
            var value = @event.Progress;
            _progressBar.value = value;
            _progressText.text = $"{Mathf.RoundToInt(value * 100)}%";
        }

        protected virtual void OnLoadingCompleted(LoadingCompletedEvent @event) => gameObject.SetActive(false);
    }
}
