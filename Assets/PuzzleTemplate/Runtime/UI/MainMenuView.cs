using System.Linq;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] protected string _defaultView;
        [SerializeField] protected UIComponent[] _uiComponents;

        protected readonly IStateMachine _stateMachine = new StateMachine();

        public void SwitchView(string key)
        {
            var uiComponent = _uiComponents.FirstOrDefault(c => c.Key == key);
            if (uiComponent != null)
            {
                _stateMachine.SwitchState(uiComponent);
            }
        }

        protected void Awake()
        {
            foreach (var uiComponent in _uiComponents)
            {
                _stateMachine.TryRegisterState(uiComponent);
            }
        }

        protected void Start()
        {
            SwitchView(_defaultView);
        }
    }
}