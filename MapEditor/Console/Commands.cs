using Microsoft.Xna.Framework.Input;
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
            var objectParam = new JavaScriptSerializer().Deserialize<GameObjectParam>(param);
            objectParam.Location = new int[] { (int)Camera.Ins.Offset, 0 };
            Scene.Ins.AddGameObject(Scene.Ins.Model.AddGameObjectParam(objectParam));
        }

        public static void Write(string param)
        {
            Scene.Ins.Model.Write();
        }

        public static void Use(string param)
        {
            Scene.Ins.UseScene(param);
        }
    }
}
