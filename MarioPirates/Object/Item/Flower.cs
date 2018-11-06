namespace MarioPirates
{
    internal class Flower : GameObjectRigidBody
    {
        public Flower(int dstX, int dstY) : base(dstX, dstY, Constants.FLOWER_WIDTH * 2, Constants.FLOWER_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("flower");
            RigidBody.CollisionLayerMask = CollisionLayer.Flower;
            RigidBody.Motion = MotionEnum.Keyframe;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = Constants.OBJECT_PRECOLLISION_MASS;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
