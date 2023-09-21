using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JeuDePlateau
{
    public class Player
    {
        public String name { get; set; }
        public Color color { get; set; }
        Panel panel { get; set; } = new Panel();
        public int point { get; set; }
        public int energyToken { get; set; }
        public int waterToken { get; set; }
        public Image playerImage { get; set; }
        public int dispo { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<Scientist> scientists { get; set; }
        public Dictionary<Card, int> deckOfCards { get; set; }
        public Dictionary<Card, int> nothing { get; set; }

        public Player(string name, Color color, int x, int y)
        {
            scientists = new List<Scientist>();
            this.name = name;
            this.color = color;
            X = x;
            Y = y;
            energyToken = 10;
            waterToken = 10;
            point = 0;
            playerImage = addPicturePlayeur();
            addNumberOfScientists(2);
            dispo = scientists.Count();
            deckOfCards = new Dictionary<Card, int>();
        }

        private Image addPicturePlayeur()
        {
            Image path = null;
            switch (this.color.ToKnownColor())
            {
                case KnownColor.DeepSkyBlue:
                    path = Properties.Resources.astronauteStarsDeepSkyBlue;
                    break;
                case KnownColor.LimeGreen:
                    path = Properties.Resources.astronauteStarsLimeGreen;
                    break;
                case KnownColor.DarkOrange:
                    path = Properties.Resources.astronauteStarsDarkOrange;
                    break;
                case KnownColor.Gold:
                    path = Properties.Resources.astronauteStarsGold;
                    break;
            }
            return path;
        }
        /// <summary>
        /// Ajoute le nombre de scientifique disponible
        /// </summary>
        /// <param name="number"></param>
        public void addNumberOfScientists(int number)
        {
            for (int i = 0; i < number; i++)
            {
                scientists.Add(new Scientist(color));
            }
        }

        /// <summary>
        /// afficher le nombre de scientifiques qui se trouvent actuellement sur le hub
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        public void displayNumberOfScientistOnHub(Graphics g)
        {
            int temp = 0;
            Scientist thescientist = null;
            foreach (Scientist scientist in scientists)
            {
                if (scientist.isOnHub)
                {
                    temp++;
                    thescientist = scientist;
                }
            }
            Font police = new Font("Arial", 50);
            Brush couleur = Brushes.Red;
            if (temp > 0)
            {
                g.DrawString(temp.ToString(), police, couleur, thescientist.uSkin.Location);
            }
        }

        /// <summary>
        /// dessine les joueurs présent dans le jeu
        /// </summary>
        /// <param name="g"></param>
        public void DrawPlayer(Graphics g)
        {

            Font font = new Font("Arial", 12);
            SolidBrush b = new SolidBrush(Color.FromArgb(150, color));

            int x = this.X;
            int y = this.Y;

            panel.Location = new Point(x, y);
            panel.Size = new Size(473, 274);
            g.FillRectangle(b, x, y, panel.Width, panel.Height);
            int margin = 35;
            int xEnergy = x + 15;
            int yEnergy = y + 15;
            int xWater = x + 15;
            int yWater = y + 60;

            DrawCircleIcon(g, xEnergy, yEnergy, margin);
            DrawCircleIcon(g, xWater, yWater, margin);
            Image imageEnergy = Properties.Resources.energy;
            g.DrawImage(imageEnergy, xEnergy + 5, yEnergy + 5);

            Image imageWater = Properties.Resources.eau;
            g.DrawImage(imageWater, xWater + 5, yWater + 5);

            g.DrawString(this.energyToken.ToString(), font, Brushes.Black, xEnergy + 50, yEnergy + imageEnergy.Height / 2);
            g.DrawString(this.waterToken.ToString(), font, Brushes.Black, xWater + 50, yWater + imageWater.Height / 2);


            x = this.X + panel.Width / 2;
            y = this.Y + panel.Height / 24 * 11;
            drawCard(g, x, y, b);

            b.Color = Color.Black;
            string text = "Score : " + this.point.ToString();
            g.DrawString(text, font, b, new PointF(panel.Location.X + panel.Width - 100, panel.Location.Y + 30));

            text = this.name;
            SizeF textSize = g.MeasureString(this.name, font);
            float positionLabelX = panel.Location.X + panel.Width / 2 - textSize.Width / 2;
            float positionLabelY = panel.Location.Y + panel.Height / 4;
            Font boldFont = new Font(font, FontStyle.Bold);
            g.DrawString(text, boldFont, Brushes.White, positionLabelX, positionLabelY);
        }


        public int getNumberOfCards(Color c)
        {

            foreach (KeyValuePair<Card, int> pair in deckOfCards)
            {
                if (pair.Key.color.Equals(c))
                {
                    return pair.Value;
                }
            }
            return 0;
        }

        /// <summary>
        /// Dessine un cercle 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="margin"></param>

        private void DrawCircleIcon(Graphics g, int x, int y, int margin)
        {
            Brush fond = new SolidBrush(Color.White);
            g.FillEllipse(fond, x, y, margin, margin);

        }

        /// <summary>
        /// Dessine les cartes disponible dans le jeu
        /// </summary>
        /// <param name="g"></param>
        /// <param name="xPlayer"></param>
        /// <param name="yPlayer"></param>
        /// <param name="b"></param>
        private void drawCard(Graphics g, int xPlayer, int yPlayer, Brush b)
        {
            int widthCard = 80;
            int heightCard = 120;
            int margin = 10;
            int position3 = margin + widthCard;
            int position2 = position3 - (widthCard / 2 - margin) + widthCard;
            int position1 = position2 - (widthCard / 2 - margin) + widthCard;
            int position4 = widthCard / 2;
            int position5 = margin;
            int position6 = position5 - (widthCard / 2 - margin) + widthCard;
            int position7 = position6 - (widthCard / 2 - margin) + widthCard;

            Font font = new Font("Arial", 12);

            drawRoundedRectangle(g, Brushes.White, new Rectangle(xPlayer - position1, yPlayer + 30, widthCard, heightCard), 10);
            drawRoundedRectangle(g, Brushes.Black, new Rectangle(xPlayer - position2, yPlayer + 20, widthCard, heightCard), 10);
            drawRoundedRectangle(g, Brushes.Purple, new Rectangle(xPlayer - position3, yPlayer + 10, widthCard, heightCard), 10);

            drawRoundedRectangle(g, Brushes.Blue, new Rectangle(xPlayer + position7, yPlayer + 30, widthCard, heightCard), 10);
            drawRoundedRectangle(g, Brushes.Green, new Rectangle(xPlayer + position6, yPlayer + 20, widthCard, heightCard), 10);
            drawRoundedRectangle(g, Brushes.Yellow, new Rectangle(xPlayer + position5, yPlayer + 10, widthCard, heightCard), 10);

            drawRoundedRectangle(g, Brushes.Red, new Rectangle(xPlayer - position4, yPlayer, widthCard, heightCard), 10);

            foreach (KeyValuePair<Card, int> pair in deckOfCards)
            {
                Card card = pair.Key;
                String color = pair.Key.color.Name;
                switch (color)
                {
                    case "White":
                        g.DrawString(pair.Value.ToString(), font, Brushes.Black, xPlayer - position1 + 10, yPlayer + 40);
                        break;
                    case "Black":
                        g.DrawString(pair.Value.ToString(), font, Brushes.White, xPlayer - position2 + 10, yPlayer + 30);
                        break;
                    case "Violet":
                        g.DrawString(pair.Value.ToString(), font, Brushes.White, xPlayer - position3 + 10, yPlayer + 20);
                        break;
                    case "Red":
                        g.DrawString(pair.Value.ToString(), font, Brushes.Black, xPlayer - position4 + 10, yPlayer + 10);
                        break;
                    case "Yellow":
                        g.DrawString(pair.Value.ToString(), font, Brushes.Black, xPlayer + position5 + widthCard - 20, yPlayer + 20);
                        break;
                    case "Green":
                        g.DrawString(pair.Value.ToString(), font, Brushes.Black, xPlayer + position6 + widthCard - 20, yPlayer + 30);
                        break;
                    case "Blue":
                        g.DrawString(pair.Value.ToString(), font, Brushes.Black, xPlayer + position7 + widthCard - 20, yPlayer + 40);
                        break;
                }
            }

        }

        public static void drawRoundedRectangle(Graphics g, Brush b, Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = cornerRadius * 2;
            Rectangle arc = new Rectangle(rect.X, rect.Y, d, d);
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            g.FillPath(b, path);
        }

        public void addCard(Card card)
        {
            if (this.deckOfCards.ContainsKey(card))
            {
                this.deckOfCards[card]++;
            }
            else
            {
                this.deckOfCards.Add(card, 0);
            }
        }

        public void addCardWithColor(Color c)
        {
            Dictionary<Card, int> tempDictionnary = new Dictionary<Card, int>(deckOfCards);
            foreach (Card card in tempDictionnary.Keys)
            {
                if (card.color.Equals(c))
                {
                    deckOfCards[card]++;
                }
            }
        }
    }
}
