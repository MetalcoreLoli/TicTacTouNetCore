
namespace TicTacTou.Game.Core
{
    internal interface IRenderable
    {
        char Symbol { get; set; }
        Vector Position { get; set; }
        
        System.ConsoleColor Color { get; set; }
        System.ConsoleColor BackColor { get; set; }

    }
}
