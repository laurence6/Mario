namespace MarioPirates
{
    using Event;

    internal class Coin : GameObjectRigidBody
    {
        private const int coinWidth = 7, coinHeight = 14;

        public Coin(int dstX, int dstY) : base(dstX, dstY, coinWidth * 2, coinHeight * 2)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("coins");
            RigidBody.Mass = 0.05f;
        }

        public override void OnCollide(GameObject obj, CollisionSide side)
        {
            if (obj is Mario)
            {
                EventManager.Instance.TriggerEvent(new GameObjectDestroyEvent(this));
            }
        }
    }
}
