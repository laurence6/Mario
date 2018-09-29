using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal class CustomRigidBody : BaseRigidBody
    {
        private Rectangle BoundOffset;

        public override Rectangle Bound
        {
            get
            {
                var bound = BoundOffset;
                bound.Offset(Object.Location);
                return bound;
            }
        }

        public CustomRigidBody(GameObject gameObject, Rectangle boundOffset) : base(gameObject)
        {
            BoundOffset = boundOffset;
        }
    }
}
