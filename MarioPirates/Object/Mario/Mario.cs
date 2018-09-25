namespace MarioPirates
{
    public class Mario : GameObject
    {
        public MarioState State { get; set; }

        public Mario(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            State = new MarioStateSmallRightIdle(this);
        }
    }
}
