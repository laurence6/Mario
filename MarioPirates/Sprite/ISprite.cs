using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal interface ISprite
    {
        void Update(float dt);
        void Draw(SpriteBatch spriteBatch, float dstX, float dstY, int? sizeX = null, int? sizeY = null);
    }
}
