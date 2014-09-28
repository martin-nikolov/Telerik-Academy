namespace TicTacToe.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TicTacToe.Data.Contracts;
    using TicTacToe.GameLogic;
    using TicTacToe.GameLogic.Contracts;
    using TicTacToe.GameLogic.Enum;
    using TicTacToe.Models;
    using TicTacToe.Web.Controllers;
    using TicTacToe.Web.DataModels;
    using TicTacToe.Web.Infrastructure;

    [TestClass]
    public class PlayActionTests
    {
        private readonly IGameResultValidator gameResultValidator = new GameResultValidator();

        [TestMethod]
        public void WhenIsXTurnChangeStateToO()
        {
            var userId = "Niki";
            var gameId = Guid.NewGuid();
            var game = new Game
            {
                GameId = gameId,
                FirstPlayerId = userId,
                State = GameState.TurnX
            };
            game.GameId = gameId;

            var userIdProviderMock = new Mock<IUserInfoProvider>();
            userIdProviderMock.Setup(x => x.GetUserId()).
            Returns(userId);

            var repositoryMock = new Mock<IGenericRepository<Game>>();
            repositoryMock.Setup(x => x.All()).Returns(() => new List<Game>()
            {
                game,
            }
             .AsQueryable());
            repositoryMock.Setup(x => x.Find(It.IsAny<Guid>()))
                          .Returns(game);

            var uowData = new Mock<ITicTacToeData>();
            uowData.SetupGet(x => x.Games).Returns(repositoryMock.Object);

            var controller = new GamesController(
                uowData.Object,
                new GameResultValidator(),
                userIdProviderMock.Object);

            var result = controller.Play(new PlayRequestDataModel()
            {
                GameId = gameId.ToString(),
                Col = 1,
                Row = 1,
            });

            Assert.AreEqual(GameState.TurnO, game.State);
        }

        [TestMethod]
        public void TestWhenXWinsInFirstRow()
        {
            var board = "XXXO-O-O-";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenXWinsInSecondRow()
        {
            var board = "O--XXXO-O";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenXWinsInThirdRow()
        {
            var board = "O-OO--XXX";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenXWinsInFirstColumn()
        {
            var board = "X--X-OXOO";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenXWinsInSecondColumn()
        {
            var board = "-X--XOOXO";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenXWinsInThirdColumn()
        {
            var board = "--X-OXOOX";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenXWinsInLeftToRightDiagonal()
        {
            var board = "X---XOOOX";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenXWinsInRightToLeftDiagonal()
        {
            var board = "OOXOX-XO-";
            Assert.AreEqual(GameResult.WonByX, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInFirstRow()
        {
            var board = "OOOX-X-X-";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInSecondRow()
        {
            var board = "X--OOOX-X";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInThirdRow()
        {
            var board = "X-XX--OOO";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInFirstColumn()
        {
            var board = "O--O-XOXX";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInSecondColumn()
        {
            var board = "-O--OXXOX";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInThirdColumn()
        {
            var board = "--O-XOXXO";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInLeftToRightDiagonal()
        {
            var board = "O---OXXXO";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenOWinsInRightToLeftDiagonal()
        {
            var board = "XXOXO-OX-";
            Assert.AreEqual(GameResult.WonByO, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenGameIsNotFinished_1()
        {
            var board = "--------";
            Assert.AreEqual(GameResult.NotFinished, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenGameIsNotFinished_2()
        {
            var board = "OO--X-XO-";
            Assert.AreEqual(GameResult.NotFinished, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestWhenGameIsNotFinished_3()
        {
            var board = "OO-OX-XOX";
            Assert.AreEqual(GameResult.NotFinished, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestOnDrawGame_1()
        {
            var board = "XOXXOXOXO";
            Assert.AreEqual(GameResult.Draw, this.gameResultValidator.GetResult(board));
        }

        [TestMethod]
        public void TestOnDrawGame_2()
        {
            var board = "OXOOXOXOX";
            Assert.AreEqual(GameResult.Draw, this.gameResultValidator.GetResult(board));
        }
    }
}