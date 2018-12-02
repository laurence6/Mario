using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class GameMarioStateNormal : GameMarioState
    {
        public GameMarioStateNormal(GameMario game) : base(game)
        {
        }

        protected override void Update(GameTime gameTime)
        {
            game.Controllers.ForEach(c => c.Update());
            Time.Update(gameTime);
            EventManager.Ins.Update();
            Scene.Ins.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        protected override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);

            Scene.Ins.Draw(spriteBatch);
            HUD.Ins.Draw(spriteBatch);
        }
    }
}
