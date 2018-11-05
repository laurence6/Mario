namespace MarioPirates
{
    internal class GameObjectCreateEventArgs : System.EventArgs
    {
        public readonly IGameObject Object;

        public GameObjectCreateEventArgs(IGameObject o) => Object = o;
    }
}
