using System.Collections.Generic;

namespace MarioPirates
{
    internal class BrickDebris : Block
    {
        protected override bool IsDebris => State != BlockState.Hidden;

        public BrickDebris(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("brickdebris"))
        {
        }
    }
}
