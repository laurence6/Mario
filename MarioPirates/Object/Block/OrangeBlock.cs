using System.Collections.Generic;

namespace MarioPirates
{
    internal class OrangeBlock : Block
    {
        public OrangeBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("orangeblock"))
        {
        }
    }
}
