using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JeuDePlateau;

namespace JeuDePlateau
{
    public class Room
    {
        public int nbMaxScientists { get; set; }

        /**
         * room 0 : life quarters
         * room 1 : engine room
         * room 2 : research lab
         * room 3 : recycling plant
         * autre chose : hub
         */
        public Label name { get; set; } = new Label();
        public List<Scientist> listOfScientist;
        Random random;
        /*
         * C'est le constructeur d'un salle,
         * Notre code n'as qu'une seule classe, mais va avoir plusieurs instances de cette classe
         * La classe va avoir tout le code des salles, mais les différentes instances ne vont pas avoir accès aux actions des autres salles
         * Pour différencier les salles on les instancies avec un chiffre de 0 à 3, qui permet de déterminer leurs rôles et leurs nombres max de scientists dans la salle
         * (voir le commentaire au dessus)
         * 
         * 
         */
        public Room(String nameRoom, int maxScientists)
        {
            random = new Random();
            listOfScientist = new List<Scientist>();
            nbMaxScientists = maxScientists;
            name.Text = nameRoom;
            name.AutoSize = true;
        }
        /*
         * Fonction qui permet de dessiner la salle sur le plateau
         */
        public void DrawAction(Graphics g, Rectangle r)
        {
            Font font = new Font("Arial", 15, FontStyle.Bold | FontStyle.Underline);
            Pen pencile = new Pen(Color.White, 4);

            SizeF tailleTexte = g.MeasureString(this.name.Text, font);
            float positionLabelX = r.X + (r.Width - tailleTexte.Width) / 2;
            float positionLabelY = r.Y - tailleTexte.Height - 10;

            g.DrawRectangle(pencile, r);
            g.DrawString(name.Text, font, Brushes.White, positionLabelX, positionLabelY);
            pencile.Dispose();
        }
        /*
         * Avec cette fonction chaque salle ne pourra avoir qu'une seule action
         * et ne pourra pas "bugger" pour en choisir une autre
         * à la fin de l'éxécution des salles tout les scientist retourne au hub
         */
        public void ActionOfRoom(List<Player> players)
        {
            switch (this.name.Text)
            {
                case "Engine Room":
                    EngineRoom(players);
                    break;
                case "Research Lab":
                    ResearchLab(players);
                    break;
                case "Recycling Plant":
                    RecyclingPlant(players);
                    break;
                case "Life Quarters":
                    LifeQuarters(players);
                    break;
                default:
                    break;
            }
            listOfScientist.Clear();
        }


        /*
        * Code de la salle RecyclingPlant
        * (Permet d'échanger des jetons d'énergie contre des jetons d'eau, si quelqu'un fait l'action
        * tout les autres joueurs peuvent choisir de dépenser moins pour en avoir un peu)
        */
        void RecyclingPlant(List<Player> players)
        {
            List<Player> secondList = new List<Player>();
            secondList.AddRange(players);
            int choice = 0;
            foreach (Player player in players)
            {
                if (NumberOfScientistInTheRoom(player) >= 1)
                {
                    ChoixProposition choiceForAction = new ChoixProposition(2, "Recycling plant", "-2 Jeton énergie\n+4 jetons eau \n\n" +
                        "choix pour autre joueur :\n\n -1 jeton énergie\n+1 jeton eau", "-5 jetons énergie, +7 jetons eau\n\n" +
                        "autre joueur présent :\n\n+1 jeton eau", "RIEN", player.name.ToString());
                    if (choiceForAction.ShowDialog() == DialogResult.OK)
                    {
                        choice = choiceForAction.choose;
                        secondList.Remove(player);
                    }
                    if (choice == -1) { MessageBox.Show("Erreur"); }
                    if (choice == 1)
                    {
                        if (player.energyToken >= 2)
                        {
                            player.energyToken -= 2;
                            player.waterToken += 4;
                            foreach (Player secondPlayer in secondList)
                            {
                                ChoixProposition secondChoice = new ChoixProposition(2, "Recycling plant", "-1 jeton énergie\n+1 jeton eau", "RIEN", "", secondPlayer.name.ToString());
                                if (secondChoice.ShowDialog() == DialogResult.OK)
                                {
                                    if (secondChoice.choose == 1)
                                    {
                                        secondPlayer.energyToken--;
                                        secondPlayer.waterToken++;
                                    }
                                }
                            }
                        }
                    }
                    if (choice == 2)
                    {
                        if (player.energyToken >= 5)
                        {
                            player.energyToken -= 5;
                            player.waterToken += 7;
                            foreach (Player secondPlayer in secondList)
                            {
                                secondPlayer.waterToken++;
                            }
                        }
                    }
                }
            }
        }
        void ResearchLab(List<Player> players)
        {

            foreach (Player p in players)
            {
                if (NumberOfScientistInTheRoom(p) >= 1)
                {
                    ChoixProposition hisChoice = new ChoixProposition(2, "Research Lab", "-2 jetons énergie\n+2 cartes aléatoire", "Gagner des points\navec des combos de cartes", "", null);
                    if (hisChoice.ShowDialog() == DialogResult.OK)
                    {
                        if (hisChoice.choose == 1)
                        {
                            if (Card.cardsPick.Count == 0)
                            {
                                if (Card.cardsDiscardPile.Count() != 0)
                                {
                                    Card.cardsPick = Card.cardsDiscardPile;
                                }
                                else
                                {
                                    MessageBox.Show("Toutes les carets sont dans vos main.", "Attention");
                                    return;
                                }


                            }
                            int randomNumber1 = random.Next(0, Card.cardsPick.Count());
                            Card card1 = Card.cardsPick[randomNumber1];
                            Card.removeCard(card1.color);

                            int randomNumber2 = random.Next(0, Card.cardsPick.Count());
                            Card card2 = Card.cardsPick[randomNumber2];
                            Card.removeCard(card2.color);

                            p.addCardWithColor(card1.color);
                            p.addCardWithColor(card2.color);



                        }
                        else if (hisChoice.choose == 2)
                        {
                            ChoixCarteValo comboCarte = new ChoixCarteValo(p);
                            comboCarte.ShowDialog();
                        }
                    }
                }
            }
        }

