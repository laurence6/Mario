namespace MarioPirates
{
    internal class CollideEventArgs : System.EventArgs
    {
        public readonly GameObjectRigidBody object1;
        public readonly GameObjectRigidBody object2;

        public readonly CollisionSide side;
        public readonly float depth;

        public CollideEventArgs(GameObjectRigidBody object1, GameObjectRigidBody object2, CollisionSide side, float depth)
        {
            this.object1 = object1;
            this.object2 = object2;
            this.side = side;
            this.depth = depth;
        }
    }
}
