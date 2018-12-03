using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal sealed class Console
    {
        public static readonly Console Ins = new Console();

        private Console()
        {
        }

        private SpriteText sprite;

        private string text;

        public void Reset()
        {
            text = "";
            sprite = SpriteFactory.Ins.CreateSmallFontSprite(() => "> " + text);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            sprite.Draw(spriteBatch, Constants.CONSOLE_POSITION.X, Constants.CONSOLE_POSITION.Y);
            spriteBatch.End();
        }

        public void HandleKey(Keys key)
        {
            switch (key)
            {
                case Keys k when (Keys.A <= k && k <= Keys.Z):
                    text += k;
                    break;
                case Keys.Enter:
                    break;
            }
        }
    }
}
