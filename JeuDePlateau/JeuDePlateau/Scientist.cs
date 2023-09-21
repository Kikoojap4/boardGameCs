
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JeuDePlateau
{
    public class Scientist
    {
        public Color color { get; set; }
        public Image skin { get; }
        public bool isOnHub { get; set; }

        public bool isDejaClick = false;
        public Rectangle uSkin { get; set; }

        public Scientist(Color color)
        {
            switch (color.ToKnownColor())
            {
                case KnownColor.DeepSkyBlue:
                    skin = Properties.Resources.astronauteDeepSkyBlue;
                    break;
                case KnownColor.LimeGreen:
                    skin = Properties.Resources.astronauteLimeGreen;
                    break;
                case KnownColor.DarkOrange:
                    skin = Properties.Resources.astronauteDarkOrange;
                    break;
                case KnownColor.Gold:
                    skin = Properties.Resources.astronauteGold;
                    break;
            }
            this.color = color;
        }


        /*
        * Permet au scientist de retourner au hub central
        */
        public void backToHub()
        {
            switch (this.color.Name)
            {
                case "DeepSkyBlue":
                    //this.uSkin.Offset(new Point((Plateau.PlateauWidth / 2) - 70, (Plateau.PlateauHeight / 2) - 70));
                    uSkin = new Rectangle((Plateau.PlateauWidth / 2) - 70, (Plateau.PlateauHeight / 2) - 70, 50, 50);
                    break;
                case "LimeGreen":
                    //this.uSkin.Offset(new Point((Plateau.PlateauWidth / 2) - 70, (Plateau.PlateauHeight / 2) - 70));
                    uSkin = new Rectangle((Plateau.PlateauWidth / 2) + 20, (Plateau.PlateauHeight / 2) - 70, 50, 50);
                    //coord = ((Plateau.PlateauWidth / 2) + 20, (Plateau.PlateauHeight / 2) - 70);
                    break;
                case "DarkOrange":
                    uSkin = new Rectangle((Plateau.PlateauWidth / 2) + 20, (Plateau.PlateauHeight / 2) + 20, 50, 50);
                    //coord = ((Plateau.PlateauWidth / 2) + 20, (Plateau.PlateauHeight / 2) + 20);
                    break;
                case "Gold":
                    uSkin = new Rectangle((Plateau.PlateauWidth / 2) - 70, (Plateau.PlateauHeight / 2) + 20, 50, 50);
                    //coord = ((Plateau.PlateauWidth / 2) - 70, (Plateau.PlateauHeight / 2) + 20);
                    break;
            }
        }
    }
}
