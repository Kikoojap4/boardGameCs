using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace JeuDePlateau
{
    public partial class Plateau : Form
    {
        public Rectangle rectanglelifeQuarters;
        public Rectangle rectangleResearchLab;
        public Rectangle rectangleRecyclingPlant;
        public Rectangle rectangleEngineRoom;
        private Boolean refresh = false;
        public Scientist selection;
        private Pen pencil = new Pen(Color.Black, 3);
        private bool pawnClick = false;
        public PictureBox getPictureCard { get { return pictureCard; } }
        public PictureBox getPictureMap { get { return pictureMap; } }
        public static Boolean pass = false;
        public static Boolean Start;
        private Boolean fin = true;

        public System.Windows.Forms.Button getButtonQuit { get { return buttonQuit; } }

        public GameController gameController;

        public static int nbrOfPlayers;
        public static int PlateauHeight { get; set; }
        public static int PlateauWidth { get; set; }

        public Plateau()
        {
            InitializeComponent();

            selection = new Scientist(Color.Black);
            this.FormBorderStyle = FormBorderStyle.None;
            Start = false;
            PlateauHeight = this.Height;
            PlateauWidth = this.Width;
            //nbrOfPlayers = gameController.nbOfPlayer;
            int x = this.Width / 2; int y = this.Height / 2; int width = 250; int height = width / 2;

            rectangleEngineRoom = new Rectangle(x - width / 2, (y / 6) * 2 - height / 2, width, height);
            rectangleResearchLab = new Rectangle((x / 8) * 14 - width / 2, y - height / 2, width, height);
            rectangleRecyclingPlant = new Rectangle(x - width / 2, (y / 6) * 10 - height / 2, width, height);
            rectanglelifeQuarters = new Rectangle((x / 8) * 2 - width / 2, y - height / 2, width, height);

            allBackHub();
            foreach (Player player in GameController.players)
            {
                foreach (Scientist scientist in player.scientists)
                {
                    scientist.backToHub();
                }
            }
            this.Invalidate();
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            if (!GameController.playerWin)
            {
                drawPawn(e);
                int x = this.Width / 2; int y = this.Height / 2;
                pictureCard.Location = new Point(x - 100 - 50 - pictureCard.Width, y - pictureCard.Height / 2);
                pictureMap.Location = new Point(x + 100 + 50, y - pictureMap.Height / 2);
                buttonQuit.Location = new Point(x - buttonQuit.Width / 2, y / 6 * 11);

                DrawBestPlayerScore(e.Graphics, GameController.players);
                DrawCircle(e.Graphics, x, y);

                GameController.engineRoom.DrawAction(e.Graphics, rectangleEngineRoom);
                GameController.researchLab.DrawAction(e.Graphics, rectangleResearchLab);
                GameController.recyclingPlant.DrawAction(e.Graphics, rectangleRecyclingPlant);
                GameController.lifeQuarters.DrawAction(e.Graphics, rectanglelifeQuarters);

            }
            else
            {
                MessageBox.Show("Nouvelle partie", "Encore une petite patie");
                GameController.playerWin = false;
                Dispose();
                GameController gameController = new GameController();
                gameController.init();

                gameController.plateau.ShowDialog();
            }
        }

        /// <summary>
        /// Affiche le score du meilleur joueur de la partie
        /// </summary>
        /// <param name="g"></param>
        /// <param name="players"></param>
        public void DrawBestPlayerScore(Graphics g, List<Player> players)
        {
            if (players.Count != 0)
            {
                Player bestPlayer = players.OrderByDescending(p => p.point).First();

                Font font = new Font("Arial", 25);
                Brush brush = Brushes.White;

                String text = "Meilleur joueur : " + bestPlayer.name + " (" + bestPlayer.point.ToString() + ")";
                SizeF textSize = g.MeasureString(text, font);
                float positionLabelX = this.Location.X + this.Width / 2 - textSize.Width / 2;
                float positionLabelY = this.Location.Y + 24;
                g.DrawString(text, font, brush, positionLabelX, positionLabelY);
            }

        }


        private void DrawCircle(Graphics g, int x, int y)
        {
            int radius = 100;
            Pen pencil = new Pen(Color.Black, 3);
            g.DrawEllipse(pencil, x - radius, y - radius, radius * 2, radius * 2);
            pencil.Dispose();
        }

        public void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PictureMap_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.ShowDialog();
        }



        private void Plateau_MouseDown(object sender, MouseEventArgs e)
        {
            selection = Selection(e.Location);
            if (selection != null)
            {
                pawnClick = true;
            }
        }

        private void Plateau_MouseMove(object sender, MouseEventArgs e)
        {
            if (pawnClick)
            {
                selection.uSkin = new Rectangle(e.Location.X - 25, e.Location.Y - 25, 50, 50);
                this.Invalidate();
                return;
            }
        }

        private void Plateau_MouseUp(object sender, MouseEventArgs e)
        {
            if (pawnClick)
            {
                if (rectangleEngineRoom.Contains(e.Location) || rectangleResearchLab.Contains(e.Location) || rectangleRecyclingPlant.Contains(e.Location) || rectanglelifeQuarters.Contains(e.Location))
                {
                    selection.isOnHub = false;
                    switch (e.Location)
                    {
                        case var location when rectanglelifeQuarters.Contains(location):
                            PanwInRoom(selection, GameController.lifeQuarters);
                            selection = null;
                            break;
                        case var location when rectangleResearchLab.Contains(location):
                            PanwInRoom(selection, GameController.researchLab);
                            selection = null;
                            break;
                        case var location when rectangleRecyclingPlant.Contains(location):
                            PanwInRoom(selection, GameController.recyclingPlant);
                            selection = null;
                            break;
                        case var location when rectangleEngineRoom.Contains(location):
                            PanwInRoom(selection, GameController.engineRoom);
                            selection = null;
                            break;
                    }
                    pawnClick = false;
                    pass = true;
                    selection = null;
                }
                else
                {
                    MessageBox.Show("Impossible de poser votre pion içi", "Attention");
                    selection.backToHub();
                    this.Invalidate();
                    pawnClick = false;
                    selection = null;
                }
                return;
            }
        }

        private Scientist Selection(Point p)
        {
            Scientist scient = null;
            int i = 0;
            while (i < GameController.players.Count() && scient == null)
            {
                int j = 0;
                while (j < GameController.players[i].scientists.Count() && scient == null)
                {
                    if (contain(p, GameController.players[i].scientists[j]))
                    {
                        if (GameController.players[i].scientists[j].color.Equals(GameController.scientistColor) && GameController.players[i].scientists[j].isDejaClick == false)
                        {
                            scient = GameController.players[i].scientists[j];
                        }
                    }
                    j++;
                }
                i++;
            }
            return scient;
        }

        private bool contain(Point mouse, Scientist scient)
        {
            if (mouse.X > scient.uSkin.X && mouse.X < scient.uSkin.X + scient.uSkin.Width)
            {
                if (mouse.Y > scient.uSkin.Y && mouse.Y < scient.uSkin.Y + scient.uSkin.Height)
                {
                    return true;
                }
            }
            return false;
        }

        private void PanwInRoom(Scientist scient, Room r)
        {
            Boolean res = r.AddScientistToTheRoom(scient);
            if (!res)
            {
                MessageBox.Show("Vous ne pouvez poser le pion ici car la salle " + r.name.Text + " est pleine ", "Attention");
                scient.backToHub();
                this.Invalidate();

            }
            else
            {
                MessageBox.Show("Vous avez posé votre pion dans la salle " + r.name.Text, "Bien joué");
                scient.isDejaClick = true;
                foreach (Player p in GameController.players)
                {
                    foreach (Scientist scientist in p.scientists)
                    {
                        if (scientist.color.Equals(scient.color))
                        {
                            p.dispo--;
                            break;
                        }
                    }
                }
                GameController.switchColor(GameController.scientistColor);
            }

        }

        private bool IsMouseOverZones(Point mousePosition)
        {
            int x = this.Width / 2; int y = this.Height / 2;
            Rectangle lifeQuartersZone = new Rectangle((x / 8) * 2, y, 250, 250 / 2);
            Rectangle researchLabZone = new Rectangle((x / 8) * 14, y, 250, 250 / 2);
            Rectangle recyclingPlantZone = new Rectangle(x, (y / 6) * 2, 250, 250 / 2);
            Rectangle engineRoomZone = new Rectangle(x, (y / 6) * 10, 250, 250 / 2);

            if (lifeQuartersZone.Contains(mousePosition))
            {
                return true;
            }
            else if (researchLabZone.Contains(mousePosition))
            {
                return true;
            }
            else if (recyclingPlantZone.Contains(mousePosition))
            {
                return true;
            }
            else if (engineRoomZone.Contains(mousePosition))
            {
                return true;
            }
            return false;
        }

        private void drawPawn(PaintEventArgs e)
        {
            foreach (Player p in GameController.players)
            {
                p.DrawPlayer(e.Graphics);
                foreach (Scientist s in p.scientists)
                {
                    if (refresh)
                    {
                        s.backToHub();
                    }
                    e.Graphics.DrawImage(s.skin, s.uSkin);
                    //System.Drawing.Image imagePion = System.Drawing.Image.FromFile(s.skin);
                }
                p.displayNumberOfScientistOnHub(e.Graphics);

            }
            if (refresh)
            {
                this.Invalidate();
                refresh = false;
            }
        }



        private void buttonTourSuivant_Click(object sender, EventArgs e)
        {

            foreach (Player p in GameController.players)
            {
                foreach (Scientist s in p.scientists)
                {
                    if (s.isDejaClick == false)
                    {
                        fin = false;
                    }
                }
            }
            if (fin)
            {
                GameController gameController = new GameController();
                gameController.Revolution();
                this.Invalidate();
                if (gameController.verifPlayerWin())
                {
                    GameController.playerWin = true;
                }

            }
            else
            {
                MessageBox.Show("Placer tout les pions avant de passer aux action", "Attention");
            }
        }


        public void allBackHub()
        {
            foreach (Player p in GameController.players)
            {
                foreach (Scientist s in p.scientists)
                {
                    s.backToHub();
                    s.isDejaClick = false;
                }
            }
            this.Invalidate();
        }

        private void pictureCard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Le nombre de cartes restantes est : " + Card.cardsPick.Count());
        }
    }

}
