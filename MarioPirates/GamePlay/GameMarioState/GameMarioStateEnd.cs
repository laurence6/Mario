using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal class GameMarioStateEnd : GameMarioState
    {
        public GameMarioStateEnd(GameMario game) : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Time.Update(gameTime);
            EventManager.Ins.Update();
            Scene.Ins.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);

            Scene.Ins.Draw(spriteBatch);
        }
    }
}
