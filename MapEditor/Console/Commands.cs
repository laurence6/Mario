using Microsoft.Xna.Framework.Input;
using System;
using System.Web.Script.Serialization;

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
            try
            {
                var objectParam = new JavaScriptSerializer().Deserialize<GameObjectParam>(param);
                objectParam.Location = new int[] { (int)Camera.Ins.Offset, 0 };
                Scene.Ins.Model.AddGameObjectParam(objectParam);
            }
            catch (Exception e)
            {
                Console.Ins.Input(Constants.CONSOLE_ERROR + e.ToString());
            }
        }
    }
}
