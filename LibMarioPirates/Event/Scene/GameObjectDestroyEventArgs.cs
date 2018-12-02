namespace MarioPirates
{
    internal class GameObjectDestroyEventArgs : System.EventArgs
    {
        public readonly IGameObject Object;

        public GameObjectDestroyEventArgs(IGameObject o) => Object = o;
    }
}
