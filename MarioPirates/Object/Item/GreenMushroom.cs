﻿namespace MarioPirates
{
    using Event;

    internal class GreenMushroom : GameObjectRigidBody
    {
        private const int greenMushroomWidth = 16, greenMushroomHeight = 16;

        public GreenMushroom(int dstX, int dstY) : base(dstX, dstY, greenMushroomWidth * 2, greenMushroomHeight * 2)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("greenmushroom");
            RigidBody.Mass = 0.05f;
        }

        public override void OnCollide(GameObject other, CollisionSide side)
        {
            if (other is Mario)
            {
                EventManager.Instance.TriggerEvent(new GameObjectDestroyEvent(this));
            }
        }
    }
}
