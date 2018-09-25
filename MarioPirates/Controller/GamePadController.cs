using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class GamePadController : IController
    {
        private Dictionary<Buttons, Command.ICommand> mapping = new Dictionary<Buttons, Command.ICommand>();

        private GamePadState prevState = GamePad.GetState(PlayerIndex.One);

        public void AddCommandMapping(Command.ICommand command, params Buttons[] buttons)
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
