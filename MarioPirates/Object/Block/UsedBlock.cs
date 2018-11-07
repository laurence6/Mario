using System.Collections.Generic;

namespace MarioPirates
{
    internal class UsedBlock : Block
    {
        public override bool IsUsed => State != BlockState.Hidden;

        public UsedBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("usedblock"))
        {
        }
    }
}
