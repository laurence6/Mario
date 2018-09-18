using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> mapping = new Dictionary<Buttons, ICommand>();

        private GamePadState prevState = GamePad.GetState(PlayerIndex.One);

        public void AddCommandMapping(ICommand command, params Buttons[] buttons)
        {
            foreach (var b in buttons)
            {
                mapping.Add(b, command);
            }
        }

        public void Update()
        {
            var currState = GamePad.GetState(PlayerIndex.One);
            if (currState.IsConnected)
            {
                foreach (var m in mapping)
                {
                    if (currState.IsButtonDown(m.Key) && !(prevState.IsConnected && prevState.IsButtonDown(m.Key)))
                    {
                        m.Value.Execute();
                    }
                }
            }
            prevState = currState;
        }
    }
}