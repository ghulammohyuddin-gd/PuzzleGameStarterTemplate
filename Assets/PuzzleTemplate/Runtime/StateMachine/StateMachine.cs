using System.Collections.Generic;

namespace PuzzleTemplate.Runtime
{
    public class StateMachine : IStateMachine
    {
        protected readonly HashSet<IState> _states = new();

        public IState CurrentState { get; protected set; }

        public bool TryRegisterState(IState state)
        {
            if (state == null) return false;

            return _states.Add(state);
        }

        public void SwitchState(IState newState)
        {
            if (newState == null) return;

            if (!_states.Contains(newState))
                throw new System.Exception(
                    $"State {newState.GetType().Name} not registered"
                );

            if (CurrentState == newState)
                return;

            CurrentState?.OnExit();
            CurrentState = newState;
            CurrentState.OnEnter();
        }

        public void Stop()
        {
            if (CurrentState == null) return;

            CurrentState.OnExit();
            CurrentState = null;
        }

        public void Clear()
        {
            Stop();
            _states.Clear();
        }
    }
}
