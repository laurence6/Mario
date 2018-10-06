using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class SpriteFactory
    {
        public static SpriteFactory Instance { get; } = new SpriteFactory();

        private class SpriteParam
        {
            public string TextureName = null;
            public int[] Size = null;
            public int[] Frames = null;
            public int AccelerateRate = 1;

            public Sprite ToSprite()
            {
                var frames = new Point[Frames.Length / 2];
                for (var i = 0; i < frames.Length; i++)
                    frames[i] = new Point(Frames[i * 2], Frames[i * 2 + 1]);
                return new Sprite(TextureName, new Point(Size[0], Size[1]), frames, AccelerateRate);
            }
        };

        private Dictionary<string, SpriteParam> spriteParam;

        private SpriteFactory()
        {
            Reset();
        }

        public void Reset()
        {
            spriteParam = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteParam>>(ReadAllText("Sprite\\SpritesData.json"));
        }

        public Sprite CreateSprite(string spriteName) => spriteParam[spriteName].ToSprite();
    }
}
