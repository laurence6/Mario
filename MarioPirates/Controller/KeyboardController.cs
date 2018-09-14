using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> mapping = new Dictionary<Keys, ICommand>();

        private KeyboardState prevState = Keyboard.GetState();

        public void AddCommandMapping(Keys k, ICommand command)
        {
            mapping.Add(k, command);
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
