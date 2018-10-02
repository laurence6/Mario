using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioPirates.Event
{
    internal class GameObjectDestroyEvent : IEvent
    {
        public EventEnum EventType => EventEnum.GameObjectDestroy;

        public GameObject object1 { get; private set; }

        public GameObjectDestroyEvent(GameObject o1)
        {
            object1 = o1;
        }

    }
}
