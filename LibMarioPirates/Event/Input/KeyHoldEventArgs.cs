using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{

    internal class KeyHoldEventArgs : System.EventArgs
    {
        public readonly Keys key;

        public KeyHoldEventArgs(Keys key) => this.key = key;
    }
}
