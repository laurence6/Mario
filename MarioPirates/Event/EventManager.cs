using System.Collections.Generic;

namespace MarioPirates.Event
{
    using static Common;

    internal sealed class EventManager
    {
        private static OnEvent[] subscribers = new OnEvent[EnumValues<EventEnum>().Length];
        private static Queue<IEvent> queueOld = new Queue<IEvent>(), queueActive = new Queue<IEvent>();

        public static void Reset()
        {
            for (var i = 0; i < subscribers.Length; i++)
                subscribers[i] = null;
            queueOld.Clear();
            queueActive.Clear();
        }

        public static void Subscribe(OnEvent f, params EventEnum[] eventTypes)
        {
            eventTypes.ForEach(e => subscribers[(int)e] += f);
        }

        public static void TriggerEvent(IEvent e)
        {
            subscribers[(int)e.EventType]?.Invoke(e);
        }

        public static void EnqueueEvent(IEvent e)
        {
            queueActive.Enqueue(e);
        }

        public static void ProcessQueue()
        {
            Swap(ref queueActive, ref queueOld);
            while (queueOld.Count > 0)
                TriggerEvent(queueOld.Dequeue());
        }
    }
}
