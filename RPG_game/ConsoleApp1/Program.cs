using System;
using System.Collections.Generic;
using System.Linq;

namespace TextRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Game game = new Game();
            game.Start();
        }
    }
}