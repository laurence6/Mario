using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class VirtualWall : GameObjectRigidBody
    {
        public const int Width = 16, Height = Camera.ScreenHeight;

        public VirtualWall(float locX, float locY) : base(locX, locY, Width, Height)
        {
            IsLocationAbsolute = true;
        }

        public override void Update(float dt)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
