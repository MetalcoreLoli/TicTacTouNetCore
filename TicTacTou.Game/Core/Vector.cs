using System;
using System.Linq;
using System.Collections.Generic;

using TicTacTou.Game.Enums;

namespace TicTacTou.Game.Core
{
    ///<summary>
    /// Cтркура хранящаяя координаты
    ///</summary>
    internal struct Vector
    {
        public System.Int32 X { get; set; }
        public System.Int32 Y { get; set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        ///<summary>
        /// Преобразование строки в вектор
        /// формаt строки должен быть следующий - 
        /// "1 2", где первое число - X, a 
        /// второе - Y
        ///</summary>
        public static Vector FromString(string vector)
        {
            List<string> coord = vector.Split(' ').ToList();
            if(coord.Count() < 2 || coord.Count() > 2)
                throw new Exception("Неверный формат строки");
            Int32 x = Int32.Parse(coord[0]);
            Int32 y = Int32.Parse(coord[1]);
            return new Vector(x, y);
        }


        public static Vector FromEnum(PositionOnBoard value)
        {
            switch (value)
            {
                case PositionOnBoard.One:
                    return new Vector(0, 0);
            
                case PositionOnBoard.Two:
                    return new Vector(2, 0);

                case PositionOnBoard.Three:
                    return new Vector(4, 0);

                case PositionOnBoard.Four:
                    return new Vector(0, 2);

                case PositionOnBoard.Five:
                    return new Vector(2, 2);

                case PositionOnBoard.Six:
                    return new Vector(4, 2);

                case PositionOnBoard.Seven:
                    return new Vector(0, 4);
                
                case PositionOnBoard.Eight:
                    return new Vector(2, 4);
                
                case PositionOnBoard.Nine:
                    return new Vector(4, 4);
                
                default: 
                    return new Vector(0, 0);

            }
        }

        #region Overrided Operators
        public static Vector operator +(Vector a, Vector b)
            => new Vector(a.X + b.X, a.Y + b.Y);
        
        public static Vector operator -(Vector a, Vector b)
            => new Vector(a.X - b.X, a.Y - b.Y);
        #endregion


        #region Overrided Methods From Object

        public override bool Equals(object obj)
        {
            Vector b = (Vector)obj;
            return X.Equals(b.X) && Y.Equals(b.Y);
        }

        #endregion
    }
}
