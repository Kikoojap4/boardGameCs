namespace JeuDePlateau
{
    partial class Plateau
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureCard = new System.Windows.Forms.PictureBox();
            this.pictureMap = new System.Windows.Forms.PictureBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonSuivant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMap)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureCard
            // 
            this.pictureCard.BackColor = System.Drawing.Color.Transparent;
            this.pictureCard.Image = global::JeuDePlateau.Properties.Resources.carte_a_jouer;
            this.pictureCard.Location = new System.Drawing.Point(702, 463);
            this.pictureCard.Name = "pictureCard";
            this.pictureCard.Size = new System.Drawing.Size(100, 100);
            this.pictureCard.TabIndex = 20;
            this.pictureCard.TabStop = false;
            this.pictureCard.Click += new System.EventHandler(this.pictureCard_Click);
            // 
            // pictureMap
            // 
            this.pictureMap.BackColor = System.Drawing.Color.Transparent;
            this.pictureMap.Image = global::JeuDePlateau.Properties.Resources.radar;
            this.pictureMap.Location = new System.Drawing.Point(1106, 463);
            this.pictureMap.Name = "pictureMap";
            this.pictureMap.Size = new System.Drawing.Size(100, 100);
            this.pictureMap.TabIndex = 21;
            this.pictureMap.TabStop = false;
            this.pictureMap.Click += new System.EventHandler(this.PictureMap_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(922, 936);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(150, 60);
            this.buttonQuit.TabIndex = 35;
            this.buttonQuit.Text = "Quitter";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonSuivant
            // 
            this.buttonSuivant.Location = new System.Drawing.Point(922, 676);
            this.buttonSuivant.Name = "buttonSuivant";
            this.buttonSuivant.Size = new System.Drawing.Size(75, 23);
            this.buttonSuivant.TabIndex = 37;
            this.buttonSuivant.Text = "Placement terminé";
            this.buttonSuivant.UseVisualStyleBackColor = true;
            this.buttonSuivant.Click += new System.EventHandler(this.buttonTourSuivant_Click);
            // 
            // Plateau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JeuDePlateau.Properties.Resources.naissance_etoiles;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.buttonSuivant);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.pictureMap);
            this.Controls.Add(this.pictureCard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Plateau";
            this.Text = "Plateau";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Plateau_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Plateau_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Plateau_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureCard;
        private System.Windows.Forms.PictureBox pictureMap;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonSuivant;
    }
}

