namespace MarioPirates
{
    internal class Flag : GameObjectRigidBody
    {
        public Flag(int dstX, int dstY) : base(dstX, dstY, Constants.FLAG_WIDTH * 2, Constants.FLAG_HEIGHT * 2) // 33, 168
        {
            Sprite = SpriteFactory.Ins.CreateSprite("flag");
        }
    }
}
