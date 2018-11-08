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
    }
}
