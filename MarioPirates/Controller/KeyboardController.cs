using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;

    internal class KeyboardController : IController
    {
        private Dictionary<Keys, IEvent> mapping = new Dictionary<Keys, IEvent>();

        private KeyboardState prevState = Keyboard.GetState();

        public void AddEventMapping(IEvent eventData, params Keys[] keys)
        {
            foreach (var k in keys)
                mapping.Add(k, eventData);
        }

        public void Update()
        {
            var currState = Keyboard.GetState();
            foreach (var m in mapping)
                if (currState.IsKeyDown(m.Key) && !prevState.IsKeyDown(m.Key))
                    EventManager.Instance.EnqueueEvent(m.Value);
            prevState = currState;
        }
    }
}
