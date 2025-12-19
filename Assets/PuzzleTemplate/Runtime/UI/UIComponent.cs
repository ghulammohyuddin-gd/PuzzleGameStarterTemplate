using UnityEngine;

namespace PuzzleTemplate.Runtime.UI
{
    public abstract class UIComponent : MonoBehaviour, IUIComponent
    {
        [SerializeField] protected string _key;

        public string Key => _key;

        public virtual void OnEnter()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnExit()
        {
            gameObject.SetActive(false);
        }
    }
}