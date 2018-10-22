namespace MarioPirates
{
    internal class Coin : GameObjectRigidBody
    {
        private const int coinWidth = 7, coinHeight = 14;

        public Coin(int dstX, int dstY) : base(dstX, dstY, coinWidth * 2, coinHeight * 2)
        {
            Sprite = SpriteFactory.CreateSprite("coins");
            RigidBody.Mass = 0.05f;
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = 1e-6f;
                EventManager.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
