using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class VirtualPlane : GameObjectRigidBody
    {
        public VirtualPlane(float locX, float locY) : base(locX, locY, Constants.SCREEN_WIDTH, 32)
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
