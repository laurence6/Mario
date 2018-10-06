namespace MarioPirates
{
    using Event;

    internal class Flower : GameObjectRigidBody
    {
        private const int flowerWidth = 16, flowerHeight = 16;

        public Flower(int dstX, int dstY) : base(dstX, dstY, flowerWidth * 2, flowerHeight * 2)
        {
            Sprite = SpriteFactory.CreateSprite("flower");
            RigidBody.Mass = 0.05f;
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {
                EventManager.TriggerEvent(new GameObjectDestroyEvent(this));
            }
        }
    }
}
