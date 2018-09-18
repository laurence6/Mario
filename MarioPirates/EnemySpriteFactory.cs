using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace MarioPirates
{
    public class EnemySpriteFactory
    {
        private Texture2D koopaSpriteSheet;
        private Texture2D goombaSpriteSheet;
        private static EnemySpriteFactory instance = new EnemySpriteFactory();
        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemySpriteFactory()
        {
        }
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
