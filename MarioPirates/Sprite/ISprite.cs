using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    public interface ISprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures);
    }
}
