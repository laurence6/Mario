namespace MarioPirates
{
    internal class GameObjectCreateEventArgs : System.EventArgs
    {
        public readonly GameObject Object;

        public GameObjectCreateEventArgs(GameObject o) => Object = o;
    }
}
