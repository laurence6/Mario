namespace MarioPirates
{
    using Event;

    internal class RedMushroom : GameObjectRigidBody
    {
        private const int redMushroomWidth = 16, redMushroomHeight = 16;

        public RedMushroom(int dstX, int dstY) : base(dstX, dstY, redMushroomWidth * 2, redMushroomHeight * 2)
        {
            Sprite = SpriteFactory.CreateSprite("redmushroom");
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
