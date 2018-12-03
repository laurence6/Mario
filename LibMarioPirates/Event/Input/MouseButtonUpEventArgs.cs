using Microsoft.Xna.Framework;

namespace MarioPirates
{

    internal class MouseButtonUpEventArgs : System.EventArgs
    {
        public readonly Point mousePosition;

        public MouseButtonUpEventArgs(Point mousePosition) => this.mousePosition = mousePosition;
    }
}
