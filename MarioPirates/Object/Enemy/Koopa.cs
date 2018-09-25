namespace MarioPirates
{
    internal class Koopa : GameObject
    {
        public Koopa(int x, int y)
        {
            Location.X = x;
            Location.Y = y;
            Size.X = 60;
            Size.Y = 48;
            Sprite = SpriteFactory.Instance.CreateSprite("koopa");
        }
    }
}
