using System.Collections.Generic;

namespace MarioPirates
{
    internal class QuestionBlock : Block
    {
        public string Powerup { get; set; }

        public QuestionBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("questionblock"))
        {
            this.Powerup = Params["Powerup"];
        }
    }
}
