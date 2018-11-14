using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioPirates
{
    internal sealed class HUD
    {
        public static readonly HUD Ins = new HUD();

        private HUD()
        {
        }

        private List<(ISprite, Vector2)> components = new List<(ISprite, Vector2)>();

        public void Reset()
        {
            components.Add((SpriteFactory.Ins.CreateSprite(() => Constants.SCORE_TITLE), Constants.SCORE_TITLE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Constants.COINS_TITLE), Constants.COINS_TITLE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Constants.LEVEL_TITLE), Constants.LEVEL_TITLE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Constants.TIME_TITLE), Constants.TIME_TITLE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Constants.LIVES_TITLE), Constants.LIVES_TITLE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Scene.Ins.ActiveScene.level), Constants.LEVEL_VALUE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Score.Ins.Value.ToString()), Constants.SCORE_VALUE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Coins.Ins.Value.ToString()), Constants.COINS_VALUE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Timer.Ins.Value.ToString()), Constants.TIME_VALUE_POSITION));
            components.Add((SpriteFactory.Ins.CreateSprite(() => Lives.Ins.Value.ToString()), Constants.LIVES_VALUE_POSITION));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            components.ForEach(c => c.Item1.Draw(spriteBatch, c.Item2.X, c.Item2.Y));
            spriteBatch.End();
        }
    }
}
