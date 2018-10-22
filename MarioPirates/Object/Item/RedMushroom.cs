using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class RedMushroom : GameObjectRigidBody
    {
        private const int redMushroomWidth = 16, redMushroomHeight = 16;

        public RedMushroom(int dstX, int dstY) : base(dstX, dstY, redMushroomWidth * 2, redMushroomHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("redmushroom");
            RigidBody.Mass = 0.05f;

            RigidBody.Velocity = new Vector2(25f, 0f);
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
