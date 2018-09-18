using Microsoft.Xna.Framework.Content;

namespace MarioPirates
{
    public sealed class EnemySpriteFactory
    {
        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        //private Texture2D koopaSpriteSheet;
        //private Texture2D goombaSpriteSheet;

        private EnemySpriteFactory()
        { }

        public void LoadTextures(ContentManager content)
        {
        }

        public ISprite CreateGoombaSprite()
        {
            return null;
        }
    }
}
