namespace MarioPirates
{
    internal class Background : GameObject
    {
        private const int bkgdWidth = 800, bkgdHeight = 480;

        public Background() : this(0, 0)
        {
        }

        public Background(int X, int Y) : base(X, Y, bkgdWidth, bkgdHeight)
        {
            IsLocationAbsolute = true;
            Sprite = SpriteFactory.Ins.CreateSprite("background");
        }
    }
}
