using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal static class Time
    {
        public static float Now { get; private set; }

        public static void Update(GameTime gameTime) => Now = (float)gameTime.TotalGameTime.TotalMilliseconds;
    }
}
