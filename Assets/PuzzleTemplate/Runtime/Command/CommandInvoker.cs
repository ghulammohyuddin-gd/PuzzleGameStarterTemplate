using System.Collections.Generic;

namespace PuzzleTemplate.Runtime
{
    public sealed class CommandInvoker
    {
        private readonly Stack<ICommand> _undo = new();
        private readonly Stack<ICommand> _redo = new();

        public bool CanUndo => _undo.Count > 0;
        public bool CanRedo => _redo.Count > 0;

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undo.Push(command);
            _redo.Clear();
        }

        public void UndoOnce()
        {
            if (_undo.TryPop(out var command))
            {
                command.Undo();
                _redo.Push(command);
            }
        }

        public void RedoOnce()
        {
            if (_redo.TryPop(out var command))
            {
                command.Execute();
                _undo.Push(command);
            }
        }

        public void Clear()
        {
            _undo.Clear();
            _redo.Clear();
        }
    }
}