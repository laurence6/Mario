namespace MarioPirates.Event
{
    internal class CollideEventArgs : System.EventArgs
    {
        public readonly GameObject object1;
        public readonly GameObject object2;

        public readonly CollisionSide side;
        public readonly float depth;

        public CollideEventArgs(GameObject object1, GameObject object2, CollisionSide side, float depth)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.side = side;
            this.depth = depth;
        }
    }
}
