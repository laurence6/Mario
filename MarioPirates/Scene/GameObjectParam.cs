using System;

namespace MarioPirates
{
    internal sealed class GameObjectParam
    {
        public string TypeName = null;
        public bool IsStatic = false;
        public int[] Location = null;
        public string State = null;

        public GameObject ToGameObject()
        {
            var t = Type.GetType("MarioPirates." + TypeName);

            // Hack: Handle blocks seperately
            return State != null
                ? (GameObject)Activator.CreateInstance(t, new object[] { Location[0], Location[1], State })
                : (GameObject)Activator.CreateInstance(t, new object[] { Location[0], Location[1] });

        }
    }
}
