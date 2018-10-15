namespace MarioPirates.Event
{
    internal class GameObjectCreateEventArgs : System.EventArgs
    {
        public readonly GameObjectParam param;

        public GameObjectCreateEventArgs(GameObjectParam param) => this.param = param;
    }
}
