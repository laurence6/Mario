using System.Collections.Generic;

namespace MarioPirates
{
    internal class BrokenBlock : Block
    {
        public BrokenBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite(Constants.BROKEN_BLOCK_SPRITE))
        {
        }
    }
}
