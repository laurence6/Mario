using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    using Event;

    internal class GamePadController : IController
    {
        private Dictionary<Buttons, IEvent> mapping = new Dictionary<Buttons, IEvent>();

        private GamePadState prevState = GamePad.GetState(PlayerIndex.One);

        public void AddEventMapping(IEvent e, params Buttons[] buttons)
        {
            foreach (var b in buttons)
                mapping.Add(b, e);
        }

        public void Update()
        {
            var currState = GamePad.GetState(PlayerIndex.One);
            if (currState.IsConnected)
                foreach (var m in mapping)
                    if (currState.IsButtonDown(m.Key) && !(prevState.IsConnected && prevState.IsButtonDown(m.Key)))
                        EventManager.Instance.EnqueueEvent(m.Value);
            prevState = currState;
        }
    }
}
