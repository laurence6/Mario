using System.Collections.Generic;

namespace MarioPirates
{
    internal class UsedBlock : Block
    {
        protected override BlockState State
        {
            get => base.State;
            set
            {
                value = value == BlockState.Hidden ? BlockState.Hidden : BlockState.Normal;
                base.State = value;
            }
        }

        public UsedBlock(int dstX, int dstY, Dictionary<string, string> Params)
            : base(dstX, dstY, Params, SpriteFactory.Ins.CreateSprite("usedblock"))
        {
        }
    }
}
