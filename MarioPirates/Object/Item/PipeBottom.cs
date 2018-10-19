namespace MarioPirates
{
    internal class PipeBottom : GameObjectRigidBody
    {
        private const int pipeWidth = 28, pipeHeight = 17;

        public PipeBottom(int dstX, int dstY) : base(dstX, dstY, pipeWidth * 2, pipeHeight * 2)
        {
            Sprite = SpriteFactory.CreateSprite("pipelinebottom");
        }
    }
}
