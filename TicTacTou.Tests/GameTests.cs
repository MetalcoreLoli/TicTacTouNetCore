using NUnit.Framework;
using System;
using TicTacTou.Game;
using TicTacTou.Game.Core;
using TicTacTou.Game.Actors;
using TicTacTou.Game.Builders;

namespace TicTacTou.Tests
{
    [TestFixture]
    class GameTests
    {
        Game.Game game; 
        [SetUp]
        public void SetUp()
        {
            game = new Game.Game(); 
        }

        [Test]
        public void GameCreatePlayerTest()
        {
            Player player = game.CreatePlayer();
            Player playerOne = game.CreatePlayer();
            Assert.AreNotSame(player, playerOne);
        }
        
    }
}
