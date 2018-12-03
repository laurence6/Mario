using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
            editor.Controllers.ForEach(c => c.Update());
            Time.Update(gameTime);
            EventManager.Ins.Update();
            Scene.Ins.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        public void DoDraw(SpriteBatch spriteBatch)
        {
            Scene.Ins.Draw(spriteBatch);
        }

        public abstract void HandleKeyDown(KeyDownEventArgs e);
    }
}
