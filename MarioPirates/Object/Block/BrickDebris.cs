using System.Collections.Generic;

namespace MarioPirates
{
    internal class BrickDebris : GameObjectRigidBody
    {
        public const int debrisWidth = 8, debrisHeight = 8;

        public BrickDebris(int dstX, int dstY, Dictionary<string, string> Params) : base(dstX, dstY, debrisWidth * 2, debrisHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("brickdebris" + Params["Position"]);
            RigidBody.Mass = 0.05f;
            RigidBody.CollisionLayerMask = CollisionLayer.None;
        }
    }
}
