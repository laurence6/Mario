using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class VirtualWall : GameObjectRigidBody
    {
        public VirtualWall(float locX, float locY) : base(locX, locY, 1, Camera.ScreenHeight)
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
