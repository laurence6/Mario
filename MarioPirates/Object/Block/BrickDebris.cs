using System.Collections.Generic;

namespace MarioPirates
{
    internal class BrickDebris : GameObjectRigidBody
    {
        public BrickDebris(int dstX, int dstY, Dictionary<string, string> Params) : base(dstX, dstY, Constants.BRICK_DEBRIS_WIDTH * 2, Constants.BRICK_DEBRIS_HEIGHT * 2) // 8, 8
        {
            Sprite = SpriteFactory.Ins.CreateSprite("brickdebris" + Params["Position"]);
            RigidBody.Mass = Constants.BRICK_DEBRIS_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.None;
        }
    }
}