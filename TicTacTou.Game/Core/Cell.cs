using System;

namespace TicTacTou.Game.Core
{
    ///<summary>
    /// Класс описывающий одну клетку в консоли
    ///</summary>
    internal class Cell : IRenderable
    {
        ///<summary>
        /// Символ, что содержится в клетке
        ///</summary>
        public Char Symbol { get; set; }

        ///<summary>
        /// Расволожение клетки в консоли 
        ///</summary>
        public Vector Position { get; set; }

        
        ///<summary>
        /// Цвет символа в ячейки
        ///</summary>
        public ConsoleColor Color { get; set; }
        
        ///<summary>
        /// Цвет фона ячейки
        ///</summary>
        public ConsoleColor BackColor { get; set; }

        public Cell(char symbol, int x, int y)
            : this(symbol, new Vector(x, y))
        {
        }
        
        public Cell(char symbol, int x, int y, ConsoleColor color, ConsoleColor backColor)
            : this (symbol, new Vector(x, y), color, backColor)
        {}
        
        public Cell(char symbol, Vector position, ConsoleColor color = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
        {
            Symbol = symbol;
            Position = position;
            Color = color;
            BackColor = backColor;
        }

    }
}
