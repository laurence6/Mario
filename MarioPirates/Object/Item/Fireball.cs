namespace MarioPirates
{
    internal class Fireball : GameObjectRigidBody
    {
        public Fireball(int dstX, int dstY) : base(dstX, dstY, Constants.FIREBALL_WIDTH * 2, Constants.FIREBALL_HEIGHT * 2)
        {
            this.Sprite = SpriteFactory.Ins.CreateSprite("fireball");
            this.RigidBody.Mass = Constants.FIREBALL_MASS;
            this.RigidBody.CollisionLayerMask = CollisionLayer.Enemy | CollisionLayer.Static;
            this.RigidBody.Motion = MotionEnum.Dynamic;
        }
    }
}
