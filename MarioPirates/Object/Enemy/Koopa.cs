namespace MarioPirates
{

    class Koopa : GameObject
    {
        public Koopa(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size.X = 60;
            size.Y = 48;
            sprite = SpriteFactory.Instance.CreateSprite("koopa");
        }
    }
}
