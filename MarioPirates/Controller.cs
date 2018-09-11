using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates
{
    interface IController
    {
        void Update();
    }

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

    class GamePadController : IController
    {
        private Dictionary<Buttons, ICommand> mapping = new Dictionary<Buttons, ICommand>();

        private GamePadState prevState = GamePad.GetState(PlayerIndex.One);

        public void AddCommandMapping(Buttons b, ICommand command)
        {
            mapping.Add(b, command);
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