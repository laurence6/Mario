using System.Collections.Generic;

namespace MarioPirates
{
    internal class Background : GameObject
    {
        public Background(int X, int Y, Dictionary<string, string> Params) : base(X, Y, Constants.BACKGROUND_WIDTH, Constants.BACKGROUND_HEIGHT)
        {
            IsLocationAbsolute = true;
            Sprite = SpriteFactory.Ins.CreateSprite(Params["Background"]);
        }
    }
}
