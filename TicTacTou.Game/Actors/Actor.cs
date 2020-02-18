using System;
using TicTacTou.Game.Core;

namespace TicTacTou.Game.Actors
{
    internal class Actor : IRenderable
    {
        #region Public Properties
        ///<summary>
        /// Символ актера 
        ///</summary>
        public Char Symbol { get; set; }

        ///<summary>
        /// Позиция актера 
        ///</summary>
        public Vector Position { get; set; }

        
        ///<summary>
        /// Имя актера 
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// Цвет актeра в ячейки
        ///</summary>
        public ConsoleColor Color { get; set; }
        
        ///<summary>
        /// Цвет фона актeра в ячейки
        ///</summary>
        public ConsoleColor BackColor { get; set; }
        #endregion

        #region Constructors
        public Actor(char symbol, Vector position)
            : this ("Actor", symbol, position)
        {
        }

        public Actor(char symbol, Vector position, ConsoleColor color, ConsoleColor backColor)
            : this ("Actor", symbol, position, color, backColor)
        {
        }


        public Actor(
                string name, 
                char symbol, 
                Vector position, 
                ConsoleColor color = ConsoleColor.White, 
                ConsoleColor backColor = ConsoleColor.Black)
        {
            Name = name;
            Symbol = symbol;
            Position = position;
        }
        #endregion
    }
}
