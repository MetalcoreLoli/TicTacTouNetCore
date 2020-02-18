using System;
using TicTacTou.Game.Core;
using TicTacTou.Game.Actors;

namespace TicTacTou.Game
{
    ///<summary>
    /// Игрованя карта
    ///</summary>
    internal class Map
    {
        #region Public Properties
        ///<summary>
        /// Высота
        ///</summary>
        public Int32 Height { get; set; }
        
        ///<summary>
        /// Ширина
        ///</summary>
        public Int32 Width  { get; set; }

        ///<summary>
        /// Игровая доска
        ///</summary>
        public Cell[] Board { get; private set; }
        #endregion

        #region Constructors
        public Map(int width, int height)
        {
            Height = height;
            Width =  width;

            Board = InitMap(Width, Height); 
        }
        #endregion

        #region Public Methods
        
        ///<summary>
        /// Получение ячейки с доски
        ///</summary>
        public Cell GetCell(Int32 x, Int32 y)
        {
            Cell cell = Board[x + Width * y];    
            if (cell == null)
                throw new NullReferenceException("Ячейка не найдена");
            return cell;
        }

        ///<summary>
        /// Установка игрока символа в ячейку 
        ///</summary>
        public void SetActorSymbolToBoard(Actor actor, Vector position)
        {
            if (position.X % 2 != 0)
                position.X++;
            if (position.Y % 2 != 0)
                position.Y++;
            Board[position.X + Width * position.Y].Symbol = actor.Symbol; 
        }

        ///<summary>
        /// Метод отрисовывает карту
        ///</summary>
        public void Draw()
        {
            Board.RangeWithOutOffset();
        }
        #endregion
        
        #region Private Members
        
        private Cell[] InitMap(int width, int height)
        {
            Cell[] temp = new Cell[width * height];
            for  (int y = 0; y < height; y++)
                for(int x = 0; x < width; x++)
                    temp[x + width * y] = new Cell(' ', x, y);

            temp = SetBorders(temp);
            return temp;
        }

        private Cell[] SetBorders(Cell[] board)
        {
            Cell[] temp = board;
            for  (int y = 0; y < Height; y++)
                for(int x = 0; x < Width; x++)
                {
                    Cell cell = temp[x + Width * y];
                    if (cell.Position.X % 2 != 0)
                        cell.Symbol = '|';

                    if (cell.Position.Y % 2 != 0)
                        cell.Symbol = '-';

                    if (cell.Position.X % 2 != 0 && cell.Position.Y % 2 != 0)
                        cell.Symbol = '+';
                }
            return temp;
        }
        #endregion
    }
}