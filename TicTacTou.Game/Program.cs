using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TicTacTou.Tests")]
namespace TicTacTou.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();  
            new Game().Start();
            Console.ReadKey();
        }
    }
}
