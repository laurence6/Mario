using System;

namespace MarioPirates
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (var game = new GameMario())
                game.Run();
        }
    }
#endif
}
