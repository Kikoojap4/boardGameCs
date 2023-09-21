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
    internal partial class ChoixCarteValo : Form
    {
        int nbCardBlc = 0;
        int nbCardVlt = 0;
        int nbCardRed = 0;
        int nbCardGrn = 0;
        int nbCardBlu = 0;
        int nbCardWht = 0;
        int nbCardYel = 0;

        int nbOfDifferentCards = 0;
        int potentialPoints;
        int RemainsEnergy;

        Dictionary<Card, int> SlctOfCards;
        Player p;



        public ChoixCarteValo(Player p)
        {
            InitializeComponent();
            setPositionToAllPicture();
            setPositionToLabelLinkWithPicture();
            this.p = p;
            SlctOfCards = new Dictionary<Card, int>(p.deckOfCards);
            getNbOfCards();
            RemainsEnergy = p.energyToken;
            potentialPoints = 0;
            
            foreach(Card c in p.deckOfCards.Keys)
            {
                SlctOfCards[c] = 0;
            }
            


            labelnbCardBlck.Text = nbCardBlc.ToString();
            labelnbCardBlue.Text = nbCardBlu.ToString();
            labelnbCardVlt.Text = nbCardVlt.ToString();
            labelnbCardWht.Text = nbCardWht.ToString();
            labelnbCardYell.Text = nbCardYel.ToString();
            labelnbCardGrn.Text = nbCardGrn.ToString();
            labelnbCardRed.Text = nbCardRed.ToString();

            


        }

        private void getNbOfCards()
        {
            foreach (KeyValuePair<Card, int> pair in p.deckOfCards)
            {
                switch (pair.Key.color.ToKnownColor())
                {
                    case KnownColor.White:
                        nbCardWht = pair.Value;
                        break;
                    case KnownColor.Black:
                        nbCardBlc = pair.Value;
                        break;
                    case KnownColor.Red:
                        nbCardRed = pair.Value;
                        break;
                    case KnownColor.Green:
                        nbCardGrn = pair.Value;
                        break;
                    case KnownColor.Blue:
                        nbCardBlu = pair.Value;
                        break;
                    case KnownColor.Violet:
                        nbCardVlt = pair.Value;
                        break;
                    case KnownColor.Yellow:
                        nbCardYel = pair.Value;
                        break;
                }
            }

            
        }
        private void Draw(object sender, PaintEventArgs e)
        {
            foreach(KeyValuePair<Card, int> pair in SlctOfCards)
            {
                switch (pair.Key.color.ToKnownColor())
                {
                    case KnownColor.White:
                        labelSlctWht.Text = pair.Value.ToString();
                        break;
                    case KnownColor.Black:
                        labelSlctBlc.Text = pair.Value.ToString();
                        break;
                    case KnownColor.Red:
                        labelSlctRed.Text = pair.Value.ToString();
                        break;
                    case KnownColor.Green:
                        labelSlctGrn.Text = pair.Value.ToString();
                        break;
                    case KnownColor.Blue:
                        labelSlctBlu.Text = pair.Value.ToString();
                        break;
                    case KnownColor.Violet:
                        labelSlctVlt.Text = pair.Value.ToString();
                        break;
                    case KnownColor.Yellow:
                        labelSlctYel.Text = pair.Value.ToString();
                        break;
                }
            }
            labelPoints.Text = potentialPoints.ToString();
            labelRemainsEnergy.Text = RemainsEnergy.ToString();
            labelPointJoueur.Text = p.point.ToString();
            
        }
        private void setPositionToAllPicture()
        {
            pictureBoxWht.Location = new Point(this.Width / 8 - (pictureBoxWht.Width / 2), pictureBoxWht.Location.Y);
            pictureBoxBlu.Location = new Point(this.Width * 2 / 8 - (pictureBoxBlu.Width / 2), pictureBoxBlu.Location.Y);
            pictureBoxYel.Location = new Point(this.Width * 3 / 8 - (pictureBoxYel.Width / 2), pictureBoxYel.Location.Y);
            pictureBoxBlc.Location = new Point(this.Width * 4 / 8 - (pictureBoxBlc.Width / 2), pictureBoxBlc.Location.Y);
            pictureBoxRed.Location = new Point(this.Width * 5 / 8 - (pictureBoxRed.Width / 2), pictureBoxRed.Location.Y);
            pictureBoxGrn.Location = new Point(this.Width * 6 / 8 - (pictureBoxGrn.Width / 2), pictureBoxGrn.Location.Y);
            pictureBoxVlt.Location = new Point(this.Width * 7 / 8 - (pictureBoxVlt.Width / 2), pictureBoxVlt.Location.Y);
        }

        private void setPositionToLabelLinkWithPicture()
        {
            labelnbCardBlck.Location = new Point(pictureBoxBlc.Location.X +(pictureBoxBlc.Width/2)-labelnbCardBlck.Height/2,pictureBoxBlc.Location.Y-50);
            labelnbCardBlue.Location = new Point(pictureBoxBlu.Location.X+(pictureBoxBlu.Width/2)-labelnbCardBlue.Height/2,pictureBoxBlu.Location.Y-50);
            labelnbCardWht.Location = new Point(pictureBoxWht.Location.X+(pictureBoxWht.Width/2)-labelnbCardWht.Height/2,pictureBoxWht.Location.Y-50);
            labelnbCardGrn.Location = new Point(pictureBoxGrn.Location.X + (pictureBoxGrn.Width / 2) - labelnbCardGrn.Height / 2, pictureBoxGrn.Location.Y - 50);
            labelnbCardRed.Location = new Point(pictureBoxRed.Location.X + (pictureBoxRed.Width / 2) - labelnbCardRed.Height / 2, pictureBoxRed.Location.Y - 50);
            labelnbCardVlt.Location = new Point(pictureBoxVlt.Location.X + (pictureBoxVlt.Width / 2) - labelnbCardVlt.Height / 2, pictureBoxVlt.Location.Y - 50);
            labelnbCardYell.Location = new Point(pictureBoxYel.Location.X + (pictureBoxYel.Width / 2) - labelnbCardYell.Height / 2, pictureBoxYel.Location.Y - 50);

            labelSlctBlc.Location = new Point(labelnbCardBlck.Location.X, labelnbCardBlck.Location.Y+200);
            labelSlctBlu.Location = new Point(labelnbCardBlue.Location.X, labelnbCardBlue.Location.Y+200);
            labelSlctGrn.Location = new Point(labelnbCardGrn.Location.X, labelnbCardGrn.Location.Y + 200);
            labelSlctRed.Location = new Point(labelnbCardRed.Location.X, labelnbCardRed.Location.Y + 200);
            labelSlctVlt.Location = new Point(labelnbCardVlt.Location.X, labelnbCardVlt.Location.Y + 200);
            labelSlctWht.Location = new Point(labelnbCardWht.Location.X, labelnbCardWht.Location.Y + 200);
            labelSlctYel.Location = new Point(labelnbCardYell.Location.X, labelnbCardYell.Location.Y + 200);
        }

        private void calculPoint()
        {
            nbOfDifferentCards = 0;
            bool FiveSameCards = false;
            foreach (KeyValuePair<Card, int> card in SlctOfCards)
            {
                if (card.Value == 1)
                {
                    nbOfDifferentCards++;
                }
                if (card.Value == 5)
                {
                    FiveSameCards = true;
                }

                /*switch (card.Key.color.ToKnownColor())
                {/*
                    case KnownColor.Blue:
                        if (p.color.ToKnownColor() == KnownColor.DeepSkyBlue)
                        {
                           potentialPoints = 3;
                            break;
                        }
                       break;
                    case KnownColor.Green:
                        if(p.color.Equals(Color.LimeGreen))
                        {
                            potentialPoints = 3;
                            break;
                        }
                        break;
                   case KnownColor.Red:
                        if(p.color.Equals(Color.DarkOrange))
                        {
                           potentialPoints = 3;
                            break;
                        }
                        break;
                    case KnownColor.Yellow:
                        if(p.color.Equals(Color.Gold))
                        {
                            potentialPoints = 3;
                            break;
                        }
                        break;
                    default:
                        potentialPoints = 0;
                        break;
                    */





                if (FiveSameCards)
                {
                    potentialPoints = 7;
                    return;
                }
                switch (nbOfDifferentCards)
                {
                    case 1:
                        potentialPoints = 0;
                        break;
                    case 2:
                        potentialPoints = 0;
                        break ;
                    case 3:
                        potentialPoints = 0;
                        break;
                    case 7:
                        potentialPoints = 50;
                        break;
                    case 5:
                        potentialPoints = 0;
                        break;
                    case 6:
                        potentialPoints = 30;
                        break;
                    case 4:
                        potentialPoints = 10;
                        break;

                }

            }
        }

        private void pictureBoxVlt_Click(object sender, EventArgs e)
        {
            if(p.getNumberOfCards(Color.Violet) > SlctOfCards[findCardWithColor(Color.Violet)] && RemainsEnergy >= 2)
            {
                SlctOfCards[findCardWithColor(Color.Violet)]++;
                RemainsEnergy -= 2;
            }
            calculPoint();
            Refresh();
        }

        private void pictureBoxGrn_Click(object sender, EventArgs e)
        {
            if(p.getNumberOfCards(Color.Green) > SlctOfCards[findCardWithColor(Color.Green)] && RemainsEnergy >= 2)
            {
                SlctOfCards[findCardWithColor(Color.Green)]++;
                RemainsEnergy -= 2;
            }
            calculPoint();
            if (nbOfDifferentCards == 1 && p.color.Equals(Color.LimeGreen))
            {
                potentialPoints = 3;
            }
            Refresh();
        }

        private void pictureBoxBlc_Click(object sender, EventArgs e)
        {
            if(p.getNumberOfCards(Color.Black) > SlctOfCards[findCardWithColor(Color.Black)] && RemainsEnergy >= 2)
            {
                SlctOfCards[findCardWithColor(Color.Black)]++;
                RemainsEnergy -= 2;
            }
            calculPoint();
            Refresh();
        }

        private void pictureBoxRed_Click(object sender, EventArgs e)
        {
            if(p.getNumberOfCards(Color.Red) > SlctOfCards[findCardWithColor(Color.Red)] && RemainsEnergy >= 2)
            {
                SlctOfCards[findCardWithColor(Color.Red)]++;
                RemainsEnergy -= 2;
            }
            
            calculPoint();
            if (nbOfDifferentCards == 1 && p.color.Equals(Color.DarkOrange))
            {
                potentialPoints = 3;
            }
            Refresh();
        }

        private void pictureBoxYel_Click(object sender, EventArgs e)
        {
            if(p.getNumberOfCards(Color.Yellow) > SlctOfCards[findCardWithColor(Color.Yellow)] && RemainsEnergy >= 2)
            {
                SlctOfCards[findCardWithColor(Color.Yellow)]++;
                RemainsEnergy -= 2;
            }

            calculPoint();
            if(nbOfDifferentCards == 1 && p.color.Equals(Color.Gold))
            {
                potentialPoints = 3;
            }
            Refresh();
        }

        private void pictureBoxBlu_Click(object sender, EventArgs e)
        {
            if (p.getNumberOfCards(Color.Blue) > SlctOfCards[findCardWithColor(Color.Blue)] && RemainsEnergy >= 2)
            {
                SlctOfCards[findCardWithColor(Color.Blue)]++;
                RemainsEnergy -= 2;
            }
            calculPoint();
            if(nbOfDifferentCards == 1 && p.color.Equals(Color.DeepSkyBlue))
            {
                potentialPoints = 3;
            }
            Refresh();
        }

        private void pictureBoxWht_Click(object sender, EventArgs e)
        {
            
            if(p.getNumberOfCards(Color.White)> SlctOfCards[findCardWithColor(Color.White)] && RemainsEnergy >= 2)
            {
                SlctOfCards[findCardWithColor(Color.White)]++;
                RemainsEnergy -= 2;
            }
            calculPoint();

            Refresh();
        }



        private Card findCardWithColor(Color c)
        {
            foreach(Card card in SlctOfCards.Keys)
            {
                if(card.color == c)
                {
                    return card;
                }
            }
            return null;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            foreach (Card c in p.deckOfCards.Keys)
            {
                SlctOfCards[c] = 0;
            }
            RemainsEnergy = p.energyToken;
            potentialPoints = 0;
            
        }

        private void buttonCombo_Click(object sender, EventArgs e)
        {
            p.point += potentialPoints;
            potentialPoints = 0;
            p.energyToken = RemainsEnergy;
            Dictionary<Card, int> tempDictionnary = new Dictionary<Card, int>(p.deckOfCards);
            foreach(Card c in tempDictionnary.Keys)
            {
                p.deckOfCards[c] -= SlctOfCards[c];
                Card.cardsDiscardPile.Add(c);
                SlctOfCards[c] = 0;
            }
            getNbOfCards();
            labelnbCardBlck.Text = nbCardBlc.ToString();
            labelnbCardBlue.Text = nbCardBlu.ToString();
            labelnbCardVlt.Text = nbCardVlt.ToString();
            labelnbCardWht.Text = nbCardWht.ToString();
            labelnbCardYell.Text = nbCardYel.ToString();
            labelnbCardGrn.Text = nbCardGrn.ToString();
            labelnbCardRed.Text = nbCardRed.ToString();
            this.Invalidate();
        }
    }
}
