using System.Collections;

namespace Template.Runtime.Loading.Core
{
    public interface ILoadingCommand
    {
        IEnumerator Execute();
    }
}
