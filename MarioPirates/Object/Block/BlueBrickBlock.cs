using System.Collections.Generic;

namespace MarioPirates
{
    internal class BlueBrickBlock : Block
    {
        public string Powerup { get; set; }

        public BlueBrickBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("bluebrickblock"))
        {
            if (Params.ContainsKey("Powerup"))
                Powerup = Params["Powerup"];
        }
    }
}
