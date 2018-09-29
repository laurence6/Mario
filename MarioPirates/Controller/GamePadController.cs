using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates.Controller
{
    using Event;
    using static Common;

    internal class GamePadController : IController
    {
        private Dictionary<Buttons, IEvent>[] mapping;

        private GamePadState prevState = GamePad.GetState(PlayerIndex.One);

        public GamePadController()
        {
            mapping = new Dictionary<Buttons, IEvent>[EnumValues<InputState>().Length];
            for (var i = 0; i < mapping.Length; i++)
                mapping[i] = new Dictionary<Buttons, IEvent>();
        }

        public void EnableButtonEvent(InputState state, Buttons[] buttons)
        {
            foreach (var b in buttons)
                mapping[(int)state].Add(b, InputEventFactory.CreateButtonEvent(state, b));
        }

        public void Update()
        {
            IEvent e = null;
            var currState = GamePad.GetState(PlayerIndex.One);
            if (currState.IsConnected)
            {
                foreach (var b in EnumValues<Buttons>())
                    if (currState.IsButtonDown(b))
                    {
                        if (prevState.IsButtonDown(b))
                        {
                            if (mapping[(int)InputState.Hold].TryGetValue(b, out e))
                                EventManager.Instance.EnqueueEvent(e);
                        }
                        else
                        {
                            if (mapping[(int)InputState.Down].TryGetValue(b, out e))
                                EventManager.Instance.EnqueueEvent(e);
                        }
                    }
                    else if (currState.IsButtonUp(b) && prevState.IsButtonDown(b))
                    {
                        if (mapping[(int)InputState.Up].TryGetValue(b, out e))
                            EventManager.Instance.EnqueueEvent(e);
                    }
                prevState = currState;
            }
        }
    }
}
