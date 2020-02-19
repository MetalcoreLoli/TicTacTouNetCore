using System;
using System.Collections.Generic;


namespace TicTacTou.Game.Core
{
    ///<summary>
    /// Класс отвечающий за отрисовку
    ///</summary>
    internal static class Render
    {
        ///<summary>
        /// Отсрисовка с смещением
        ///</summary>
        public static void WithOffset(IRenderable obj, int xOff, int yOff)
        {
            Console.CursorVisible = false;
            Int32 left = Console.CursorLeft;
            Int32 top = Console.CursorTop;

            Console.SetCursorPosition(obj.Position.X + xOff, obj.Position.Y + yOff);
            
            Console.ForegroundColor = obj.Color;
            Console.BackgroundColor = obj.BackColor;
            Console.Write(obj.Symbol);
            Console.ResetColor();
            
            Console.SetCursorPosition(left, top);
            Console.CursorVisible = false;
        }


        ///<summary>
        /// Отрисовка без смещения
        ///</summary>
        public static void WithOutOffset(IRenderable obj)
        {
            WithOffset(obj, 0, 0);
        }


        ///<summary>
        /// Отрисовка набора объектов с смешением
        ///</summary>
        public static void RangeWithOffset(this IEnumerable<IRenderable> source, int xOff, int yOff)
        {
            foreach (IRenderable obj in source)
                WithOffset(obj, xOff, yOff);
        }

        ///<summary>
        /// Отрисовка набора объектов без смешением
        ///</summary>
        public static void RangeWithOutOffset(this IEnumerable<IRenderable> source)
        {
            source.RangeWithOffset(0, 0);
        }
    }
}
