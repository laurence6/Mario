using Microsoft.Xna.Framework;

namespace MarioPirates
{

    internal class MouseButtonHoldEventArgs : System.EventArgs
    {
        public readonly Point mousePosition;

        public MouseButtonHoldEventArgs(Point mousePosition) => this.mousePosition = mousePosition;
    }
}
