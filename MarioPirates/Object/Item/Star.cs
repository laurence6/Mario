namespace MarioPirates
{
    internal class Star : GameObjectRigidBody
    {
        public Star(int dstX, int dstY) : base(dstX, dstY, Constants.STAR_WIDTH * 2, Constants.STAR_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("star");
            RigidBody.Mass = Constants.STAR_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Star;
            RigidBody.Velocity = Constants.STAR_INITIAL_VELOCITY;
        }
    }
}
