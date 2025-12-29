using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PuzzleTemplate.Runtime
{
    public abstract class ClickController : MonoBehaviour, IPointerClickHandler, ISceneEntity
    {
        public event Action<ISceneEntity> OnClick;

        public GameObject GameObject => gameObject;

        public Transform Transform => transform;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked();
            OnClick.SafeInvoke(this);
            EventBus.Raise(new ClickControllerEvent(this));
        }

        protected abstract void OnClicked();
    }
}