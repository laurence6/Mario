namespace MarioPirates
{
    public class Goomba : GameObject
    {
        private enum State { normal, flipped, stomped };

        private State state = State.normal;

        private int vx = 1;

        public Goomba(int x, int y)
        {
            location.X = x;
            location.Y = y;
            size.X = 60;
            size.Y = 40;
            sprite = SpriteFactory.Instance.CreateSprite("goomba");
        }

        public override void Update()
        {
            vx = (location.X == 0) ? 1 : (location.X == 800 - 48) ? -1 : vx;
            location.X += vx;
            base.Update();
        }
    }
}
