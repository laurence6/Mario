using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MarioPirates.Controller
{
    using Event;
    using static Common;

    internal class KeyboardController : IController
    {
        private Dictionary<Keys, List<Keys>> inputMapping;
        private Dictionary<Keys, IEvent>[] eventMapping;
        private List<Keys> enabledKey;

        private KeyboardState prevState, currState;

        public KeyboardController()
        {
            inputMapping = new Dictionary<Keys, List<Keys>>();
            eventMapping = new Dictionary<Keys, IEvent>[EnumValues<InputState>().Length];
            for (var i = 0; i < eventMapping.Length; i++)
                eventMapping[i] = new Dictionary<Keys, IEvent>();
            enabledKey = new List<Keys>();
            prevState = Keyboard.GetState();
        }

        public void SetKeyMapping(Keys k1, Keys k2)
        {
            if (!inputMapping.ContainsKey(k2))
                inputMapping.Add(k2, new List<Keys> { k2 });
            inputMapping[k2].AddIfNotExist(k1);
        }

        public void EnableKeyEvent(InputState state, params Keys[] keys)
        {
            foreach (var k in keys)
            {
                eventMapping[(int)state].Add(k, InputEventFactory.CreateKeyEvent(state, k));
                enabledKey.AddIfNotExist(k);
            }
        }

        public void Update()
        {
            currState = Keyboard.GetState();

            enabledKey.ForEach(k =>
            {
                var state = InputState.None;
                if (inputMapping.TryGetValue(k, out var mappings))
                    mappings.ForEach(k1 => state |= GetPrevKeyState(k1) | GetCurrKeyState(k1));
                else
                    state |= GetPrevKeyState(k) | GetCurrKeyState(k);

                if (eventMapping[(int)state].TryGetValue(k, out var e))
                    EventManager.Instance.EnqueueEvent(e);
            });

            prevState = currState;
        }

        private InputState GetPrevKeyState(Keys k) => prevState.IsKeyDown(k) ? InputState.Up : InputState.None;
        private InputState GetCurrKeyState(Keys k) => currState.IsKeyDown(k) ? InputState.Down : InputState.None;
    }
}
