using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates.Object
{
    public abstract class GameObject
    {
        public ISprite sprite;
        public Point location, size;

        public GameObject(ISprite sprite, Point location, Point size)
        {
            this.sprite = sprite;
            this.location = location;
            this.size = size;
        }

        public virtual void Update() { }

        public virtual void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures, Rectangle drawDst)
        {
            sprite?.Draw(spriteBatch, textures, new Rectangle(location.X, location.Y, size.X, size.Y));
        }
    }
}
