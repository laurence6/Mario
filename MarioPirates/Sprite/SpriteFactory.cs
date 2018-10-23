using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class SpriteFactory
    {
        private class SpriteParam
        {
            public string TextureName = null;
            public int[] Size = null;
            public int[] Frames = null;
            public int AccelerateRate = 1;

            public Sprite ToSprite(Dictionary<string, Texture2D> textures)
            {
                var frames = new Point[Frames.Length / 2];
                for (var i = 0; i < frames.Length; i++)
                    frames[i] = new Point(Frames[i * 2], Frames[i * 2 + 1]);
                return new Sprite(textures[TextureName], new Point(Size[0], Size[1]), frames, AccelerateRate);
            }
        }

        public static readonly SpriteFactory Ins = new SpriteFactory();

        private SpriteFactory() { }

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        private Dictionary<string, SpriteParam> spriteParam;

        public void LoadContent(ContentManager content)
        {
            spriteParam = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteParam>>(ReadAllText("Content\\SpritesData.json"));
            spriteParam.ForEach((name, param) => param.TextureName.NotNullThen(() => textures.AddIfNotExist(param.TextureName, null)));
            textures.Keys.ToList().ForEach(name => textures[name] = content.Load<Texture2D>(name));
        }

        public Sprite CreateSprite(string spriteName) => spriteParam[spriteName].ToSprite(textures);
    }
}
