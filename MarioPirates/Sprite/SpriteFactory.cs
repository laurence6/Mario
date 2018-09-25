using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal sealed class SpriteFactory
    {
        public static SpriteFactory Instance { get; private set; } = new SpriteFactory();

        private SpriteFactory() { }

        public Sprite CreateSprite(string spriteName)
        {
            switch (spriteName)
            {
                case "coins":
                    return new Sprite("coins", new Point(30, 24), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 4));

                case "flower":
                    return new Sprite("flower", new Point(30, 20), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 4));

                case "greenmushroom":
                    return new Sprite("greenmushroom", new Point(28, 30), new Point(0, 0));

                case "pipe":
                    return new Sprite("pipeline", new Point(64, 64), new Point(0, 0));

                case "redmushroom":
                    return new Sprite("redmushroom", new Point(28, 30), new Point(0, 0));

                case "stars":
                    return new Sprite("stars", new Point(30, 24), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 4));

                case "brickblock":
                    return new Sprite("brickblock", new Point(16, 16), new Point(0, 0));

                case "brokenblock":
                    return new Sprite("brokenblock", new Point(16, 16), new Point(0, 0));

                case "brownblock":
                    return new Sprite("brownblock", new Point(16, 16), new Point(0, 0));

                case "hiddenblock":
                    return new Sprite("hiddenblock", new Point(16, 16), new Point(0, 0));

                case "orangeblock":
                    return new Sprite("orangeblock", new Point(16, 16), new Point(0, 0));

                case "questionblock":
                    return new Sprite("questionblock", new Point(16, 16), new Point(0, 0));

                case "goomba":
                    return new Sprite("goomba", new Point(30, 20), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 2));

                case "koopa":
                    return new Sprite("turtles", new Point(30, 24), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 9));

                case "mario_small_crouch_left":
                    return new Sprite("smallmario", new Point(30, 15), new Point(0, 0));

                case "mario_small_jump_left":
                    return new Sprite("smallmario", new Point(30, 15), new Point(0, 0));

                case "mario_small_run_left":
                    return new Sprite("smallmario", new Point(30, 15), new Point(120, 0), new Point(90, 0), new Point(60, 0), new Point(90, 0));

                case "mario_small_idle_left":
                    return new Sprite("smallmario", new Point(30, 15), new Point(150, 0));

                case "mario_small_idle_right":
                    return new Sprite("smallmario", new Point(30, 15), new Point(180, 0));

                case "mario_small_run_right":
                    return new Sprite("smallmario", new Point(30, 15), new Point(210, 0), new Point(240, 0), new Point(270, 0), new Point(240, 0));

                case "mario_small_jump_right":
                    return new Sprite("smallmario", new Point(30, 15), new Point(330, 0));

                case "mario_small_crouch_right":
                    return new Sprite("smallmario", new Point(30, 15), new Point(330, 0));

                case "mario_big_crouch_left":
                    return new Sprite("leftcrouchbigmario", new Point(16, 22), new Point(0, 0));

                case "mario_big_jump_left":
                    return new Sprite("bigmario", new Point(30, 33), new Point(0, 0));

                case "mario_big_run_left":
                    return new Sprite("bigmario", new Point(30, 33), new Point(120, 0), new Point(90, 0), new Point(60, 0), new Point(90, 0));

                case "mario_big_idle_left":
                    return new Sprite("bigmario", new Point(30, 33), new Point(150, 0));

                case "mario_big_idle_right":
                    return new Sprite("bigmario", new Point(30, 33), new Point(180, 0));

                case "mario_big_run_right":
                    return new Sprite("bigmario", new Point(30, 33), new Point(210, 0), new Point(240, 0), new Point(270, 0), new Point(240, 0));

                case "mario_big_jump_right":
                    return new Sprite("bigmario", new Point(30, 33), new Point(330, 0));

                case "mario_big_crouch_right":
                    return new Sprite("rightcrouchbigmario", new Point(16, 22), new Point(0, 0));

                case "mario_fire_crouch_left":
                    return new Sprite("leftcrouchfiremario", new Point(16, 22), new Point(0, 0));

                case "mario_fire_jump_left":
                    return new Sprite("firemario", new Point(30, 33), new Point(0, 0));

                case "mario_fire_run_left":
                    return new Sprite("firemario", new Point(30, 33), new Point(120, 0), new Point(90, 0), new Point(60, 0), new Point(90, 0));

                case "mario_fire_idle_left":
                    return new Sprite("firemario", new Point(30, 33), new Point(150, 0));

                case "mario_fire_idle_right":
                    return new Sprite("firemario", new Point(30, 33), new Point(180, 0));

                case "mario_fire_run_right":
                    return new Sprite("firemario", new Point(30, 33), new Point(210, 0), new Point(240, 0), new Point(270, 0), new Point(240, 0));

                case "mario_fire_jump_right":
                    return new Sprite("firemario", new Point(30, 33), new Point(330, 0));

                case "mario_fire_crouch_right":
                    return new Sprite("rightcrouchfiremario", new Point(16, 22), new Point(0, 0));

                case "mario_dead":
                    return new Sprite("deadmario", new Point(15, 14), new Point(0, 0));

                default:
                    return null;
            }
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
