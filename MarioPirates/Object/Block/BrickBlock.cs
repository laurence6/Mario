using System.Collections.Generic;

namespace MarioPirates
{
    internal class BrickBlock : Block
    {
        public string Powerup { get; set; }

        public BrickBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite(Constants.BRICK_BLOCK_SPRITE))
        {
            if (Params.ContainsKey(Constants.POWERUP_PARAM))
                Powerup = Params[Constants.POWERUP_PARAM];
        }
    }
}
