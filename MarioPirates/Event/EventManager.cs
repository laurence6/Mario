using System;

namespace MarioPirates.Event
{
    using static Common;

    internal static class EventManager
    {
        private static EventHandler[] handlerList = new EventHandler[EnumValues<EventEnum>().Length];

        public static void Reset()
        {
            for (var i = 0; i < handlerList.Length; i++)
                handlerList[i] = null;
        }

        public static void Subscribe(EventEnum type, EventHandler h)
        {
            handlerList[(int)type] += h;
        }

        public static void RaiseEvent(EventEnum type, object s, EventArgs e)
        {
            handlerList[(int)type]?.Invoke(s, e);
        }
    }
}
