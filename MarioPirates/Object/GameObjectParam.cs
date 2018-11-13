using System;
using System.Collections.Generic;

namespace MarioPirates
{
    internal class GameObjectParam
    {
        public string TypeName = null;
        public int[] Location = null;
        public MotionEnum? Motion = null;
        public WorldForce? Force = null;
        public float? Mass = null;
        public Dictionary<string, string> Params = null;

        public IGameObject ToGameObject()
        {
            var objectType = Type.GetType(Constants.GAME_NAMESPACE + TypeName);
            var param = Params != null
                ? (new object[] { Location[0], Location[1], Params })
                : (new object[] { Location[0], Location[1] });
            var gameObject = (IGameObject)Activator.CreateInstance(objectType, param);

            if (gameObject is GameObjectRigidBody gameObjectRigidBody)
                SetRigidBodyParam(gameObjectRigidBody);

            return gameObject;
        }

        private void SetRigidBodyParam(GameObjectRigidBody gameObject)
        {
            if (Motion.HasValue)
                gameObject.RigidBody.Motion = Motion.Value;
            if (Force.HasValue)
                gameObject.RigidBody.ApplyForce(Force.Value);
            if (Mass.HasValue)
                gameObject.RigidBody.Mass = Mass.Value;
        }
    }
}
