using System.Collections.Generic;

namespace MarioPirates.Event
{
    using static MarioPirates.Common;

    internal sealed class EventManager
    {
        public delegate void OnEvent(IEvent eventData);

        private OnEvent[] subscribers;
        private Queue<IEvent> queueOld, queueActive;

        public static EventManager Instance { get; } = new EventManager();

        private EventManager()
        {
            subscribers = new OnEvent[EnumValues<EventEnum>().Length];
            queueOld = new Queue<IEvent>();
            queueActive = new Queue<IEvent>();
        }

        public void Reset()
        {
            for (var i = 0; i < subscribers.Length; i++)
                subscribers[i] = null;
            queueOld.Clear();
            queueActive.Clear();
        }

        public void Subscribe(OnEvent f, params EventEnum[] eventTypes)
        {
            foreach (var e in eventTypes)
                subscribers[(int)e] += f;
        }

        public void Unsubscribe(OnEvent f, params EventEnum[] eventTypes)
        {
            foreach (var e in eventTypes)
                subscribers[(int)e] -= f;
        }

        public void TriggerEvent(IEvent e)
        {
            subscribers[(int)e.EventType]?.Invoke(e);
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
