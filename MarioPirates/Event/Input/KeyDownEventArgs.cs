using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{

    internal class KeyDownEventArgs : System.EventArgs
    {
        public readonly Keys key;

        public KeyDownEventArgs(Keys key) => this.key = key;
    }
}
