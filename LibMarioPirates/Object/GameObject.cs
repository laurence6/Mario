using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class GameObject : GameObjectBase
    {
        private Vector2 location;
        public override Vector2 Location
        {
            get => IsLocationAbsolute ? new Vector2(location.X + Camera.Ins.Offset, location.Y) : location;
            set { location = value; location.X -= IsLocationAbsolute ? Camera.Ins.Offset : 0f; }
        }

        public override Point Size { get; set; }

        protected GameObject(float locX, float locY, int sizeX, int sizeY) : base(locX, locY, sizeX, sizeY)
        {
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
