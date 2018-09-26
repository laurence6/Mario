namespace MarioPirates
{
    public class Mario : GameObject
    {
        public MarioState State;

        public Mario(int dstX, int dstY)
        {
            location.X = dstX;
            location.Y = dstY;
            State = new MarioStateSmallRightIdle(this);
        }
    }
}
