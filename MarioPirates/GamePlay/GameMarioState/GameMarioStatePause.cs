using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class GameMarioStatePause : GameMarioState
    {
        public GameMarioStatePause(GameMario game) : base(game)
        {
        }

        protected override void Update(GameTime gameTime)
        {
            game.Controllers.ForEach(c => c.Update());
        }

        protected override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);

            Scene.Ins.Draw(spriteBatch);
            HUD.Ins.Draw(spriteBatch);
        }

        public override void Pause()
        {
            game.State = new GameMarioStateNormal(game);
            Timer.Ins.Unfreeze();
        }
    }
}
