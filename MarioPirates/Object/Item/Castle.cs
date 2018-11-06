namespace MarioPirates
{
    internal class Castle : GameObjectRigidBody
    {
        public Castle(int dstX, int dstY) : base(dstX, dstY, Constants.CASTLE_WIDTH * 2, Constants.CASTLE_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("castle");
        }
    }
}
