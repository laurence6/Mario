using System.Collections.Generic;

namespace MarioPirates
{
    internal class PipeTop : GameObjectRigidBody
    {
        public readonly string ToLevel = null;

        public PipeTop(int dstX, int dstY) : base(dstX, dstY, Constants.PIPE_TOP_WIDTH * 2, Constants.PIPE_TOP_HEIGHT * 2) // 32, 15
        {
            Sprite = SpriteFactory.Ins.CreateSprite("pipelinetop");
        }

        public PipeTop(int dstX, int dstY, Dictionary<string, string> Params) : this(dstX, dstY)
        {
            ToLevel = Params["ToLevel"];
        }
    }
}
