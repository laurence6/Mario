using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal class MapEditorStateConsole : MapEditorState
    {
        public MapEditorStateConsole(MapEditor editor) : base(editor)
        {
            Console.Ins.Reset();
        }

        public override void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.F4:
                case Keys.Escape:
                    editor.State = new MapEditorStateNormal(editor);
                    break;
                default:
                    Console.Ins.HandleKeyDown(key);
                    break;
            }
        }

        public override void HandleKeyUp(Keys key)
        {
            switch (key)
            {
                default:
                    Console.Ins.HandleKeyUp(key);
                    break;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Console.Ins.Update();
        }

        protected override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            Console.Ins.Draw(spriteBatch);
        }
    }
}
