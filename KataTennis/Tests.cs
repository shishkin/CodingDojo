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
        public void Given_Love_Love_when_left_scores_should_state_Fifteen_Love()
        {
            var game = new Game()
                .ScoreLeft();
            Assert.AreEqual(Score.Fifteen, game.LeftScore);
            Assert.AreEqual(Score.Love, game.RightScore);
        }

        [TestMethod]
        public void Given_Fifteen_Love_when_left_scores_should_state_Thirty_Love()
        {
            var game = new Game(Score.Fifteen, Score.Love)
                .ScoreLeft();
            Assert.AreEqual(Score.Thirty, game.LeftScore);
            Assert.AreEqual(Score.Love, game.RightScore);
        }

        [TestMethod]
        public void Given_Fifteen_Love_when_right_scores_should_state_Fifteen_Fifteen()
        {
            var game = new Game(Score.Fifteen, Score.Love)
                .ScoreRight();
            Assert.AreEqual(Score.Fifteen, game.LeftScore);
            Assert.AreEqual(Score.Fifteen, game.RightScore);
        }
    }

    public enum Score
    {
        Love,
        Fifteen,
        Thirty,
        Forty,
        Advantage,
        Won
    }

    public class Game
    {
        public Game() : this (Score.Love, Score.Love){}

        public Game(Score left, Score right)
        {
            LeftScore = left;
            RightScore = right;
        }

        public Score LeftScore { get; private set; }
        
        public Score RightScore { get; private set; }

        public Game ScoreLeft()
        {
            LeftScore++;
            return this;
        }

        public Game ScoreRight()
        {
            RightScore++;
            return this;
        }
    }
}
