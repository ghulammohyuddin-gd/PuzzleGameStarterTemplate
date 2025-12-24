using System.Runtime.CompilerServices;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public static class Statics
    {

        /// <summary>
        /// Logs a message with an optional context object.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void LogInfo(object msg, object ctx = null)
            => Debug.Log($"{(ctx == null ? string.Empty : $"[{ctx.GetType().Name}]")} - {msg}");
    }
}