using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates.Controller
{
    using Event;
    using static Common;

    internal class KeyboardController : IController
    {
        private Dictionary<Keys, IEvent>[] mapping = new Dictionary<Keys, IEvent>[2] {
            new Dictionary<Keys, IEvent>(),
            new Dictionary<Keys, IEvent>(),
        };

        private KeyboardState prevState = Keyboard.GetState();

        public void EnableKeyEvent(InputState state, params Keys[] keys)
        {
            foreach (var k in keys)
                mapping[(int)state].Add(k, InputEventFactory.CreateKeyEvent(state, k));
        }

        public void Update()
        {
            IEvent e = null;
            var currState = Keyboard.GetState();
            foreach (var k in EnumValues<Keys>())
                if (currState.IsKeyDown(k) && prevState.IsKeyUp(k))
                {
                    if (mapping[(int)InputState.Down].TryGetValue(k, out e))
                        EventManager.Instance.EnqueueEvent(e);
                }
                else if (currState.IsKeyUp(k) && prevState.IsKeyDown(k))
                {
                    if (mapping[(int)InputState.Up].TryGetValue(k, out e))
                        EventManager.Instance.EnqueueEvent(e);
                }
            prevState = currState;
        }
    }
}
