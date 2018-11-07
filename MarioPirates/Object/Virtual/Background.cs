namespace MarioPirates
{
    internal class Background : GameObject
    {
        public Background() : this(0, 0)
        {
        }

        public Background(int X, int Y) : base(X, Y, Constants.BACKGROUND_WIDTH, Constants.BACKGROUND_HEIGHT)
        {
            IsLocationAbsolute = true;
            Sprite = SpriteFactory.Ins.CreateSprite("background");
        }
    }
}
