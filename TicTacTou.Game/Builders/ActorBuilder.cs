using System;
using TicTacTou.Game.Core;
using TicTacTou.Game.Actors;

namespace TicTacTou.Game.Builders
{
    internal class ActorBuilder<T> where T: Actor, new()
    {
        private T _instance;

        public ActorBuilder()
        {
            _instance = new T();
        }


        ///<summary>
        /// Установка имени актеру
        ///</summary>
        public void SetName(string name)
        {
            _instance.Name = name;
        }
        
        ///<summary>
        /// Установка символа актеру
        ///</summary>
        public void SetSymbol(char symbol)
        {
            _instance.Symbol = symbol;
        }
        
        ///<summary>
        /// Установка позиции актера
        ///</summary>
        public void SetPosition(Vector position)
        {
           _instance.Position = position; 
        }


        ///<summary>
        /// Уствнока цвета символа готового актера
        ///</summary>
        public void SetColor(ConsoleColor color)
        {
            _instance.Color = color; 
        }

        ///<summary>
        /// Уствнока цвета фон готового актера
        ///</summary>
        public void SetBackColor(ConsoleColor backColor)
        {
            _instance.BackColor = backColor;
        }

        ///<summary>
        /// Получение готового актера
        ///</summary>
        public T Get()
            => _instance;
    }
}
