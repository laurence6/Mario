using System;
using System.Collections.Generic;

namespace MarioPirates.Event
{
    using static Common;

    internal static class EventManager
    {
        private static EventHandler[] handlerList = new EventHandler[EnumValues<EventEnum>().Length];

        private static List<ValueTuple<float, EventEnum, object, EventArgs>> waitlist = new List<(float, EventEnum, object, EventArgs)>();

        public static void Reset()
        {
            for (var i = 0; i < handlerList.Length; i++)
                handlerList[i] = null;
        }

        public static Action Subscribe(EventEnum type, EventHandler h)
        {
            handlerList[(int)type] += h;
            return () => handlerList[(int)type] -= h;
        }

        public static void RaiseEvent(EventEnum type, object s, EventArgs e)
        {
            handlerList[(int)type]?.Invoke(s, e);
        }

        public static void RaiseEvent(EventEnum type, object s, EventArgs e, float dt)
        {
            waitlist.Add((Time.Now + dt, type, s, e));
        }

        public static void Update()
        {
            var t = Time.Now;
            waitlist.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            while (waitlist.Count > 0)
            {
                (var due, var type, var s, var e) = waitlist[0];
                if (due > t)
                    break;
                waitlist.RemoveAt(0);
                RaiseEvent(type, s, e);
            }
        }
    }
}
