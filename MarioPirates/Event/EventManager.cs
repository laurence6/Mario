using System.Collections.Generic;

namespace MarioPirates.Event
{
    internal sealed class EventManager
    {
        public delegate void OnEvent(IEvent eventData);

        private Dictionary<EventEnum, List<OnEvent>> subscribers = new Dictionary<EventEnum, List<OnEvent>>();
        private Queue<IEvent> queue = new Queue<IEvent>();

        public static EventManager Instance { get; } = new EventManager();

        private EventManager() { }

        public void Subscribe(EventEnum e, OnEvent f)
        {
            if (!subscribers.ContainsKey(e))
                subscribers[e] = new List<OnEvent>();
            if (!subscribers[e].Contains(f))
                subscribers[e].Add(f);
        }

        public void Unsubscribe(EventEnum e, OnEvent f)
        {
            if (subscribers.ContainsKey(e))
                subscribers[e].Remove(f);
        }

        public void TriggerEvent(IEvent e)
        {
            if (subscribers.ContainsKey(e.EventType))
                subscribers[e.EventType].ForEach(f => f(e));
        }

        public void EnqueueEvent(IEvent e)
        {
            queue.Enqueue(e);
        }

        public void ProcessQueue()
        {
            for (var i = queue.Count; i > 0; i--)
                TriggerEvent(queue.Dequeue());
        }
    }
}
