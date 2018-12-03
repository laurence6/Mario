using Microsoft.Xna.Framework.Input;

namespace MarioPirates
{
    internal static class Commands
    {
        public static void Exit(string param)
        {
            EventManager.Ins.RaiseEvent(EventEnum.KeyDown, null, new KeyDownEventArgs(Keys.Escape));
            EventManager.Ins.RaiseEvent(EventEnum.KeyDown, null, new KeyDownEventArgs(Keys.Escape));
        }

        public static void New(string param)
        {
            System.Console.Error.WriteLine(param);
        }
    }
}
