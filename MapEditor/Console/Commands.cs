using Microsoft.Xna.Framework.Input;
using System;
using System.Web.Script.Serialization;

namespace MarioPirates
{
    internal static class Commands
    {
        public static void CmdExit(string param)
        {
            EventManager.Ins.RaiseEvent(EventEnum.KeyDown, null, new KeyDownEventArgs(Keys.Escape));
            EventManager.Ins.RaiseEvent(EventEnum.KeyDown, null, new KeyDownEventArgs(Keys.Escape));
        }

        public static void CmdNew(string param)
        {
            var objectParam = new JavaScriptSerializer().Deserialize<GameObjectParam>(param);
            objectParam.Location = new int[] { (int)Camera.Ins.Offset, 0 };
            Scene.Ins.AddGameObject(Scene.Ins.Model.AddGameObject(objectParam));
        }

        public static void CmdWrite(string param)
        {
            Scene.Ins.Model.Write();
        }

        public static void CmdUse(string param)
        {
            Scene.Ins.UseScene(param);
        }

        public static void CmdHelp(string param)
        {
            var str = string.Empty;
            foreach (var m in typeof(Commands).GetMethods())
                if (m.Name.StartsWith(Constants.CONSOLE_COMMANDS_PREFIX))
                    str += m.Name.Substring(Constants.CONSOLE_COMMANDS_PREFIX.Length) + " ";
            Console.Ins.Input(str);
        }

        public static bool Execute(string name, string param)
        {
            foreach (var m in typeof(Commands).GetMethods())
                if ((Constants.CONSOLE_COMMANDS_PREFIX + name).ToLower() == m.Name.ToLower())
                {
                    try
                    {
                        m.Invoke(null, new object[] { param });
                    }
                    catch (Exception e)
                    {
                        Console.Ins.Input(Constants.CONSOLE_ERROR + e.ToString());
                    }
                    return true;
                }
            return false;
        }
    }
}
