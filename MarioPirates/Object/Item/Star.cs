namespace MarioPirates
{
    internal class Star : GameObjectRigidBody
    {
        public Star(int dstX, int dstY) : base(dstX, dstY, Constants.STAR_WIDTH * 2, Constants.STAR_HEIGHT * 2)
        {
            this.Sprite = SpriteFactory.Ins.CreateSprite("star");
            this.RigidBody.Mass = Constants.STAR_MASS;
            this.RigidBody.CollisionLayerMask = CollisionLayer.Star;
            this.RigidBody.Velocity = Constants.STAR_INITIAL_VELOCITY;
        }
    }
}
