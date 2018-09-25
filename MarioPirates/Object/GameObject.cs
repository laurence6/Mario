using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public abstract class GameObject
    {
        public Sprite sprite;
        public Point location, size;

        public virtual void Update()
        {
            sprite?.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            sprite?.Draw(spriteBatch, textures, new Rectangle(location.X, location.Y, size.X, size.Y));
        }
    }
}
