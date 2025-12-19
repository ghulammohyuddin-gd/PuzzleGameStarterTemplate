using System.Linq;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public class ViewsController : MonoBehaviour
    {
        [SerializeField] protected string _defaultView;
        [SerializeField] protected UIComponent[] _views;

        protected readonly IStateMachine _stateMachine = new StateMachine();

        public virtual void SwitchView(string key)
        {
            var view = _views.FirstOrDefault(c => c.Key == key);
            if (view != null)
            {
                _stateMachine.SwitchState(view);
            }
        }

        protected virtual void Awake()
        {
            foreach (var uiComponent in _views)
            {
                _stateMachine.TryRegisterState(uiComponent);
            }
        }

        protected virtual void Start()
        {
            SwitchView(_defaultView);
        }
    }
}