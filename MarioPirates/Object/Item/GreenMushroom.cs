namespace MarioPirates
{
    internal class GreenMushroom : GameObjectRigidBody
    {
        public GreenMushroom(int dstX, int dstY) : base(dstX, dstY, Constants.MUSHROOM_WIDTH * 2, Constants.MUSHROOM_HEIGHT * 2)
        {
            this.Sprite = SpriteFactory.Ins.CreateSprite("greenmushroom");
            this.RigidBody.Mass = Constants.MUSHROOM_MASS;
            this.RigidBody.CollisionLayerMask = CollisionLayer.Mushroom;
            this.RigidBody.Velocity = Constants.MUSHROOM_INITIAL_VELOCITY;
        }
    }
}
