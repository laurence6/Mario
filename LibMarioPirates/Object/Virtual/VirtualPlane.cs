using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class VirtualPlane : GameObjectRigidBody
    {
        public VirtualPlane(float locX, float locY) : base(locX, locY, Constants.SCREEN_WIDTH, Constants.VIRTUAL_PLANE_HEIGHT)
        {
            IsLocationAbsolute = true;
        }

        public override void Update(float dt)
        {
            RigidBody.UpdateBound();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
