using System.Collections.Generic;

namespace MarioPirates
{
    internal class BlueBrickBlock : Block
    {
        public string Powerup { get; set; }

        public BlueBrickBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite(Constants.BLUE_BRICK_BLOCK_SPRITE))
        {
            if (Params.ContainsKey(Constants.POWERUP_PARAM))
                Powerup = Params[Constants.POWERUP_PARAM];
        }
    }
}
