using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace MarioPirates
{
    internal static class Commands
    {
        private static readonly string HelpTitle = "Command      Description";
        private static readonly Dictionary<string, (Action<string>, string)> Cmds = new Dictionary<string, (Action<string>, string)>
        {
            { "exit",  (CmdExit, "exit map editor ( exit )") },
            { "use", (CmdUse, "switch levels ( use underwater )") },
            { "new",  (CmdNew, "create new object ( new { \"TypeName\": \"Koopa\" } )") },
            { "write", (CmdWrite, "write to data file ( write )") },
            { "help", (CmdHelp, "help") }
        };

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
            Console.Ins.Input(HelpTitle);
            Console.Ins.NextLine();
            foreach (var p in Cmds)
            {
                Console.Ins.Input(p.Key);
                Console.Ins.Input("             ");
                Console.Ins.Input(p.Value.Item2);
                Console.Ins.NextLine();
            }
        }

        public static void Execute(string name, string param)
        {
            foreach (var p in Cmds)
                if (name.ToLower() == p.Key)
                {
                    try
                    {
                        p.Value.Item1(param);
                    }
                    catch (Exception e)
                    {
                        Console.Ins.Input(Constants.CONSOLE_ERROR + e.ToString());
                    }
                    return;
                }
            CmdHelp(param);
        }
    }
}
