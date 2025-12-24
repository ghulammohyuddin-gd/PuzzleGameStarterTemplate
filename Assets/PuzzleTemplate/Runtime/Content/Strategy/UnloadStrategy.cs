using System.Collections.Generic;

namespace PuzzleTemplate.Runtime
{
    internal sealed class UnloadStrategy : IProcessStrategy
    {
        private readonly IDictionary<string, IData> _registry;

        public UnloadStrategy(IDictionary<string, IData> registry) => _registry = registry;

        public void Process(IData data)
        {
            if (_registry.Remove(data.Id)) return;

            Statics.LogInfo($"Attempted to remove unregistered Id '{data.Id}', skipping.", this);
        }
    }
}