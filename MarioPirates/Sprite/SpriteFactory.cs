using Microsoft.Xna.Framework;

namespace MarioPirates
{
    public sealed class SpriteFactory
    {
        public static SpriteFactory Instance { get; private set; } = new SpriteFactory();

        private SpriteFactory() { }

        public Sprite CreateSprite(string spriteName)
        {
            switch (spriteName)
            {
                case "coins": return new Sprite("coins", new Point(30, 24), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 4));

                case "flower": return new Sprite("flower", new Point(30, 20), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 4));

                case "greenmushroom": return new Sprite("greenmushroom", new Point(28, 30), new Point(0, 0));

                case "pipe": return new Sprite("pipeline", new Point(64, 64), new Point(0, 0));

                case "redmushroom": return new Sprite("redmushroom", new Point(28, 30), new Point(0, 0));

                case "stars": return new Sprite("stars", new Point(30, 24), GenerateFrameLocationArray(new Point(0, 0), new Point(30, 0), 4));

                case "mario_big_idle_left": return new Sprite("bigmario", new Point(30, 32), new Point(150, 0));

                // TODO

                default: return null;
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
