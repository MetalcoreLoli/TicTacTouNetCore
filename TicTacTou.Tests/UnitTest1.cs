using NUnit.Framework;
using TicTacTou.Game.Core;

namespace TicTacTou.Tests
{
    public class Tests
    {
        Vector a;
        Vector b;
        [SetUp]
        public void Setup()
        {
            a = new Vector(1, 1);
            b = new Vector(2, 2);
        }

        [Test]
        public void VectorAddTest()
        {
            Vector result = a + b;
            Vector answer = new Vector(3, 3);
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void VectorSubTest()
        {
            Vector result = a - b;
            Vector answer = new Vector(-1, -1);
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void VectorFromString()
        {
            Vector result = Vector.FromString("1 2");
            Vector answer = new Vector(1, 2);

            Assert.AreEqual(result, answer);
        }
    }
}
