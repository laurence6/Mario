using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal class MapEditorStateNormal : MapEditorState
    {
        public MapEditorStateNormal(MapEditor editor) : base(editor)
        {
            Console.Ins.Reset();

            Constants.MAPEDITOR_HELP.ForEach(s =>
            {
                Console.Ins.Input(s);
                Console.Ins.NextLine();
            });
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
