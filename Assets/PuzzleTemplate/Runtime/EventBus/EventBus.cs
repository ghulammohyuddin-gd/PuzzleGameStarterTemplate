using System;
using System.Collections.Generic;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public static class EventBus
    {
        private static readonly IDictionary<Type, List<IListener>> _subscriptions = new Dictionary<Type, List<IListener>>();

        public static void Reset()
        {
            foreach (var kvp in _subscriptions)
            {
                kvp.Value.Clear();
            }

            _subscriptions.Clear();
        }

        public static void Subscribe<TEvent>(Action<TEvent> action)
            where TEvent : struct, IEvent
        {
            var eventType = typeof(TEvent);
            var listener = new Listener<TEvent>(action);

            if (_subscriptions.TryGetValue(eventType, out var listeners))
            {
                listeners.Add(listener);
                return;
            }

            _subscriptions.Add(eventType, new List<IListener> { listener });
        }

        public static void Unsubscribe<TEvent>(Action<TEvent> action)
            where TEvent : struct, IEvent
        {
            if (!_subscriptions.TryGetValue(typeof(TEvent), out var listeners)) return;

            for (var i = 0; i < listeners.Count; i++)
            {
                if (listeners[i] is Listener<TEvent> typed && typed.Action == action)
                {
                    listeners.RemoveAt(i);
                    break;
                }
            }
        }

        public static void Raise<TEvent>(TEvent @event)
            where TEvent : struct, IEvent
        {
            if (!_subscriptions.TryGetValue(typeof(TEvent), out var listeners)) return;

            foreach (var listener in listeners)
            {
                if (listener is Listener<TEvent> typed)
                {
                    typed.Action(@event);
                }
            }
        }
    }
}
