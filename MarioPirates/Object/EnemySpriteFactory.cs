namespace MarioPirates
{
    public sealed class EnemySpriteFactory
    {
        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        private EnemySpriteFactory()
        { }

        public ISprite CreateGoombaSprite(int locationX, int locationY)
        {
            return new GoombaSprite(locationX, locationY);
        }
    }
}
