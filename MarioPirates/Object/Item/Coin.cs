namespace MarioPirates
{
    internal class Coin : GameObjectRigidBody
    {
        private const int coinWidth = 16, coinHeight = 14;

        public Coin(int dstX, int dstY) : base(dstX, dstY, coinWidth * 2, coinHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("coin");
            RigidBody.Mass = 0.05f;
            RigidBody.CollisionLayerMask = CollisionLayer.Coin;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = 1e-6f;
                Coins.Ins.Value++;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
