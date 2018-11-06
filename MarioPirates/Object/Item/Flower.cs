namespace MarioPirates
{
    internal class Flower : GameObjectRigidBody
    {
        public Flower(int dstX, int dstY) : base(dstX, dstY, Constants.FLOWER_WIDTH * 2, Constants.FLOWER_HEIGHT * 2) // 16, 16
        {
            Sprite = SpriteFactory.Ins.CreateSprite("flower");
            RigidBody.CollisionLayerMask = CollisionLayer.Flower;
            RigidBody.Motion = MotionEnum.Keyframe;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = Constants.FLOWER_PRECOLLISION_MASS; // 1e-6f
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
