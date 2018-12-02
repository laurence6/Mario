namespace MarioPirates
{
    internal class Fireball : GameObjectRigidBody
    {
        public Fireball(int dstX, int dstY) : base(dstX, dstY, Constants.FIREBALL_WIDTH * 2, Constants.FIREBALL_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.FIREBALL_SPRITE);
            RigidBody.Mass = Constants.FIREBALL_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Enemy | CollisionLayer.Static;
            RigidBody.Motion = MotionEnum.Dynamic;
        }
    }
}
