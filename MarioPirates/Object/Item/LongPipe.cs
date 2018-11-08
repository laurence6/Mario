namespace MarioPirates
{
    internal class LongPipe : GameObjectRigidBody
    {
        public LongPipe(int dstX, int dstY) : base(dstX, dstY, Constants.LONG_PIPE_WIDTH * 2, Constants.LONG_PIPE_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("longpipe");
        }
    }
}
