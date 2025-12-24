using System;
using System.Collections.Generic;

namespace PuzzleTemplate.Runtime
{
    /// <summary>
    /// Simplest implementation.
    /// </summary>
    public static class Locator
    {
        private static readonly Dictionary<Type, object> _lookup = new();

        public static void Register<T>(T instance)
        {
            var type = typeof(T);
            if (!_lookup.TryAdd(type, instance))
            {
                _lookup[type] = instance;
            }
        }

        public static T Get<T>()
        {
            var type = typeof(T);
            if (_lookup.TryGetValue(type, out var service))
            {
                return (T)service;
            }

            throw new Exception($"Service of type {type} not registered.");
        }

        public static void Unregister<T>() => _lookup.Remove(typeof(T));
    }
}