using System.Collections.Generic;

namespace MarioPirates
{
    internal class PipeBottom : GameObjectRigidBody
    {
        public PipeBottom(int dstX, int dstY, Dictionary<string, string> Params) : base(dstX, dstY, Constants.PIPE_BOTTOM_WIDTH * 2, int.Parse(Params["Height"]) * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("pipelinebottom");
        }
    }
}
