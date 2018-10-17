using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal abstract class GameObject
    {
        public Sprite Sprite { get; set; }

        public bool IsStatic { get; set; } = true;

        protected Vector2 location;
        protected Point size;
        public virtual Vector2 Location { get => location; set => location = value; }
        public virtual Point Size { get => size; set => size = value; }

        protected GameObject(float locX, float locY, int sizeX, int sizeY)
        {
            location.X = locX;
            location.Y = locY;
            size.X = sizeX;
            size.Y = sizeY;
        }

        public virtual void Step(float dt)
        {
        }

        public virtual void Update(float dt)
        {
            Sprite.Update(dt);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, new Rectangle((int)location.X, (int)location.Y, size.X, size.Y));
        }
    }
}
