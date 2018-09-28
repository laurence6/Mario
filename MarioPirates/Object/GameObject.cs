using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal abstract class GameObject
    {
        public Sprite Sprite { get; set; }

        public Point Size { get => size; set => size = value; }
        public Point Location { get => location; }

        protected Point size;
        protected Point location;

        public virtual void Update()
        {
            Sprite?.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            Sprite?.Draw(spriteBatch, textures, new Rectangle(location, size));
        }
    }
}
