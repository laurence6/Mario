using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class DefaultRigidBody : BaseRigidBody
    {
        public override Rectangle Bound => new Rectangle((int)Object.Location.X, (int)Object.Location.Y, Object.Size.X, Object.Size.Y);

        public DefaultRigidBody(GameObject gameObject) : base(gameObject)
        {
        }
    }
}
