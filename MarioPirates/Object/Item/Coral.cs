namespace MarioPirates
{
    internal class Coral : GameObjectRigidBody
    {
        public Coral(int dstX, int dstY) : base(dstX, dstY, Constants.CORAL_WIDTH * 2, Constants.CORAL_HEIGHT * 2)
        {
            Sprite = SpriteFactory.Ins.CreateSprite(Constants.CORAL_SPRITE);
        }
    }
}
