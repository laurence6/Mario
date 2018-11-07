using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class HUD
    {
        private uint score;
        private uint coins;
        private uint time;
        private uint lives;
        private string level;

        public static readonly HUD Ins = new HUD();

        private HUD()
        {
            score = 0;
            coins = 0;
            level = "";
            time = 0;
            lives = 0;
        }

        public void UpdateScore(uint score)
        {
            this.score = score;
        }

        public void UpdateCoins(uint coins)
        {
            this.coins = coins;
        }

        public void UpdateLevel(string level)
        {
            this.level = level;
        }

        public void UpdateTime(uint time)
        {
            this.time = time;
        }

        public void UpdateLives(uint lives)
        {
            this.lives = lives;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "SCORE", Constants.SCORE_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "COINS", Constants.COINS_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "LEVEL", Constants.LEVEL_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "TIME", Constants.TIME_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, "LIVES", Constants.LIVES_TITLE_POSITION, Color.White);
            spriteBatch.DrawString(font, score.ToString(), Constants.SCORE_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, coins.ToString(), Constants.COINS_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, level, Constants.LEVEL_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, time.ToString(), Constants.TIME_VALUE_POSITION, Color.White);
            spriteBatch.DrawString(font, lives.ToString(), Constants.LIVES_VALUE_POSITION, Color.White);
            spriteBatch.End();
        }
    }
}
