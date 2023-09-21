using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace JeuDePlateau
{
    public class Card
    {
        public static List<Card> cardsPick { get; set; } = new List<Card>();
        public static List<Card> cardsDiscardPile { get; set; } = new List<Card>();
        public Color color { get; }
        private const int heightCards = 20;
        private const int widthCards = 10;

        /// <summary>
        /// Initialise une couleur spécifique à une carte
        /// </summary>
        /// <param name="colorOfCard"></param>
        public Card(Color colorOfCard)
        {
            this.color = colorOfCard;
            cardsPick.Add(this);
        }

        /// <summary>
        /// Permet d'enlever une carte de la pioche
        /// </summary>
        /// <param name="colorCard"></param> couleur de la carte à suprimer
        public static void removeCard(Color colorCard)
        {
            int i = 0;
            Boolean find = false;
            Card card = null;
            while (find == false && i < cardsPick.Count)
            {
                if (cardsPick[i].color == colorCard)
                {
                    card = cardsPick[i];
                    find = true;
                }
                i++;
            }
            cardsPick.Remove(card);
        }
        /// <summary>
        /// Ajoute toutes les cartes dans la pioche
        /// </summary>
        public static void makeCardsPick()
        {
            cardsPick.Clear();
            cardsDiscardPile.Clear();

            int NuberOfYellowCard = 20;
            int NuberOfBlueCard = 20;
            int NuberOfRedCard = 20;
            int NuberOfGreenCard = 20;
            int NuberOfPurpleCard = 10;
            int NuberOfBlackCard = 8;
            int NuberOfWhiteCard = 2;
            Random aleatoire = new Random();
            while (cardsPick.Count != 100)
            {
                int entier = aleatoire.Next(7);
                if (entier == 0 && NuberOfYellowCard != 0)
                {
                    Card c = new Card(Color.Yellow);
                    NuberOfYellowCard--;
                }
                else if (entier == 1 && NuberOfBlueCard != 0)
                {
                    Card c = new Card(Color.Blue);
                    NuberOfBlueCard--;
                }
                else if (entier == 2 && NuberOfRedCard != 0)
                {
                    Card c = new Card(Color.Red);
                    NuberOfRedCard--;
                }
                else if (entier == 3 && NuberOfGreenCard != 0)
                {
                    Card c = new Card(Color.Green);
                    NuberOfGreenCard--;
                }
                else if (entier == 4 && NuberOfPurpleCard != 0)
                {
                    Card c = new Card(Color.Violet);
                    NuberOfPurpleCard--;
                }
                else if (entier == 5 && NuberOfBlackCard != 0)
                {
                    Card c = new Card(Color.Black);
                    NuberOfBlackCard--;
                }
                else if (entier == 6 && NuberOfWhiteCard != 0)
                {
                    Card c = new Card(Color.White);
                    NuberOfWhiteCard--;
                }
            }
        }
    }
}
