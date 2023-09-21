using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuDePlateau
{
    public partial class ChoixProposition : Form
    {
        /*
         * Ceci est le constructeur du form ChoixProposition qui permet de proposer un choix, entre 2 ou 3 solutions
         * @nbOfChoice : c'est le nombre de choix qu'il doit avoir pour l'instant soit 2 soit 3
         * @nameOfTheRoom : c'est un string qui permet d'afficher sur un label qui fait office de titre
         * @choice1 : c'est un string qui va décrire le choix 1
         * @choice2: c'est un string qui va décrire le choix 2
         * @choice3: c'est un string uqi va décrire le choix 3, il n'est pas utilisé si jamais il y a que 2 choix
         * 
         */
        public ChoixProposition(int nbOfChoice, string nameOfTheRoom,string choice1, string choice2, string choice3, String joueur)
        {
            InitializeComponent();
            labelTitre.Text = nameOfTheRoom;
            labelProposition1.Text = choice1;
            labelProposition2.Text = choice2;
            labelProposition3.Text = choice3;
            if (!string.IsNullOrEmpty(joueur))
            {
                labelJoueur.Text = labelJoueur.Text + joueur + " :";
                labelJoueur.Location = new Point(this.Width / 2 - labelJoueur.Width / 2, this.Height / 4 - labelJoueur.Height*2);
            }
            else
            {
                labelJoueur.Visible = false;
            }
            // Si il y a que 2 choix, on replace les boutons et les labels pour qu'il soit au milieu
            if (nbOfChoice == 2)
            {
                choixc.Visible = false;
                labelProposition3.Visible = false;
                choixa.Location = new Point(this.Width / 3 - (choixa.Width / 2), this.Height / 3);
                choixb.Location = new Point(this.Width * 2 / 3 - (choixb.Width / 2), this.Height / 3);
                labelProposition1.Location = new Point(this.Width / 3 - (labelProposition1.Width / 2), labelProposition1.Location.Y);
                labelProposition2.Location = new Point(this.Width * 2 / 3 - (labelProposition2.Width / 2), labelProposition2.Location.Y);
            
            }else if (nbOfChoice == 3)
            {
                choixa.Location = new Point(this.Width / 4 - (choixa.Width / 2), this.Height / 3);
                choixb.Location = new Point(this.Width / 2 - (choixb.Width / 2), this.Height / 3);
                choixc.Location = new Point(this.Width * 3 / 4 - (choixc.Width / 2), this.Height / 3);
                labelProposition1.Location = new Point(this.Width / 4 - (labelProposition1.Width / 2), labelProposition1.Location.Y);
                labelProposition2.Location = new Point(this.Width / 2 - (labelProposition2.Width / 2), labelProposition2.Location.Y);
                labelProposition3.Location = new Point(this.Width * 3 / 4 - (labelProposition3.Width / 2), labelProposition3.Location.Y);
            }


            if (!nameOfTheRoom.Equals("Nombre de Joueurs"))
            {
                picturePlayer1.Visible = false;picturePlayer2.Visible = false;picturePlayer3.Visible = false;picturePlayer4.Visible = false;
            }
            picturePlayer1.Location = new Point(this.Width / 5*1 - picturePlayer1.Width/2, this.Height - 150);
            picturePlayer2.Location = new Point(this.Width / 5*2 - picturePlayer1.Width/2, this.Height - 150);
            picturePlayer3.Location = new Point(this.Width / 5*3 - picturePlayer1.Width/2, this.Height - 150);
            picturePlayer4.Location = new Point(this.Width / 5*4 - picturePlayer1.Width/2, this.Height - 150);

        }

        /*
         * Cette fonction va return le choix de l'utilisateur sous forme d'un int
         * Si il choisis A ça va return 1, si B 2, et C 3
         * 
         * Si jamais la fonction n'arrive pas a récupérer la réponse, la fonction va return -1
         */
        private int hisChoiceOrNegative()
        {
            if (choixa.Checked)
            {
                return 1;
            }
            if (choixb.Checked)
            {
                return 2;
            }
            if (choixc.Checked)
            {
                return 3;
            }
            return -1;
            
        }

        public int choose { get{ return hisChoiceOrNegative(); } }



        //Une methode click pour chaque choix
        private void choixa_CheckedChanged(object sender, EventArgs e)
        {
            if (labelTitre.Text.Equals("Nombre de Joueurs"))
            {
                picturePlayer3.Visible = false;
                picturePlayer4.Visible = false;
            }
        }

        private void choixb_CheckedChanged(object sender, EventArgs e)
        {
            if (labelTitre.Text.Equals("Nombre de Joueurs"))
            {
                picturePlayer3.Visible = true;
                picturePlayer4.Visible = false;
            }
        }

        private void choixc_CheckedChanged(object sender, EventArgs e)
        {
            if (labelTitre.Text.Equals("Nombre de Joueurs"))
            {
                picturePlayer3.Visible = true;
                picturePlayer4.Visible = true;
            }
        }
    }
}
