using System;
using NUnit.Framework;
using TicTacTou.Game;
using TicTacTou.Game.Core;
using TicTacTou.Game.Actors;
using TicTacTou.Game.Builders;

namespace TicTacTou.Tests
{
    [TestFixture]
    class MapTests
    {

        Map map;
        Player player;
        ActorBuilder<Player> builder;
        [SetUp]
        public void SetUp()
        {
            map = new Map(5, 5); 
            builder = new ActorBuilder<Player>();
            builder.SetSymbol('X');
            builder.SetPosition(new Vector(0, 0));
            player = builder.Get();
        }

        [Test]
        public void MapWidthUndHeightTest()
        {
            Int32 mapHeight = 5, mapWidth = 5;
            Assert.AreEqual(map.Height, mapHeight);
            Assert.AreEqual(map.Width, mapWidth);
        }
        

        [Test]
        public void MapGetCell()
        {
           Cell cell = map.GetCell(0, 0);
           Assert.That(cell, Is.Not.Null);
        }

        [Test]
        public void MapSetActorSymbolToBoord()
        {
            map.SetActorSymbolToBoard(player, new Vector(0, 0));  
            Cell cell = map.GetCell(0, 0);
            Assert.AreEqual(cell.Symbol, player.Symbol);
        }
    }
}
