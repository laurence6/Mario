namespace MarioPirates
{
    internal class Flower : GameObjectRigidBody
    {
        private const int flowerWidth = 16, flowerHeight = 16;

        public Flower(int dstX, int dstY) : base(dstX, dstY, flowerWidth * 2, flowerHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("flower");
            RigidBody.CollisionLayerMask = CollisionLayer.Flower;
            RigidBody.Motion = MotionEnum.Keyframe;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = 1e-6f;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
