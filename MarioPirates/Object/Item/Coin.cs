namespace MarioPirates
{
    internal class Coin : GameObjectRigidBody
    {
        public Coin(int dstX, int dstY) : base(dstX, dstY, Constants.COIN_WIDTH * 2, Constants.COIN_HEIGHT * 2)
        {
            this.Sprite = SpriteFactory.Ins.CreateSprite("coin");
            this.RigidBody.Mass = Constants.COIN_MASS;
            this.RigidBody.CollisionLayerMask = CollisionLayer.Coin;
        }
    }
}
