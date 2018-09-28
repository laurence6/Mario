using System.Collections.Generic;

namespace MarioPirates.Event
{
    using static MarioPirates.Common;

    internal sealed class EventManager
    {
        public delegate void OnEvent(IEvent eventData);

        private List<OnEvent>[] subscribers;
        private Queue<IEvent> queueOld, queueActive;

        public static EventManager Instance { get; } = new EventManager();

        private EventManager()
        {
            subscribers = new List<OnEvent>[EnumValues<EventEnum>().Length];
            for (var i = 0; i < subscribers.Length; i++)
                subscribers[i] = new List<OnEvent>();
            queueOld = new Queue<IEvent>();
            queueActive = new Queue<IEvent>();
        }

        public void Reset()
        {
            for (var i = 0; i < subscribers.Length; i++)
                subscribers[i].Clear();
            queueOld.Clear();
            queueActive.Clear();
        }

        public void Subscribe(EventEnum e, OnEvent f)
        {
            if (!subscribers[(int)e].Contains(f))
                subscribers[(int)e].Add(f);
        }

        public void Unsubscribe(EventEnum e, OnEvent f)
        {
            subscribers[(int)e].Remove(f);
        }

        public void TriggerEvent(IEvent e)
        {
            subscribers[(int)e.EventType].ForEach(f => f(e));
        }

        public void EnqueueEvent(IEvent e)
        {
            queueActive.Enqueue(e);
        }

        public void ProcessQueue()
        {
            Swap(ref queueActive, ref queueOld);
            while (queueOld.Count > 0)
                TriggerEvent(queueOld.Dequeue());
        }
    }
}
