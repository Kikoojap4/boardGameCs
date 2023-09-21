namespace JeuDePlateau
{
    partial class Map
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonQuit = new System.Windows.Forms.Button();
            this.pictureMars = new System.Windows.Forms.PictureBox();
            this.pictureGalaxie = new System.Windows.Forms.PictureBox();
            this.pictureGlassHoleR = new System.Windows.Forms.PictureBox();
            this.pictureGlassHoleL = new System.Windows.Forms.PictureBox();
            this.pictureBlackHole = new System.Windows.Forms.PictureBox();
            this.labelDepart = new System.Windows.Forms.Label();
            this.labelArrivee = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGalaxie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGlassHoleR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGlassHoleL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlackHole)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(886, 989);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(150, 60);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "Retour";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // pictureMars
            // 
            this.pictureMars.Image = global::JeuDePlateau.Properties.Resources.mars;
            this.pictureMars.Location = new System.Drawing.Point(94, 97);
            this.pictureMars.Name = "pictureMars";
            this.pictureMars.Size = new System.Drawing.Size(200, 200);
            this.pictureMars.TabIndex = 1;
            this.pictureMars.TabStop = false;
            // 
            // pictureGalaxie
            // 
            this.pictureGalaxie.Image = global::JeuDePlateau.Properties.Resources.galaxie;
            this.pictureGalaxie.Location = new System.Drawing.Point(1628, 762);
            this.pictureGalaxie.Name = "pictureGalaxie";
            this.pictureGalaxie.Size = new System.Drawing.Size(200, 200);
            this.pictureGalaxie.TabIndex = 2;
            this.pictureGalaxie.TabStop = false;
            // 
            // pictureGlassHoleR
            // 
            this.pictureGlassHoleR.Image = global::JeuDePlateau.Properties.Resources.trouRigth;
            this.pictureGlassHoleR.Location = new System.Drawing.Point(1123, 434);
            this.pictureGlassHoleR.Name = "pictureGlassHoleR";
            this.pictureGlassHoleR.Size = new System.Drawing.Size(100, 100);
            this.pictureGlassHoleR.TabIndex = 3;
            this.pictureGlassHoleR.TabStop = false;
            // 
            // pictureGlassHoleL
            // 
            this.pictureGlassHoleL.Image = global::JeuDePlateau.Properties.Resources.trouLeft;
            this.pictureGlassHoleL.Location = new System.Drawing.Point(700, 434);
            this.pictureGlassHoleL.Name = "pictureGlassHoleL";
            this.pictureGlassHoleL.Size = new System.Drawing.Size(100, 100);
            this.pictureGlassHoleL.TabIndex = 4;
            this.pictureGlassHoleL.TabStop = false;
            // 
            // pictureBlackHole
            // 
            this.pictureBlackHole.Image = global::JeuDePlateau.Properties.Resources.trou_noir;
            this.pictureBlackHole.Location = new System.Drawing.Point(886, 408);
            this.pictureBlackHole.Name = "pictureBlackHole";
            this.pictureBlackHole.Size = new System.Drawing.Size(150, 150);
            this.pictureBlackHole.TabIndex = 5;
            this.pictureBlackHole.TabStop = false;
            // 
            // labelDepart
            // 
            this.labelDepart.AutoSize = true;
            this.labelDepart.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDepart.Location = new System.Drawing.Point(152, 45);
            this.labelDepart.Name = "labelDepart";
            this.labelDepart.Size = new System.Drawing.Size(101, 32);
            this.labelDepart.TabIndex = 6;
            this.labelDepart.Text = "Depart";
            // 
            // labelArrivee
            // 
            this.labelArrivee.AutoSize = true;
            this.labelArrivee.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArrivee.Location = new System.Drawing.Point(1690, 707);
            this.labelArrivee.Name = "labelArrivee";
            this.labelArrivee.Size = new System.Drawing.Size(108, 32);
            this.labelArrivee.TabIndex = 7;
            this.labelArrivee.Text = "Arrivée";
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.labelArrivee);
            this.Controls.Add(this.labelDepart);
            this.Controls.Add(this.pictureBlackHole);
            this.Controls.Add(this.pictureGlassHoleL);
            this.Controls.Add(this.pictureGlassHoleR);
            this.Controls.Add(this.pictureGalaxie);
            this.Controls.Add(this.pictureMars);
            this.Controls.Add(this.buttonQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Map";
            this.Text = "Map";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGalaxie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGlassHoleR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGlassHoleL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlackHole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.PictureBox pictureMars;
        private System.Windows.Forms.PictureBox pictureGalaxie;
        private System.Windows.Forms.PictureBox pictureGlassHoleR;
        private System.Windows.Forms.PictureBox pictureGlassHoleL;
        private System.Windows.Forms.PictureBox pictureBlackHole;
        private System.Windows.Forms.Label labelDepart;
        private System.Windows.Forms.Label labelArrivee;
    }
}