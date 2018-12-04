using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal abstract class GameObject : GameObjectBase
    {
        public override Vector2 Location
        {
            get => IsLocationAbsolute ? Camera.Ins.ScreenToWorld(RelLocation) : RelLocation;
            set => RelLocation = IsLocationAbsolute ? Camera.Ins.WorldToScreen(value) : value;
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
