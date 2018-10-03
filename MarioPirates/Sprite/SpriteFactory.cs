using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    using static Common;

    internal sealed class SpriteFactory
    {
        public static SpriteFactory Instance { get; } = new SpriteFactory();

        private class SpriteParam
        {
            public string TextureName = "";
            public int[] Size = null;
            public int[] Frames = null;

            public Sprite ToSprite()
            {
                var frames = new Point[Frames.Length / 2];
                for (var i = 0; i < frames.Length; i++)
                    frames[i] = P(Frames[i * 2], Frames[i * 2 + 1]);
                return new Sprite(TextureName, P(Size[0], Size[1]), frames);
            }
        };

        private Dictionary<string, SpriteParam> spriteParam;

        private SpriteFactory()
        {
            Reset();
        }

        public void Reset()
        {
            var s = new JavaScriptSerializer();
            spriteParam = s.Deserialize<Dictionary<string, SpriteParam>>(ReadAllText("Sprite\\SpritesData.json"));
        }

        public Sprite CreateSprite(string spriteName)
        {
            if (spriteParam.TryGetValue(spriteName, out var param))
                return param.ToSprite();
            Console.Error.WriteLine("Couldn't find sprite " + spriteName);
            return null;
        }

        public Sprite CreateSpriteMario(string spriteName)
        {
            var smallMarioSize = P(17, 15);
            var bigMarioSize = P(16, 32);
            var starSmallMarioSize = P(16, 16);
            var deadMarioSize = P(15, 14);
            switch (spriteName)
            {
                case "small_crouch_left":
                    return new Sprite("smallmario", smallMarioSize, P(0, 0));

                case "small_jump_left":
                    return new Sprite("smallmario", smallMarioSize, P(0, 0));

                case "small_run_left":
                    return new Sprite("smallmario", smallMarioSize, P(120, 0), P(90, 0), P(60, 0), P(90, 0));

                case "small_idle_left":
                    return new Sprite("smallmario", smallMarioSize, P(150, 0));

                case "small_idle_right":
                    return new Sprite("smallmario", smallMarioSize, P(180, 0));

                case "small_run_right":
                    return new Sprite("smallmario", smallMarioSize, P(210, 0), P(240, 0), P(270, 0), P(240, 0));

                case "small_jump_right":
                    return new Sprite("smallmario", smallMarioSize, P(330, 0));

                case "small_crouch_right":
                    return new Sprite("smallmario", smallMarioSize, P(330, 0));

                case "big_crouch_left":
                    return new Sprite("bigmario", bigMarioSize, P(360, 0));

                case "big_jump_left":
                    return new Sprite("bigmario", bigMarioSize, P(0, 0));

                case "big_run_left":
                    return new Sprite("bigmario", bigMarioSize, P(120, 0), P(90, 0), P(60, 0), P(90, 0));

                case "big_idle_left":
                    return new Sprite("bigmario", bigMarioSize, P(150, 0));

                case "big_idle_right":
                    return new Sprite("bigmario", bigMarioSize, P(180, 0));

                case "big_run_right":
                    return new Sprite("bigmario", bigMarioSize, P(210, 0), P(240, 0), P(270, 0), P(240, 0));

                case "big_jump_right":
                    return new Sprite("bigmario", bigMarioSize, P(330, 0));

                case "big_crouch_right":
                    return new Sprite("bigmario", bigMarioSize, P(390, 0));

                case "fire_crouch_left":
                    return new Sprite("firemario", bigMarioSize, P(360, 0));

                case "fire_jump_left":
                    return new Sprite("firemario", bigMarioSize, P(0, 0));

                case "fire_run_left":
                    return new Sprite("firemario", bigMarioSize, P(120, 0), P(90, 0), P(60, 0), P(90, 0));

                case "fire_idle_left":
                    return new Sprite("firemario", bigMarioSize, P(150, 0));

                case "fire_idle_right":
                    return new Sprite("firemario", bigMarioSize, P(180, 0));

                case "fire_run_right":
                    return new Sprite("firemario", bigMarioSize, P(210, 0), P(240, 0), P(270, 0), P(240, 0));

                case "fire_jump_right":
                    return new Sprite("firemario", bigMarioSize, P(330, 0));

                case "fire_crouch_right":
                    return new Sprite("firemario", bigMarioSize, P(390, 0));

                case "star_small_idle_right":
                    return new Sprite("smallstarpowermario", 3, starSmallMarioSize, P(96, 0), P(96, 48), P(96, 96));

                case "star_small_run_right":
                    return new Sprite("smallstarpowermario", 3, starSmallMarioSize,
                        P(0, 0), P(0, 48), P(0, 96), P(16, 0), P(16, 48), P(16, 96),
                        P(32, 0), P(32, 48), P(32, 96), P(16, 0), P(16, 48), P(16, 96));

                case "star_small_jump_right":
                    return new Sprite("smallstarpowermario", 3, starSmallMarioSize, P(64, 0), P(64, 48), P(64, 96));

                case "star_small_crouch_right":
                    return new Sprite("smallstarpowermario", 3, starSmallMarioSize, P(64, 0), P(64, 48), P(64, 96));

                case "star_big_idle_right":
                    return new Sprite("bigstarpowermario", 3, bigMarioSize, P(96, 0), P(96, 48), P(96, 96));

                case "star_big_run_right":
                    return new Sprite("bigstarpowermario", 3, bigMarioSize,
                        P(0, 0), P(0, 48), P(0, 96), P(16, 0), P(16, 48), P(16, 96),
                        P(32, 0), P(32, 48), P(32, 96), P(16, 0), P(16, 48), P(16, 96));

                case "star_big_jump_right":
                    return new Sprite("bigstarpowermario", 3, bigMarioSize, P(64, 0), P(64, 48), P(64, 96));

                case "star_big_crouch_right":
                    return new Sprite("bigstarpowermario", 3, bigMarioSize, P(80, 0), P(80, 48), P(80, 96));

                case "dead":
                    return new Sprite("deadmario", deadMarioSize, P(0, 0));

                case "star_dead":
                    return new Sprite("smallstarpowermario", 3, starSmallMarioSize, P(80, 0), P(80, 48), P(80, 96));
            }
            Console.Error.WriteLine("Couldn't find sprite " + spriteName);
            return null;
        }

        private static Point[] GenerateFrameLocationArray(Point begin, Point delta, int count)
        {
            var arr = new Point[count];
            for (var i = 0; i < count; i++)
                arr[i] = begin + delta.Mul(i);
            return arr;
        }
    }
}
