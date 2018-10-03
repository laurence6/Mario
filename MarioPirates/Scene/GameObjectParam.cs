using System;

namespace MarioPirates
{
    internal sealed class GameObjectParam
    {
        public string TypeName = null;
        public int[] Location = null;
        public bool IsStatic = false;

        public GameObject ToGameObject() =>
            (GameObject)Activator.CreateInstance(
                 Type.GetType("MarioPirates." + TypeName), new object[] { Location[0], Location[1] });
    }
}
