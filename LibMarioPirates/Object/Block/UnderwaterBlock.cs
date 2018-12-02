using System.Collections.Generic;

namespace MarioPirates
{
    internal class UnderwaterBlock : Block
    {
        public UnderwaterBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite(Constants.UNDERWATER_BLOCK_SPRITE))
        {
        }
    }
}
