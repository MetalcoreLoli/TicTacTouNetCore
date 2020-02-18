using System;
using TicTacTou.Game.Core;
using TicTacTou.Game.Actors;

namespace TicTacTou.Game.Actors
{
    internal class Player : Actor
    {
        public Player () : this(' ', new Vector(0, 0))
        {
        }
        
        public Player(char symbol, Vector position)
            : base (symbol, position)
        {
        }
    }
}
