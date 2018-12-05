using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal class MapEditorStateNormal : MapEditorState
    {
        public MapEditorStateNormal(MapEditor editor) : base(editor)
        {
            Console.Ins.Reset();
            Console.Ins.Input("Left/Right arrow: move map; F4: open console");
        }

        public override void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Escape:
                    editor.Exit();
                    break;
                case Keys.F4:
                case Keys.OemSemicolon:
                    editor.State = new MapEditorStateConsole(editor);
                    break;
            }
        }
    }
}
