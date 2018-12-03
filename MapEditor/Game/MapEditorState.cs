using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal abstract class MapEditorState
    {
        protected readonly MapEditor editor;

        public MapEditorState(MapEditor editor)
        {
            this.editor = editor;
        }

        public void DoUpdate(GameTime gameTime)
        {
            Update(gameTime);
        }

        public void DoDraw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch);
        }

        public virtual void HandleKeyDown(Keys key)
        {
        }
        public virtual void HandleKeyUp(Keys key)
        {
        }

        protected virtual void Update(GameTime gameTime)
        {
            editor.Controllers.ForEach(c => c.Update());
            Time.Update(gameTime);
            EventManager.Ins.Update();
            Scene.Ins.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        protected virtual void Draw(SpriteBatch spriteBatch)
        {
            Scene.Ins.Draw(spriteBatch);
        }
    }
}
