using Microsoft.Xna.Framework;
using System;

namespace MarioPirates
{
    using static Common;

    internal sealed class SpriteFactory
    {
        public static SpriteFactory Instance { get; private set; } = new SpriteFactory();

        private SpriteFactory() { }

        public Sprite CreateSprite(string spriteName)
        {
            switch (spriteName)
            {
                case "coins":
                    return new Sprite("coins", P(30, 14), GenerateFrameLocationArray(P(0, 0), P(30, 0), 4));

                case "flower":
                    return new Sprite("flower", P(30, 16), GenerateFrameLocationArray(P(0, 0), P(30, 0), 4));

                case "greenmushroom":
                    return new Sprite("greenmushroom", P(16, 16), P(0, 0));

                case "pipe":
                    return new Sprite("pipeline", P(32, 32), P(0, 0));

                case "redmushroom":
                    return new Sprite("redmushroom", P(16, 16), P(0, 0));

                case "stars":
                    return new Sprite("stars", P(30, 16), GenerateFrameLocationArray(P(0, 0), P(30, 0), 4));

                case "brickblock":
                    return new Sprite("brickblock", P(16, 16), P(0, 0));

                case "brokenblock":
                    return new Sprite("brokenblock", P(16, 16), P(0, 0));

                case "brownblock":
                    return new Sprite("brownblock", P(16, 16), P(0, 0));

                case "hiddenblock":
                    return new Sprite("hiddenblock", P(16, 16), P(0, 0));

                case "orangeblock":
                    return new Sprite("orangeblock", P(16, 16), P(0, 0));

                case "questionblock":
                    return new Sprite("questionblock", P(16, 16), P(0, 0));

                case "goomba":
                    return new Sprite("goomba", P(30, 16), GenerateFrameLocationArray(P(0, 0), P(30, 0), 2));

                case "koopa":
                    return new Sprite("koopa", P(30, 24), GenerateFrameLocationArray(P(0, 0), P(30, 0), 9));
            }
            Console.Error.WriteLine("Couldn't find sprite " + spriteName);
            return null;
        }

        public Sprite CreateSpriteMario(string spriteName)
        {
            switch (spriteName)
            {
                case "small_crouch_left":
                    return new Sprite("smallmario", P(30, 15), P(0, 0));

                case "small_jump_left":
                    return new Sprite("smallmario", P(30, 15), P(0, 0));

                case "small_run_left":
                    return new Sprite("smallmario", P(30, 15), P(120, 0), P(90, 0), P(60, 0), P(90, 0));

                case "small_idle_left":
                    return new Sprite("smallmario", P(30, 15), P(150, 0));

                case "small_idle_right":
                    return new Sprite("smallmario", P(30, 15), P(180, 0));

                case "small_run_right":
                    return new Sprite("smallmario", P(30, 15), P(210, 0), P(240, 0), P(270, 0), P(240, 0));

                case "small_jump_right":
                    return new Sprite("smallmario", P(30, 15), P(330, 0));

                case "small_crouch_right":
                    return new Sprite("smallmario", P(30, 15), P(330, 0));

                case "big_crouch_left":
                    return new Sprite("leftcrouchbigmario", P(16, 22), P(0, 0));

                case "big_jump_left":
                    return new Sprite("bigmario", P(30, 33), P(0, 0));

                case "big_run_left":
                    return new Sprite("bigmario", P(30, 33), P(120, 0), P(90, 0), P(60, 0), P(90, 0));

                case "big_idle_left":
                    return new Sprite("bigmario", P(30, 33), P(150, 0));

                case "big_idle_right":
                    return new Sprite("bigmario", P(30, 33), P(180, 0));

                case "big_run_right":
                    return new Sprite("bigmario", P(30, 33), P(210, 0), P(240, 0), P(270, 0), P(240, 0));

                case "big_jump_right":
                    return new Sprite("bigmario", P(30, 33), P(330, 0));

                case "big_crouch_right":
                    return new Sprite("rightcrouchbigmario", P(16, 22), P(0, 0));

                case "fire_crouch_left":
                    return new Sprite("leftcrouchfiremario", P(16, 22), P(0, 0));

                case "fire_jump_left":
                    return new Sprite("firemario", P(30, 33), P(0, 0));

                case "fire_run_left":
                    return new Sprite("firemario", P(30, 33), P(120, 0), P(90, 0), P(60, 0), P(90, 0));

                case "fire_idle_left":
                    return new Sprite("firemario", P(30, 33), P(150, 0));

                case "fire_idle_right":
                    return new Sprite("firemario", P(30, 33), P(180, 0));

                case "fire_run_right":
                    return new Sprite("firemario", P(30, 33), P(210, 0), P(240, 0), P(270, 0), P(240, 0));

                case "fire_jump_right":
                    return new Sprite("firemario", P(30, 33), P(330, 0));

                case "fire_crouch_right":
                    return new Sprite("rightcrouchfiremario", P(16, 22), P(0, 0));

                case "dead":
                    return new Sprite("deadmario", P(15, 14), P(0, 0));
            }
            Console.Error.WriteLine("Couldn't find sprite " + spriteName);
            return null;
        }

        private Point[] GenerateFrameLocationArray(Point begin, Point delta, int count)
        {
            var arr = new Point[count];
            for (var i = 0; i < count; i++)
            {
                arr[i].X = begin.X + delta.X * i;
                arr[i].Y = begin.Y + delta.Y * i;
            }
            return arr;
        }
    }
}
