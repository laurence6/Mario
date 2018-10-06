namespace MarioPirates
{
    internal class Pipe : GameObjectRigidBody
    {
        private const int pipeWidth = 32, pipeHeight = 32;

        public Pipe(int dstX, int dstY) : base(dstX, dstY, pipeWidth * 2, pipeHeight * 2)
        {
            Sprite = SpriteFactory.CreateSprite("pipe");
        }
    }
}
