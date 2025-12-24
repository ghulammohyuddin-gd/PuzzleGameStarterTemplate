using System.Collections.Generic;

namespace PuzzleTemplate.Runtime
{
    internal interface IDataLoader
    {
        IEnumerable<IData> Load(string json);
    }
}