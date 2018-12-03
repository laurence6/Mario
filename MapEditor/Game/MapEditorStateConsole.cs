using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal class MapEditorStateConsole : MapEditorState
    {
        public MapEditorStateConsole(MapEditor editor) : base(editor)
        {
        }

        public override void HandleKeyDown(KeyDownEventArgs e)
        {
            switch (e.key)
            {
                case Keys.Q:
                    editor.Exit();
                    break;
                case Keys.F4:
                case Keys.Escape:
                    editor.State = new MapEditorStateNormal(editor);
                    break;
            }
        }
    }
}
