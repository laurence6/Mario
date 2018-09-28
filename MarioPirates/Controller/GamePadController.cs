using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;
    using static Common;

    internal class GamePadController : IController
    {
        private Dictionary<Buttons, IEvent>[] mapping = new Dictionary<Buttons, IEvent>[2] {
            new Dictionary<Buttons, IEvent>(),
            new Dictionary<Buttons, IEvent>(),
        };

        private GamePadState prevState = GamePad.GetState(PlayerIndex.One);

        public void AddEventMapping(IEvent e, InputState state, Buttons[] buttons)
        {
            foreach (var b in buttons)
                mapping[(int)state].Add(b, e);
        }

        public void Update()
        {
            IEvent e = null;
            var currState = GamePad.GetState(PlayerIndex.One);
            if (currState.IsConnected)
            {
                foreach (var b in EnumValues<Buttons>())
                    if (currState.IsButtonDown(b) && prevState.IsButtonUp(b))
                    {
                        if (mapping[(int)InputState.Down].TryGetValue(b, out e))
                            EventManager.Instance.EnqueueEvent(e);
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
