using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal abstract class GameMarioState
    {
        protected GameMario game;

        public GameMarioState(GameMario game)
        {
            this.game = game;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void Pause()
        {
            game.State = new GameMarioStatePause(game);
        }
    }
}