        void EngineRoom(List<Player> players)
        {
            foreach (Player p in players)
            {
                if (NumberOfScientistInTheRoom(p) >= 1)
                {
                    p.energyToken += 7;
                    MessageBox.Show("Joueur : " + p + " vous avez gagné 7 jetons energie", "Engine Romm");
                }
            }
        }
        /*
         * Code qui permet de faire l'action de la salle LifeQuarters
         * (4 scientist max et si 2 scientists de la même couleur on peut dépenser pour avoir un nouveau scientist)
         */
        void LifeQuarters(List<Player> players)
        {
            foreach (Player player in players)
            {
                if (!(NumberOfScientistInTheRoom(player) == 0))
                {
                    if (NumberOfScientistInTheRoom(player) >= 2)
                    {
                        if (player.scientists.Count() < 10)
                        {
                            if (player.energyToken >= 5)
                            {
                                ChoixProposition result1 = new ChoixProposition(2, "Quartiers d'équipage", "-5 jetons énergie\n\n +1 scientifique", "ne rien faire", "", null);
                                if (result1.ShowDialog() == DialogResult.OK)
                                {
                                    if (result1.choose == 1)
                                    {
                                        player.energyToken -= 5;
                                        player.addNumberOfScientists(1);
                                        player.dispo++;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Joueur : " + player.name +
                        "\n\nVous ne pouvez pas faire l'action de la salle,\ncar vous n'avez pas assez de jetons énergies");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Joueur : " + player.name +
                        "\n\nVous ne pouvez pas faire l'action de la salle,\ncar vous ne pouvez pas avoir plus de 10 scientifiques");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Joueur : " + player.name +
                        "\n\nVous ne pouvez pas faire l'action de la salle,\ncar vous n'avez pas assez de scientifique dans la salle");
                    }
                }

            }
        }

        /*
         * Permet de déterminer combien il y a de scientist d'un joueur dans une salle
         */
        private int NumberOfScientistInTheRoom(Player player)
        {
            int number = 0;
            foreach (Scientist scientist in listOfScientist)
            {
                if (scientist.color.Equals(player.color))
                {
                    number++;
                }
            }
            return number;
        }

        /*
         * Ceci est une fonction toujours théorique, qui permet d'ajouter un nombre @nbr de scientist d'un certains joueur dans une salle
         */
        public Boolean AddScientistToTheRoom(Scientist player)
        {
            Boolean add = false;


            if (listOfScientist.Count < nbMaxScientists)
            {
                listOfScientist.Add(player);
                add = true;
            }

            return add;

        }
    }
}
