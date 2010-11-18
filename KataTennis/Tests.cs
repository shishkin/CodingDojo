using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataTennis
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Given_0_0_when_left_scores_should_state_1_0()
        {
            var game = new Game()
                .ScoreLeft();
            Assert.AreEqual(1, game.LeftScore);
            Assert.AreEqual(0, game.RightScore);
        }

        [TestMethod]
        public void Given_1_0_when_right_scores_should_state_1_1()
        {
            var game = new Game(1, 0)
                .ScoreRight();
            Assert.AreEqual(1, game.LeftScore);
            Assert.AreEqual(0, game.RightScore);
        }
    }

    public class Game
    {
        public Game() : this (0, 0){}

        public Game(int left, int right)
        {
            LeftScore = left;
            RightScore = right;
        }

        public int LeftScore { get; private set; }
        
        public int RightScore { get; private set; }

        public Game ScoreLeft()
        {
            LeftScore++;
            return this;
        }

        public Game ScoreRight()
        {
            throw new NotImplementedException();
        }
    }
}
