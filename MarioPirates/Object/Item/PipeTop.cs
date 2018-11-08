using System.Collections.Generic;

namespace MarioPirates
{
    internal class PipeTop : GameObjectRigidBody
    {
        public readonly string ToLevel = null;

        public PipeTop(int dstX, int dstY) : base(dstX, dstY, Constants.PIPE_TOP_WIDTH * 2, Constants.PIPE_TOP_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.PIPE_TOP_SPRITE);
        }

        public PipeTop(int dstX, int dstY, Dictionary<string, string> Params) : this(dstX, dstY)
        {
            ToLevel = Params[Constants.TO_LEVEL_PARAM];
        }
    }
}
