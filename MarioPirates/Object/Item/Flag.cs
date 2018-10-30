namespace MarioPirates
{
    internal class Flag : GameObjectRigidBody
    {
        private const int flagWidth = 33, flagHeight = 168;

        public Flag(int dstX, int dstY) : base(dstX, dstY, flagWidth * 2, flagHeight * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite("flag");
        }
    }
}
