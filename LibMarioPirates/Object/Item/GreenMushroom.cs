namespace MarioPirates
{
    internal class GreenMushroom : GameObjectRigidBody
    {
        public GreenMushroom(int dstX, int dstY) : base(dstX, dstY, Constants.MUSHROOM_WIDTH * 2, Constants.MUSHROOM_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.GREEN_MUSHROOM_SPRITE);
            RigidBody.Mass = Constants.MUSHROOM_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Mushroom;
            RigidBody.Velocity = Constants.MUSHROOM_INITIAL_VELOCITY;
        }
    }
}
