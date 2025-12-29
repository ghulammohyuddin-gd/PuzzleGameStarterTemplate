using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PuzzleTemplate.Runtime
{
    public abstract class DragController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, ISceneEntity
    {
        public event Action<ISceneEntity> OnBeginDragEvent;
        public event Action<ISceneEntity> OnEndDragEvent;

        public GameObject GameObject => gameObject;
        public Transform Transform => transform;

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnDragStarted(eventData);
            OnBeginDragEvent.SafeInvoke(this);
            EventBus.Raise(new DragControllerEvent(this, DragState.Started));
        }

        public void OnDrag(PointerEventData eventData) => OnDragging(eventData);

        public void OnEndDrag(PointerEventData eventData)
        {
            OnDragEnded(eventData);
            OnEndDragEvent.SafeInvoke(this);
            EventBus.Raise(new DragControllerEvent(this, DragState.Ended));
        }

        protected abstract void OnDragStarted(PointerEventData eventData);
        protected abstract void OnDragging(PointerEventData eventData);
        protected abstract void OnDragEnded(PointerEventData eventData);
    }
}