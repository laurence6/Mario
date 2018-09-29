using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates.Controller
{
    using Event;
    using static Common;

    internal class KeyboardController : IController
    {
        private Dictionary<Keys, IEvent>[] mapping;

        private KeyboardState prevState = Keyboard.GetState();

        public KeyboardController()
        {
            mapping = new Dictionary<Keys, IEvent>[EnumValues<InputState>().Length];
            for (var i = 0; i < mapping.Length; i++)
                mapping[i] = new Dictionary<Keys, IEvent>();
        }

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
                if (currState.IsKeyDown(k))
                {
                    if (prevState.IsKeyDown(k))
                    {
                        if (mapping[(int)InputState.Hold].TryGetValue(k, out e))
                            EventManager.Instance.EnqueueEvent(e);
                    }
                    else
                    {
                        if (mapping[(int)InputState.Down].TryGetValue(k, out e))
                            EventManager.Instance.EnqueueEvent(e);
                    }
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
