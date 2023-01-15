using System;

namespace FlatWhite
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new FlatWhite())
                game.Run();
        }
    }
}
