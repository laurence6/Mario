using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal abstract class GameObjectBase : IGameObject
    {
        public abstract Vector2 Location { get; set; }
        public bool IsLocationAbsolute { get; set; } = false;

        public abstract Point Size { get; set; }

        public ISprite Sprite { get; set; }

        protected GameObjectBase(float locX, float locY, int sizeX, int sizeY)
        {
            Location = new Vector2(locX, locY);
            Size = new Point(sizeX, sizeY);
        }

        public virtual void Update(float dt)
        {
            Sprite.Update(dt);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Location.X, Location.Y, Size.X, Size.Y);
        }
    }
}
