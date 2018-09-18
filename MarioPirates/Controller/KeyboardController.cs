using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, Commands.ICommand> mapping = new Dictionary<Keys, Commands.ICommand>();

        private KeyboardState prevState = Keyboard.GetState();

        public void AddCommandMapping(Commands.ICommand command, params Keys[] keys)
        {
            foreach (var k in keys)
            {
                mapping.Add(k, command);
            }
        }

        public void Update()
        {
            var currState = Keyboard.GetState();
            foreach (var m in mapping)
            {
                if (currState.IsKeyDown(m.Key) && !prevState.IsKeyDown(m.Key))
                {
                    m.Value.Execute();
                }
            }
            prevState = currState;
        }
    }
}