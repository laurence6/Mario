using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace MarioPirates
{
    internal class SpriteText : ISprite
    {
        private SpriteFont font;
        private Func<string> getString;
        private Color color;

        public SpriteText(SpriteFont font, Func<string> getString)
        {
            this.font = font;
            this.getString = getString;
            color = Color.White;
        }

        public void Draw(SpriteBatch spriteBatch, float dstX, float dstY, int? sizeX, int? sizeY)
        {
            spriteBatch.DrawString(font, getString(), new Vector2(dstX, dstY), color);
        }
    }
}
