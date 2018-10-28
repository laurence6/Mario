namespace MarioPirates
{
    internal class Castle : GameObjectRigidBody
    {
        private const int castleWidth = 80, castleHeight = 80;

        public Castle(int dstX, int dstY) : base(dstX, dstY, castleWidth*2, castleHeight*2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("castle");
        }
    }
}
