using System;

namespace MarioPirates
{
    internal class GameObjectParam
    {
        public string TypeName = null;
        public int[] Location = null;
        public string State = null;
        public bool? IsStatic = null;

        public GameObject ToGameObject()
        {
            var t = Type.GetType("MarioPirates." + TypeName);
            var param = State != null
                ? (new object[] { Location[0], Location[1], State })
                : (new object[] { Location[0], Location[1] });
            var obj = (GameObject)Activator.CreateInstance(t, param);
            obj.IsStatic = IsStatic ?? obj.IsStatic;
            return obj;
        }
    }
}
