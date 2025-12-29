using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public interface ISceneEntity
    {
        GameObject GameObject { get; }

        Transform Transform { get; }
    }
}