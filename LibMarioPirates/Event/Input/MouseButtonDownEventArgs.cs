using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class MouseButtonDownEventArgs : System.EventArgs
    {
        public readonly Point mousePosition;

        public MouseButtonDownEventArgs(Point mousePosition) => this.mousePosition = mousePosition;
    }
}
