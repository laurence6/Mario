using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioPirates
{
    public sealed class EnemySpriteFactory
    {
        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        private Texture2D koopaSpriteSheet;
        private Texture2D goombaSpriteSheet;

        private EnemySpriteFactory()
        { }

        public void LoadTextures(ContentManager content)
        {
            goombaSpriteSheet = content.Load<Texture2D>("goomba");
        }

        public ISprite createGoombaSprite()
        {
            return new GoombaSprite();
        }
    }
}
