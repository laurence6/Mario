using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates.Object.Virtual
{
    internal class VirtualPlane : GameObjectRigidBody
    {
        public VirtualPlane(float locX, float locY) : base(locX, locY, 1, Camera.ScreenWidth)
        {
        }

        public override void Update(float dt)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
