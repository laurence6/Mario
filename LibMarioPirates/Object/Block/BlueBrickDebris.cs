using System.Collections.Generic;

namespace MarioPirates
{
    internal class BlueBrickDebris : GameObjectRigidBody
    {
        public BlueBrickDebris(int dstX, int dstY, Dictionary<string, string> Params) : base(dstX, dstY, Constants.BRICK_DEBRIS_WIDTH * 2, Constants.BRICK_DEBRIS_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.BLUE_BRICK_DEBRIS_SPRITE + Params[Constants.POSITION_PARAM]);
            RigidBody.Mass = Constants.BRICK_DEBRIS_MASS;
            RigidBody.CollisionLayerMask = CollisionLayer.None;
        }
    }
}
