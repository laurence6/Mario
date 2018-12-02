using System;

namespace MarioPirates
{
#if WINDOWS || LINUX
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            new GameMario().Run();
        }
    }
#endif
}
