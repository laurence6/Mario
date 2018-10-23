namespace MarioPirates
{
    internal class PipeTop : GameObjectRigidBody
    {
        private const int pipeWidth = 32, pipeHeight = 15;

        public PipeTop(int dstX, int dstY) : base(dstX, dstY, pipeWidth * 2, pipeHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("pipelinetop");
        }
    }
}
