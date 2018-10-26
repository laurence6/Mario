using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class GreenMushroom : GameObjectRigidBody
    {
        private const int greenMushroomWidth = 16, greenMushroomHeight = 16;

        public GreenMushroom(int dstX, int dstY) : base(dstX, dstY, greenMushroomWidth * 2, greenMushroomHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("greenmushroom");
            RigidBody.Mass = 0.05f;
            RigidBody.CollisionLayerMask = CollisionLayer.Mushroom;
            RigidBody.Velocity = new Vector2(50f, 0f);
        }

        public override void PreCollide(GameObjectRigidBody other, CollisionSide side)
        {
            if (other is Mario)
            {
                RigidBody.Mass = 1e-6f;
                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, this, new GameObjectDestroyEventArgs(this));
            }
            base.PostCollide(other, side);
        }
    }
}
