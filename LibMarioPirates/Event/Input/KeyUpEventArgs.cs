using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{

    internal class KeyUpEventArgs : System.EventArgs
    {
        public readonly Keys key;

        public KeyUpEventArgs(Keys key) => this.key = key;
    }
}
