using System;

namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pong pong = new Pong();
            pong.Run();
            Console.ReadKey();
            Console.CursorVisible = false;
        }
    }
}

