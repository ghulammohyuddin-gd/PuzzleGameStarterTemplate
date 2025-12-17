using System.Collections;

public interface ILoadingCommand
{
    IEnumerator Execute();
}
