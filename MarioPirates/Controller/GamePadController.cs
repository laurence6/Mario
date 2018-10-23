using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MarioPirates.Controller
{
    using static Common;

    internal class GamePadController : IController
    {
        private Dictionary<Buttons, ValueTuple<EventEnum, EventArgs>>[] eventMapping;
        private List<Buttons> enabledButton;

        private GamePadState prevState, currState;

        public GamePadController()
        {
            eventMapping = new Dictionary<Buttons, ValueTuple<EventEnum, EventArgs>>[EnumValues<InputState>().Length];
            for (var i = 0; i < eventMapping.Length; i++)
                eventMapping[i] = new Dictionary<Buttons, ValueTuple<EventEnum, EventArgs>>();
            enabledButton = new List<Buttons>();
            prevState = GamePad.GetState(PlayerIndex.One);
        }

        public void EnableButtonEvent(InputState state, params Buttons[] buttons)
        {
            buttons.ForEach(b =>
            {
                eventMapping[(int)state].Add(b, InputEventFactory.CreateButtonEvent(state, b));
                enabledButton.AddIfNotExist(b);
            });
        }

        public void Update()
        {
            currState = GamePad.GetState(PlayerIndex.One);
            if (currState.IsConnected)
            {
                enabledButton.ForEach(b =>
                {
                    var state = GetPrevButtonState(b) | GetCurrButtonState(b);

                    if (eventMapping[(int)state].TryGetValue(b, out var e))
                        EventManager.Ins.RaiseEvent(e.Item1, this, e.Item2);
                });
                prevState = currState;
            }
        }

        private InputState GetPrevButtonState(Buttons k) => prevState.IsButtonDown(k) ? InputState.Up : InputState.None;
        private InputState GetCurrButtonState(Buttons k) => currState.IsButtonDown(k) ? InputState.Down : InputState.None;
    }
}
