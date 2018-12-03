using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal class MapEditorStateNormal : MapEditorState
    {
        public MapEditorStateNormal(MapEditor editor) : base(editor)
        {
        }

        public override void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Escape:
                    editor.Exit();
                    break;
                case Keys.F4:
                    editor.State = new MapEditorStateConsole(editor);
                    break;
            }
        }
    }
}
