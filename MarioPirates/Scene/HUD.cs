using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal sealed class HUD
    {
        public static readonly HUD Ins = new HUD();

        public uint Time { get; set; } = 0;

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "SCORE", Constants.SCORE_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "COINS", Constants.COINS_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "LEVEL", Constants.LEVEL_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "TIME", Constants.TIME_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "LIVES", Constants.LIVES_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, Score.Ins.Value.ToString(), Constants.SCORE_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Coins.Ins.Value.ToString(), Constants.COINS_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Scene.Ins.ActiveScene.level, Constants.LEVEL_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Time.ToString(), Constants.TIME_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Lives.Ins.Value.ToString(), Constants.LIVES_VALUE_POSITION, Color.White);
            spriteBatch.End();
        }
    }
}
