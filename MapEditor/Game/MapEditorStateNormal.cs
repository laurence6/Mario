using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal class MapEditorStateNormal : MapEditorState
    {
        public MapEditorStateNormal(MapEditor editor) : base(editor)
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
                    editor.State = new MapEditorStateConsole(editor);
                    break;
            }
        }
    }
}
