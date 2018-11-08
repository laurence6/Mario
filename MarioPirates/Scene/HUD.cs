using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal sealed class HUD
    {
        public static readonly HUD Ins = new HUD();

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, Constants.SCORE_TITLE, Constants.SCORE_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, Constants.COINS_TITLE, Constants.COINS_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, Constants.LEVEL_TITLE, Constants.LEVEL_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, Constants.TIME_TITLE, Constants.TIME_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, Constants.LIVES_TITLE, Constants.LIVES_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, Score.Ins.Value.ToString(), Constants.SCORE_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Coins.Ins.Value.ToString(), Constants.COINS_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Scene.Ins.ActiveScene.level, Constants.LEVEL_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Timer.Ins.Value.ToString(), Constants.TIME_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, Lives.Ins.Value.ToString(), Constants.LIVES_VALUE_POSITION, Color.White);
            spriteBatch.End();
        }
    }
}
