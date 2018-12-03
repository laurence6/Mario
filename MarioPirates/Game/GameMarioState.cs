using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    internal abstract class GameMarioState
    {
        protected readonly GameMario game;

        private GameMarioStatePending pending = GameMarioStatePending.None;

        public GameMarioState(GameMario game)
        {
            this.game = game;
        }

        public void DoUpdate(GameTime gameTime)
        {
            if (pending != GameMarioStatePending.None)
            {
                pending.Handle(game);
                pending = GameMarioStatePending.None;
            }
            else
            {
                Update(gameTime);
            }
        }

        public void DoDraw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
        }

        public virtual void Pause()
        {
            game.State = new GameMarioStatePause(game);
            Timer.Ins.Freeze();
        }

        public void TriggerGameOver() => pending |= GameMarioStatePending.GameOver;
        public void TriggerGameWin() => pending |= GameMarioStatePending.GameWin;
        public void TriggerReset() => pending |= GameMarioStatePending.Reset;

        protected abstract void Update(GameTime gameTime);

        protected abstract void Draw(SpriteBatch spriteBatch);
    }
}
