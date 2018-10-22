using System;

namespace MarioPirates
{
    internal class ActionEventArgs : EventArgs
    {
        private Action action;

        public ActionEventArgs(Action action) => this.action = action;

        public static void Reset()
        {
            EventManager.Subscribe(EventEnum.Action, (s, e) => ((ActionEventArgs)e).action());
        }
    }
}
