using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    class HUD
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
            spriteBatch.DrawString(font, "SCORE", new Vector2(1 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 10), Color.White);
            spriteBatch.DrawString(font, "COINS", new Vector2(3 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 10), Color.White);
            spriteBatch.DrawString(font, "LEVEL", new Vector2(5 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 10), Color.White);
            spriteBatch.DrawString(font, "TIME", new Vector2(7 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 10), Color.White);
            spriteBatch.DrawString(font, "LIVES", new Vector2(9 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 10), Color.White);
            spriteBatch.DrawString(font, score.ToString(), new Vector2(1 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 5), Color.White);
            spriteBatch.DrawString(font, coins.ToString(), new Vector2(3 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 5), Color.White);
            spriteBatch.DrawString(font, level, new Vector2(5 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 5), Color.White);
            spriteBatch.DrawString(font, time.ToString(), new Vector2(7 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 5), Color.White);
            spriteBatch.DrawString(font, lives.ToString(), new Vector2(9 * Camera.ScreenWidth / 11, Camera.ScreenHeight / 5), Color.White);
            spriteBatch.End();
        }
    }
}
