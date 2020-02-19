using System;

namespace TicTacTou.Game.Core
{
    ///<summary>
    /// Крусор
    ///</summary>
    internal static class Cursor
    {

        private static Int32 _left;
        private static Int32 _top;

        ///<summary>
        /// Расположение кусора на консоли
        ///</summary>
        public static Vector Position { get; set; }

        static Cursor()
        {
            Position = new Vector(Console.CursorLeft, Console.CursorTop);
        }

        ///<summary>
        /// Вернуть кусрор обратно
        ///</summary>
        public static void Back()
        {
            Console.SetCursorPosition(_left, _top);
        }

        ///<summary>
        /// Передвинуть кусрор
        ///</summary>
        public static void Move(Vector position)
        {
            _left = Position.X;
            _top = Position.Y;
            Position += position;
            Console.SetCursorPosition(Position.X, Position.Y);
        }

        ///<summary>
        /// Передвинуть кусрор
        /// Выполнить действие
        /// Вернуть курсор
        ///</summary>
        public static void MoveDoUndBack(Vector movePosition, Action action)
        {
            Move(movePosition);
            action();
            Back();
        }
    }
}
