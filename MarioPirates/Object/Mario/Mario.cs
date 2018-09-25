namespace MarioPirates
{
    internal class Mario : GameObject
    {
        public MarioState State { get; set; }

        public Mario(int dstX, int dstY)
        {
            Location.X = dstX;
            Location.Y = dstY;
            State = new MarioStateSmallRightIdle(this);
        }
    }
}
