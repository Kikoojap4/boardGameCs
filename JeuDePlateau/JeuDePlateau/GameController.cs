using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuDePlateau
{
    public class GameController
    {

        public static List<Player> players { get; set; } = new List<Player>();
        public int nbOfPlayer { get; set; }


        public static bool playerWin = false;
        public static Color scientistColor = Color.DeepSkyBlue;
        public Plateau plateau;



        /*
         * Couleur joueur: 
         * bleu 
         * vert 
         * Orange
         * jaune
         */

        public static Room engineRoom;
        public static Room researchLab;
        public static Room recyclingPlant;
        public static Room lifeQuarters;

        public GameController()
        {


            //ChoixProposition choiceForNbOfPlayers = new ChoixProposition(3, "Nombre de Joueurs", "2 joueurs", "3 joueurs", "4 joueurs");
            //if (choiceForNbOfPlayers.ShowDialog() == DialogResult.OK)
            //{
            //    nbOfPlayer = choiceForNbOfPlayers.choose + 1;
            //}
            //InitializationOfPlayers();
            //plateau = new Plateau();

        }
        /// <summary>
        /// Cette fonction effectue des initialisation pour démarrer le jeu 
        /// </summary>
        public void init()
        {
            players = new List<Player>();
            engineRoom = new Room("Engine Room", 2);
            researchLab = new Room("Research Lab", 2);
            recyclingPlant = new Room("Recycling Plant", 5);
            lifeQuarters = new Room("Life Quarters", 4);
            ChoixProposition choiceForNbOfPlayers = new ChoixProposition(3, "Nombre de Joueurs", "2 joueurs", "3 joueurs", "4 joueurs", null);
            if (choiceForNbOfPlayers.ShowDialog() == DialogResult.OK)
            {
                nbOfPlayer = choiceForNbOfPlayers.choose + 1;
            }
            InitializationOfPlayers();
            plateau = new Plateau();
        }

        /// <summary>
        /// Initialise le nombre de joueurs en fonction du nombre choisi
        /// </summary>
        public void InitializationOfPlayers()
        {
            Player player1 = new Player("bleu", Color.DeepSkyBlue, 24, 24);
            players.Add(player1);
            Player player2 = new Player("vert", Color.LimeGreen, 1427, 24);
            players.Add(player2);

            if (nbOfPlayer >= 3)
            {
                Player player3 = new Player("rouge", Color.DarkOrange, 1427, 780);
                players.Add(player3);
            }
            if (nbOfPlayer == 4)
            {
                Player player4 = new Player("jaune", Color.Gold, 24, 780);
                players.Add(player4);
            }
            Card card1 = new Card(Color.White);
            Card card2 = new Card(Color.Black);
            Card card3 = new Card(Color.Violet);
            Card card4 = new Card(Color.Red);
            Card card5 = new Card(Color.Yellow);
            Card card6 = new Card(Color.Green);
            Card card7 = new Card(Color.Blue);

            Card[] cards = { card1, card2, card3, card4, card5, card6, card7 };

            foreach (Player player in players)
            {
                foreach (Card card in cards)
                {
                    player.addCard(card);
                }
            }
            Card.makeCardsPick();
        }

        /// <summary>
        /// Cette fonction vérifie si un joueur a atteint 150 points pour gagner ou s'il n'a plus de scientifiques pour perdre
        /// </summary>
        /// <returns></returns>
        public Boolean verifPlayerWin()
        {
            if (players.Count() > 1)
            {
                List<Player> playersToRemove = new List<Player>();
                foreach (Player player in players)
                {
                    if (player.point >= 150)
                    {
                        
                        MessageBox.Show("Le joueur " + player.name.ToString() + " a gagné car il a atteint 150 points", "Victoire");
                        return true;
                    }
                    else if (player.scientists.Count() == 0)
                    {
                        playersToRemove.Add(player);
                        MessageBox.Show("Le joueur " + player.name.ToString() + " a perdu car il n'a plus de scientifique (pion)", "Défaite");
                    }
                }

                foreach (Player playerToRemove in playersToRemove)
                {
                    players.Remove(playerToRemove);
                }

                if (players.Count() == 0)
                {
                    MessageBox.Show("Tous les joueurs ont perdu", "Défaite");
                    return true;
                }
            }
            if (players.Count() == 1)
            {
                Player winningPlayer = players[0];

                MessageBox.Show("Le joueur " + winningPlayer.name.ToString() + " a gagné car tous les autres ont perdu", "Victoire");
                return true;
            }
            return false;
        }

        /// <summary>
        ///  cette fonction gère les actions liées à une révolution dans le jeu
        /// </summary>
        public void Revolution()
        {
            engineRoom.ActionOfRoom(players);
            researchLab.ActionOfRoom(players);
            recyclingPlant.ActionOfRoom(players);

            lifeQuarters.ActionOfRoom(players);
            foreach (Player player in players)
            {
                List<Scientist> scientistsToRemove = new List<Scientist>();
                foreach (Scientist scientist in player.scientists)
                {
                    scientist.backToHub();
                    scientist.isDejaClick = false;
                    if (player.waterToken > 0)
                    {
                        player.waterToken--;
                    }
                    else
                    {
                        scientistsToRemove.Add(scientist);
                    }
                }
                foreach (Scientist scientistToRemove in scientistsToRemove)
                {
                    player.scientists.Remove(scientistToRemove);
                }
                player.dispo = player.scientists.Count();
            }
            scientistColor = Color.DeepSkyBlue;
        }

        /// <summary>
        ///  cette fonction recherche le joueur dont la couleur correspond à la couleur spécifiée en paramètre, 
        ///  puis passe à la couleur suivante disponible dans la liste des joueurs.
        /// </summary>
        /// <param name="color"></param>
        public static void switchColor(Color color)
        {
            bool trouver = false;
            int playerCurent = -1;
            int j = 0;
            int i;
            for (i = 0; i < players.Count; i++)
            {
                if (players[i].color == color)
                {
                    playerCurent = i;
                    break;
                }
            }
            while (!trouver && j <= 40)
            {
                playerCurent ++;
                j++;
                if (playerCurent == players.Count())
                {
                    playerCurent = 0;
                }
                if (players[playerCurent].dispo >= 1)
                {
                    trouver = true;
                    scientistColor = players[playerCurent].color;
                }
            }
        }

    }
}
