using System.Collections.Generic;

namespace PuzzleTemplate.Runtime
{
    internal sealed class LoadStrategy : IProcessStrategy
    {
        private readonly IDictionary<string, IData> _registry;

        public LoadStrategy(IDictionary<string, IData> registry) => _registry = registry;

        public void Process(IData data)
        {
            if (_registry.TryAdd(data.Id, data)) return;

            Statics.LogInfo($"Duplicate Id '{data.Id}' found, conflicts with existing data.", this);
        }
    }
}