namespace MarioPirates.Event
{
    internal class GameObjectDestroyEventArgs : System.EventArgs
    {
        public GameObject Object { get; private set; }

        public GameObjectDestroyEventArgs(GameObject o) => Object = o;
    }
}
