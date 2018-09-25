using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal abstract class GameObject
    {
        public Sprite Sprite { get; set; }
        public Point Location { get; set; }
        public Point Size { get; set; }

        public virtual void Update()
        {
            Sprite?.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            Sprite?.Draw(spriteBatch, textures, new Rectangle(Location.X, Location.Y, Size.X, Size.Y));
        }
    }
}
