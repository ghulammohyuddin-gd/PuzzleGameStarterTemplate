using System;
using System.Collections.Generic;

namespace PuzzleTemplate.Runtime
{
    public class StateMachine : IStateMachine
    {
        protected readonly IDictionary<Type, IState> _states = new Dictionary<Type, IState>();

        public IState CurrentState { get; protected set; }

        public bool TryRegisterState<TState>(TState state) where TState : IState
        {
            return _states.TryAdd(typeof(TState), state);
        }

        public void SwitchState<TState>(TState state) where TState : IState
        {
            var type = typeof(TState);

            if (!_states.TryGetValue(type, out var newState))
                throw new Exception($"State {type.Name} not registered");

            if (CurrentState == newState) return;

            CurrentState?.OnExit();

            CurrentState = newState;
            CurrentState.OnEnter();
        }

        public void Reset()
        {
            CurrentState?.OnExit();
            CurrentState = null;
            _states.Clear();
        }
    }
}