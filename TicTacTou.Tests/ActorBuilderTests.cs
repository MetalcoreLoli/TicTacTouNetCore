using NUnit.Framework;
using System;
using TicTacTou.Game.Core;
using TicTacTou.Game.Actors;
using TicTacTou.Game.Builders;

namespace TicTacTou.Tests
{
    [TestFixture]
    class ActorBuilderTests
    {
        ActorBuilder<Player> builder;
        
        Player player;
        [SetUp]
        public void SetUp()
        {
            builder = new ActorBuilder<Player>();
        }


        [Test]
        public void ActorBuilderGetTest()
        {
            player = builder.Get();

            Assert.That(player, Is.Not.Null);
            Assert.That(player is Player, Is.True);
        }


        [Test]
        public void ActorBuilderSetSymbolTest()
        {
            builder.SetSymbol('X');
            player = builder.Get();
            char answer = 'X';
            Assert.AreEqual(player.Symbol, answer);
        }

        [Test]
        public void ActorBuilderSetPositionTest()
        {
            Vector position = new Vector(1, 1);
            builder.SetPosition(position);

            player = builder.Get();
            Assert.That(player.Position.Equals(new Vector(1, 1)), Is.True);
        }


        [Test]
        public void ActorBuilderSetNameTest()
        {
            string name = "Trap-chan";
            builder.SetName("Trap-chan");
            player = builder.Get();
            Assert.AreEqual(player.Name, name);
        }

        [Test]
        public void ActorBuilderSetColorTest()
        {
            builder.SetColor(ConsoleColor.Yellow);
            player = builder.Get();
            Assert.AreEqual(player.Color, ConsoleColor.Yellow);
        }
        
        [Test]
        public void ActorBuilderSetBackColorTest()
        {
            builder.SetBackColor(ConsoleColor.Yellow);
            player = builder.Get();
            Assert.AreEqual(player.BackColor, ConsoleColor.Yellow);
        }

    }
}
