﻿using System;
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
        public void Given_new_game_the_game_should_continue()
        {
            var game = new Game();
            Assert.IsFalse(game.HasEnded);
        }

        [TestMethod]
        public void Given_Love_Love_when_left_scores_should_state_Fifteen_Love()
        {
            var game = new Game()
                .ScoreLeft();
            Assert.AreEqual(Score.Fifteen, game.LeftScore);
            Assert.AreEqual(Score.Love, game.RightScore);
        }

        [TestMethod]
        public void Given_Love_Love_when_left_scores_the_game_should_continue()
        {
            var game = new Game()
                .ScoreLeft();
            Assert.IsFalse(game.HasEnded);
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
        public void Given_Thirty_Love_when_left_scores_should_state_Forty_Love()
        {
            var game = new Game(Score.Thirty, Score.Love)
                .ScoreLeft();
            Assert.AreEqual(Score.Forty, game.LeftScore);
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

        [TestMethod]
        public void Given_Forty_Love_when_left_scores_should_state_Won_Love()
        {
            var game = new Game(Score.Forty, Score.Love)
                .ScoreLeft();
            Assert.AreEqual(Score.Won, game.LeftScore);
            Assert.AreEqual(Score.Love, game.RightScore);
        }

        [TestMethod]
        public void Given_Forty_Love_when_left_scores_the_game_should_be_ended()
        {
            var game = new Game(Score.Forty, Score.Love)
                .ScoreLeft();
            Assert.IsTrue(game.HasEnded);
        }

        [TestMethod]
        public void Given_Thirty_Forty_when_right_scores_should_state_Thirty_Won()
        {
            var game = new Game(Score.Thirty, Score.Forty)
                .ScoreRight();
            Assert.AreEqual(Score.Thirty, game.LeftScore);
            Assert.AreEqual(Score.Won, game.RightScore);
        }

        [TestMethod]
        public void Given_Forty_Forty_when_left_scores_should_state_Advantage_Forty()
        {
            var game = new Game(Score.Forty, Score.Forty)
                .ScoreLeft();
            Assert.AreEqual(Score.Advantage, game.LeftScore);
            Assert.AreEqual(Score.Forty, game.RightScore);
        }

        [TestMethod]
        public void Given_Advantage_Forty_the_game_should_continue()
        {
            var game = new Game(Score.Advantage, Score.Forty);
            Assert.IsFalse(game.HasEnded);
        }

        [TestMethod]
        public void Given_Advantage_Forty_when_left_scores_should_state_Won_Forty()
        {
            var game = new Game(Score.Advantage, Score.Forty)
                .ScoreLeft();
            Assert.AreEqual(Score.Won, game.LeftScore);
            Assert.AreEqual(Score.Forty, game.RightScore);
        }

        [TestMethod]
        public void Given_Advantage_Forty_when_left_scores_the_game_should_be_ended()
        {
            var game = new Game(Score.Advantage, Score.Forty)
                .ScoreLeft();
            Assert.IsTrue(game.HasEnded);
        }

        [TestMethod]
        public void Given_Advantage_Forty_when_right_scores_should_state_Forty_Forty()
        {
            var game = new Game(Score.Advantage, Score.Forty)
                .ScoreRight();
            Assert.AreEqual(Score.Forty, game.LeftScore);
            Assert.AreEqual(Score.Forty, game.RightScore);
        }

        [TestMethod]
        public void Given_Advantage_Forty_when_right_scores_the_game_should_continue()
        {
            var game = new Game(Score.Advantage, Score.Forty)
                .ScoreRight();
            Assert.IsFalse(game.HasEnded);
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
        private readonly Player left;
        private readonly Player right;

        public Game() : this(Score.Love, Score.Love) { }

        public Game(Score leftScore, Score rightScore)
        {
            left = new Player { Score = leftScore };
            right = new Player { Score = rightScore };
        }

        public Score LeftScore
        {
            get { return left.Score; }
        }

        public Score RightScore
        {
            get { return right.Score; }
        }

        public bool HasEnded
        {
            get { return LeftScore == Score.Won || RightScore == Score.Won; }
        }

        public Game ScoreLeft()
        {
            ScorePlayer(left, right);
            return this;
        }

        public Game ScoreRight()
        {
            ScorePlayer(right, left);
            return this;
        }

        private void ScorePlayer(Player scorer, Player loser)
        {
            if (scorer.Score == Score.Forty)
            {
                if (loser.Score < Score.Forty)
                {
                    scorer.Score = Score.Won;
                }
                else if (loser.Score == Score.Forty)
                {
                    scorer.Score = Score.Advantage;
                }
                else
                {
                    loser.Score = Score.Forty;
                }
            }
            else
            {
                scorer.Score++;
            }
        }

        private class Player
        {
            public Score Score { get; set; }
        }
    }
}
