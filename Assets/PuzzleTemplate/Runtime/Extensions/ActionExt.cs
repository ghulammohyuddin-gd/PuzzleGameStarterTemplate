using System;

namespace PuzzleTemplate.Runtime
{
    public static class ActionExt
    {
        public static void SafeInvoke(this Action source) => source?.Invoke();

        public static void SafeInvoke<T>(this Action<T> source, T value) => source?.Invoke(value);
    }
}