using System;

namespace MarioPirates
{
    internal class GameObjectParam
    {
        public string TypeName = null;
        public int[] Location = null;
        public string State = null;
        public MotionEnum? Motion = null;
        public WorldForce? Force = null;
        public float? Mass = null;

        public GameObject ToGameObject()
        {
            var t = Type.GetType("MarioPirates." + TypeName);
            var param = State != null
                ? (new object[] { Location[0], Location[1], State })
                : (new object[] { Location[0], Location[1] });
            var obj = (GameObject)Activator.CreateInstance(t, param);

            if (obj is GameObjectRigidBody or)
                SetRigidBodyParam(or);

            return obj;
        }

        private void SetRigidBodyParam(GameObjectRigidBody obj)
        {
            if (Motion.HasValue)
                obj.RigidBody.Motion = Motion.Value;
            if (Force.HasValue)
                obj.RigidBody.ApplyForce(Force.Value);
            if (Mass.HasValue)
                obj.RigidBody.Mass = Mass.Value;
        }
    }
}
