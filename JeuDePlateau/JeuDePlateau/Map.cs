using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;


namespace JeuDePlateau
{
    public partial class Map : Form
    {

        Pen pen = new Pen(Color.Black, 5);
        private bool shouldDrawPlayer = true;
        public Map()
        {
            InitializeComponent();
            pictureMars.Location = new Point(100, 100);
            pictureGalaxie.Location = new Point(1624, 778);
            pictureBlackHole.Location = new Point(this.Width / 2 - pictureBlackHole.Width / 2, this.Height / 2 - pictureBlackHole.Height / 2);
            pictureGlassHoleR.Location = new Point(pictureBlackHole.Location.X + pictureBlackHole.Width + 50, pictureBlackHole.Location.Y + pictureBlackHole.Height / 2 - pictureGlassHoleR.Height / 2);
            pictureGlassHoleL.Location = new Point(pictureBlackHole.Location.X - pictureGlassHoleL.Width - 50, pictureBlackHole.Location.Y + pictureBlackHole.Height / 2 - pictureGlassHoleL.Height / 2);
            labelDepart.Location = new Point(pictureMars.Location.X + pictureMars.Width / 2 - labelDepart.Width / 2, pictureMars.Location.Y - 20 - labelDepart.Height);
            labelArrivee.Location = new Point(pictureGalaxie.Location.X + pictureGalaxie.Width / 2 - labelArrivee.Width / 2, pictureGalaxie.Location.Y - 20 - labelArrivee.Height);
        }
        /// <summary>
        /// quitte la map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Permet de dessiner les lignes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Draw(object sender, PaintEventArgs e)
        {
            int x = pictureMars.Location.X + pictureMars.Width + 100;
            int y = pictureMars.Location.Y + pictureGalaxie.Height / 2;
            int widthL = pictureGalaxie.Location.X - (pictureMars.Location.X + pictureMars.Width) - 200;
            int widthV = this.Height / 2 - (pictureMars.Location.Y + pictureMars.Height / 2) - 10;
            int widthl = pictureGlassHoleL.Location.X - (pictureMars.Location.X + pictureMars.Width + 100);
            int length = (widthL + widthl + widthV) * 2 + 16;

            DrawLine(e.Graphics, x, y, widthL);


            x = pictureGalaxie.Location.X - 100;
            y = pictureGalaxie.Location.Y + pictureGalaxie.Height / 2;
            DrawLine(e.Graphics, x, y, -widthL);

            x = pictureMars.Location.X + pictureMars.Width + 100;
            DrawLine2(e.Graphics, x, y, -widthV - 16);

            x = pictureGalaxie.Location.X - 100;
            y = pictureMars.Location.Y + pictureMars.Height / 2;
            DrawLine2(e.Graphics, x, y, widthV);

            y = pictureGlassHoleR.Location.Y + pictureGlassHoleR.Height / 2;
            x = pictureMars.Location.X + pictureMars.Width + 100;
            DrawLine(e.Graphics, x, y, widthl);

            x = pictureGalaxie.Location.X - 100;
            DrawLine(e.Graphics, x, y, -widthl);
            if (shouldDrawPlayer)
            {
                drawPlayer(e.Graphics, length, widthL, widthV, widthl);
            }

        }
        /// <summary>
        /// dessine une ligne horisontal
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        private void DrawLine(Graphics g, int x, int y, int width)
        {
            g.DrawLine(pen, x, y, x + width, y);
        }
        /// <summary>
        /// dessine une ligne verticale
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="height"></param>
        private void DrawLine2(Graphics g, int x, int y, int height)
        {
            g.DrawLine(pen, x, y, x, y + height);
        }
        /// <summary>
        /// dessine le joueur en fonction 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="length"></param>
        /// <param name="widthL"></param>
        /// <param name="heigth"></param>
        /// <param name="widthl"></param>
        private void drawPlayer(Graphics g, int length, int widthL, int heigth, int widthl)
        {
            int Case = length / 150;
            int verticalOffset = 0;
            int previousPoint1 = -1;

            foreach (Player player in GameController.players)
            {

                Image imagePion = player.playerImage;
                
                if (player.point != previousPoint1)
                {
                    // Réinitialiser le décalage vertical
                    verticalOffset = 0;
                }


                int point = player.point;
                int yOffset = previousPoint1 == player.point ? verticalOffset * (imagePion.Height + 10) : 0;

                if (point <= widthL / Case)
                {
                    g.DrawImage(imagePion, pictureMars.Location.X + pictureMars.Width + 100 + player.point * Case - Case, pictureMars.Location.Y + pictureMars.Height / 2 - imagePion.Height / 2 + yOffset);
                }
                else if (point < (widthL + heigth) / Case)
                {
                    int test2 = widthL / Case - player.point;
                    g.DrawImage(imagePion, pictureMars.Location.X + pictureMars.Width + 100 + widthL - imagePion.Width / 2 + yOffset, pictureMars.Location.Y + pictureMars.Height / 2 + (test2 * -Case) - Case);
                }
                else if (point < (widthL + heigth + widthl) / Case)
                {
                    int res = ((widthL + heigth) / Case) - player.point;
                    g.DrawImage(imagePion, pictureGalaxie.Location.X - 100 + (res * Case) - Case * 2, pictureGlassHoleR.Location.Y + pictureGlassHoleR.Height / 2 - imagePion.Height / 2 + yOffset);
                }
                else if (point < (widthL + heigth + widthl + widthl) / Case)
                {
                    int res = (widthL + heigth + widthl) / Case - player.point;
                    g.DrawImage(imagePion, pictureGlassHoleL.Location.X + (res * Case) - Case * 2, pictureGlassHoleL.Location.Y + pictureGlassHoleL.Height / 2 - imagePion.Height / 2 + yOffset);
                }
                else if (point < (widthL + heigth + widthl + widthl + heigth) / Case)
                {
                    int res = (widthL + heigth + widthl + widthl) / Case - player.point;
                    g.DrawImage(imagePion, pictureMars.Location.X + pictureMars.Width + 100 - imagePion.Width / 2 + yOffset, pictureGalaxie.Location.Y + pictureGalaxie.Height / 2 - widthl - 16 + (res * -Case));
                }
                else if (point < (widthL + heigth + widthl + widthl + heigth + widthL) / Case)
                {
                    int res = (widthL + heigth + widthl + widthl + heigth) / Case - player.point;
                    g.DrawImage(imagePion, pictureMars.Location.X + pictureMars.Width + 100 + (res * -(Case * 13 / 12)), pictureGalaxie.Location.Y + pictureGalaxie.Height / 2 - imagePion.Height / 2 + yOffset);
                }
                previousPoint1 = player.point;

                if (previousPoint1 == player.point)
                {
                    verticalOffset++;
                }

            }

            shouldDrawPlayer = false;
        }

    }
}
