using System.Collections.Generic;

namespace MarioPirates
{
    internal class UnderwaterBackground : GameObject
    {
        public UnderwaterBackground(int X, int Y, Dictionary<string, string> Params) : base(X, Y, Constants.UNDERWATERBACKGROUND_WIDTH, Constants.UNDERWATERBACKGROUND_WIDTH)
        {
            IsLocationAbsolute = true;
            Sprite = SpriteFactory.Ins.CreateSprite(Params[Constants.UNDERWATERBACKGROUND_PARAM]);
        }
    }
}
