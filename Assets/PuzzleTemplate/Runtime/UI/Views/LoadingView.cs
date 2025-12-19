using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PuzzleTemplate.Runtime.UI
{
    public class LoadingView : UIComponent
    {
        [Header("UI Elements")]
        [SerializeField] protected Slider _progressBar;
        [SerializeField] protected TextMeshProUGUI _progressText;

        protected virtual void Start() => RegisterEvents();

        protected virtual void OnDestroy() => UnRegisterEvents();

        protected virtual void RegisterEvents()
        {
            EventBus.Subscribe<LoadingStepExecutedEvent>(UpdateProgress);
        }

        protected virtual void UnRegisterEvents()
        {
            EventBus.Unsubscribe<LoadingStepExecutedEvent>(UpdateProgress);
        }

        protected virtual void UpdateProgress(LoadingStepExecutedEvent @event)
        {
            var value = @event.Progress;
            _progressBar.value = value;
            _progressText.text = $"{Mathf.RoundToInt(value * 100)}%";
        }
    }
}
