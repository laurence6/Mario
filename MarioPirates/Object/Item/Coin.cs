namespace MarioPirates
{
    internal class Coin : GameObjectRigidBody
    {
        public Coin(int dstX, int dstY) : base(dstX, dstY, Constants.CASTLE_WIDTH * 2, Constants.CASTLE_HEIGHT * 2) // 16, 14
        {
            Sprite = SpriteFactory.Ins.CreateSprite("coin");
            RigidBody.Mass = Constants.COIN_MASS; // 0.05f
            RigidBody.CollisionLayerMask = CollisionLayer.Coin;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = Constants.COIN_PRECOLLISION_MASS; //1e-6f
                Coins.Ins.Value++;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
