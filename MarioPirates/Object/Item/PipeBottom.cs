using System.Collections.Generic;

namespace MarioPirates
{
    internal class PipeBottom : GameObjectRigidBody
    {
        public const int pipeWidth = 32;

        public PipeBottom(int dstX, int dstY, Dictionary<string, string> Params) : base(dstX, dstY, pipeWidth * 2, int.Parse(Params["Height"]) * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("pipelinebottom");
        }
    }
}
