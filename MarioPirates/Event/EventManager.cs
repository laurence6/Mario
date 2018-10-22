using System;
using System.Collections.Generic;
using System.Linq;

namespace MarioPirates.Event
{
    using static Common;

    internal static class EventManager
    {
        private static EventHandler[] handlerList = new EventHandler[EnumValues<EventEnum>().Length];

        private static Dictionary<float, ValueTuple<EventEnum, object, EventArgs>> waitlist = new Dictionary<float, (EventEnum, object, EventArgs)>();

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
            waitlist.Add(Time.Now + dt, (type, s, e));
        }

        public static void Update()
        {
            var t = Time.Now;
            var keys = waitlist.Keys.ToList();
            keys.Sort();
            foreach (var k in keys)
            {
                if (k <= t)
                {
                    (var type, var s, var e) = waitlist[k];
                    waitlist.Remove(k);
                    RaiseEvent(type, s, e);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
