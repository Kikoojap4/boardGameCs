using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JeuDePlateau;
<<<<<<< HEAD
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
=======
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
>>>>>>> Aymeric

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPlateau()
        {
            Plateau plateau = new Plateau();

            Assert.AreEqual(FormBorderStyle.None, plateau.FormBorderStyle);
            Assert.AreEqual(plateau.Height, Plateau.PlateauHeight);
            Assert.AreEqual(plateau.Width, Plateau.PlateauWidth);

            Assert.IsNotNull(plateau.rectangleEngineRoom);
            Assert.IsNotNull(plateau.rectangleResearchLab);
            Assert.IsNotNull(plateau.rectangleRecyclingPlant);
            Assert.IsNotNull(plateau.rectanglelifeQuarters);
            Assert.IsNotNull(plateau.gameController);
        }

        [TestMethod]
        public void TestDraw()
        {
            Plateau plateau = new Plateau();
            PaintEventArgs paintEventArgs = new PaintEventArgs(plateau.CreateGraphics(), new Rectangle());

            plateau.Draw(null, paintEventArgs);

            int x = plateau.Width / 2;
            int y = plateau.Height / 2;
            Assert.AreEqual(new Point(x - 100 - 50 - plateau.getPictureCard.Width, y - plateau.getPictureCard.Height / 2), plateau.getPictureCard.Location);
            Assert.AreEqual(new Point(x + 100 + 50, y - plateau.getPictureMap.Height / 2), plateau.getPictureMap.Location);
            Assert.AreEqual(new Point(x - plateau.getButtonQuit.Width / 2, y / 6 * 11), plateau.getButtonQuit.Location);
        }

        [TestMethod]
<<<<<<< HEAD
        public void TestPullCard()
        {
            Card card = new Card(Color.Red);
            List<Card> cardsPick = Card.cardsPick;
            List<Card> cardsDiscardPile = Card.cardsDiscardPile;

            card.pullCard(card);

            Assert.IsFalse(cardsPick.Contains(card));
            Assert.IsTrue(cardsDiscardPile.Contains(card));
        }

        [TestMethod]
=======
>>>>>>> Aymeric
        public void TestMakeCardsPick()
        {
            Card card = new Card(Color.Yellow);
            int expectedYellowCards = 20;
            int expectedBlueCards = 20;
            int expectedRedCards = 20;
            int expectedGreenCards = 20;
            int expectedPurpleCards = 10;
            int expectedBlackCards = 8;
            int expectedWhiteCards = 2;

<<<<<<< HEAD
            card.makeCardsPick();
=======
            Card.makeCardsPick();
>>>>>>> Aymeric
            List<Card> cardsPick = Card.cardsPick;

            int actualYellowCards = CountCardsByColor(cardsPick, Color.Yellow);
            int actualBlueCards = CountCardsByColor(cardsPick, Color.Blue);
            int actualRedCards = CountCardsByColor(cardsPick, Color.Red);
            int actualGreenCards = CountCardsByColor(cardsPick, Color.Green);
            int actualPurpleCards = CountCardsByColor(cardsPick, Color.Purple);
            int actualBlackCards = CountCardsByColor(cardsPick, Color.Black);
            int actualWhiteCards = CountCardsByColor(cardsPick, Color.White);

            Assert.AreEqual(expectedYellowCards, actualYellowCards);
            Assert.AreEqual(expectedBlueCards, actualBlueCards);
            Assert.AreEqual(expectedRedCards, actualRedCards);
            Assert.AreEqual(expectedGreenCards, actualGreenCards);
            Assert.AreEqual(expectedPurpleCards, actualPurpleCards);
            Assert.AreEqual(expectedBlackCards, actualBlackCards);
            Assert.AreEqual(expectedWhiteCards, actualWhiteCards);
            Assert.AreEqual(100, cardsPick.Count);
        }

        public static int CountCardsByColor(List<Card> cards, Color color)
        {
            int count = 0;
            foreach (Card card in cards)
            {
                if (card.color == color)
                {
                    count++;
                }
            }
            return count;
        }

        [TestMethod]
        public void Test_GameController()
        {
            GameController gameController = new GameController();
            List<Player> players = GameController.players;
<<<<<<< HEAD
            Room engineRoom = gameController.engineRoom;
            Room researchLab = gameController.researchLab;
            Room recyclingPlant = gameController.recyclingPlant;
            Room lifeQuarters = gameController.lifeQuarters;
=======
            Room engineRoom = GameController.engineRoom;
            Room researchLab = GameController.researchLab;
            Room recyclingPlant = GameController.recyclingPlant;
            Room lifeQuarters = GameController.lifeQuarters;
>>>>>>> Aymeric
            int expectedNumberOfPlayers = GameController.nbOfPlayer;

            Assert.IsNotNull(players);
            Assert.AreEqual(expectedNumberOfPlayers, players.Count);
            Assert.IsNotNull(engineRoom);
            Assert.IsNotNull(researchLab);
            Assert.IsNotNull(recyclingPlant);
            Assert.IsNotNull(lifeQuarters);
        }
    }
}
