using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class SpriteFactory
    {
        private class SpriteTextureParam
        {
            public string TextureName = null;
            public int[] Size = null;
            public int[] Frames = null;
            public int Depth = 0;
            public int AccelerateRate = 1;

            public SpriteTexture ToSprite(Dictionary<string, Texture2D> textures)
            {
                var frames = new Point[Frames.Length / 2];
                for (var i = 0; i < frames.Length; i++)
                    frames[i] = new Point(Frames[i * 2], Frames[i * 2 + 1]);
                return new SpriteTexture(textures[TextureName], new Point(Size[0], Size[1]), frames, Depth, AccelerateRate);
            }
        }

        public static readonly SpriteFactory Ins = new SpriteFactory();

        private SpriteFactory() { }

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        private SpriteFont hudFont;
        private SpriteFont promptingPointsFont;

        private Dictionary<string, SpriteTextureParam> spriteTextureParam;

        public void LoadContent(ContentManager content)
        {
            spriteTextureParam = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteTextureParam>>(ReadAllText(Constants.CONTENT_PATH_ROOT + Constants.SPRITE_DATA_FILE));
            spriteTextureParam.ForEach((name, param) => param.TextureName.NotNullThen(() => textures.AddIfNotExist(param.TextureName, null)));
            textures.Keys.ToList().ForEach(name => textures[name] = content.Load<Texture2D>(name));

            hudFont = content.Load<SpriteFont>("hud");
            promptingPointsFont = content.Load<SpriteFont>("promptingpoints");
        }

        public SpriteTexture CreateSprite(string spriteName) => spriteTextureParam[spriteName].ToSprite(textures);
        public SpriteText CreateHUDSprite(Func<string> getString) => new SpriteText(hudFont, getString);
        public SpriteText CreatePromptingPointsSprite(Func<string> getString) => new SpriteText(promptingPointsFont, getString);
    }
}
