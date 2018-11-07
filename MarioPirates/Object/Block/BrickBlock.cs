using System.Collections.Generic;

namespace MarioPirates
{
    internal class BrickBlock : Block
    {
        public string Powerup { get; set; }

        public BrickBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("brickblock"))
        {
            if (Params.ContainsKey("Powerup"))
                this.Powerup = Params["Powerup"];
        }
    }
}
