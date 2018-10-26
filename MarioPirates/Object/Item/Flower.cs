namespace MarioPirates
{
    internal class Flower : GameObjectRigidBody
    {
        private const int flowerWidth = 16, flowerHeight = 16;

        public Flower(int dstX, int dstY) : base(dstX, dstY, flowerWidth * 2, flowerHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("flower");
            RigidBody.Mass = 0.05f;
            RigidBody.CollisionLayerMask = CollisionLayer.Flower;
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
