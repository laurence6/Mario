using System.Collections.Generic;

namespace MarioPirates
{
    internal class PipeBottom : GameObjectRigidBody
    {
        private const int pipeWidth = 28;

        public PipeBottom(int dstX, int dstY, Dictionary<string, string> Params) : base(dstX, dstY, pipeWidth * 2, int.Parse(Params["Height"]) * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("pipelinebottom");
        }
    }
}
