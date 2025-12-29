using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PuzzleTemplate.Runtime
{
    /// <summary>
    /// For <see cref="IPointerClickHandler"> to trigger, the GameObject must have a Collider (for 3D)
    /// or an Image/Graphic (for UI), and your scene must have a PhysicsRaycaster or GraphicRaycaster
    /// on the Camera/Canvas.
    /// </summary>
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