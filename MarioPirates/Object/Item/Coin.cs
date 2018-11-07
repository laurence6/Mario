namespace MarioPirates
{
    internal class Coin : GameObjectRigidBody
    {
        public Coin(int dstX, int dstY) : base(dstX, dstY, Constants.COIN_WIDTH * 2, Constants.COIN_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("coin");
            RigidBody.Mass = Constants.COIN_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.Coin;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = Constants.OBJECT_PRECOLLISION_MASS;
                Coins.Ins.Value++;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
