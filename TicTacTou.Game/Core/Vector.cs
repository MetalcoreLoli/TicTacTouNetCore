using System;
using System.Linq;
using System.Collections.Generic;

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
