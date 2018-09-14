using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    public interface ISprite
    {
        void Update();

        void Draw(SpriteBatch spriteBatch, Texture2D texture);
    }
}