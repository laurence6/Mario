using System.Collections.Generic;

namespace MarioPirates
{
    internal class BlueBrokenBlock : Block
    {
        public BlueBrokenBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite(Constants.BLUE_BROKEN_BLOCK_SPRITE))
        {
        }
    }
}
