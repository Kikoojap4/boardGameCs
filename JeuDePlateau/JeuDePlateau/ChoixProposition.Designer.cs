namespace JeuDePlateau
{
    partial class ChoixProposition
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
            this.choixa = new System.Windows.Forms.RadioButton();
            this.choixb = new System.Windows.Forms.RadioButton();
            this.choixc = new System.Windows.Forms.RadioButton();
            this.labelTitre = new System.Windows.Forms.Label();
            this.labelProposition1 = new System.Windows.Forms.Label();
            this.labelProposition2 = new System.Windows.Forms.Label();
            this.labelProposition3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.picturePlayer1 = new System.Windows.Forms.PictureBox();
            this.picturePlayer2 = new System.Windows.Forms.PictureBox();
            this.picturePlayer3 = new System.Windows.Forms.PictureBox();
            this.picturePlayer4 = new System.Windows.Forms.PictureBox();
            this.labelJoueur = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer4)).BeginInit();
            this.SuspendLayout();
            // 
            // choixa
            // 
            this.choixa.AutoSize = true;
            this.choixa.Location = new System.Drawing.Point(133, 165);
            this.choixa.Name = "choixa";
            this.choixa.Size = new System.Drawing.Size(68, 17);
            this.choixa.TabIndex = 0;
            this.choixa.TabStop = true;
            this.choixa.Text = "CHOIX A";
            this.choixa.UseVisualStyleBackColor = true;
            this.choixa.CheckedChanged += new System.EventHandler(this.choixa_CheckedChanged);
            // 
            // choixb
            // 
            this.choixb.AutoSize = true;
            this.choixb.Location = new System.Drawing.Point(298, 165);
            this.choixb.Name = "choixb";
            this.choixb.Size = new System.Drawing.Size(68, 17);
            this.choixb.TabIndex = 1;
            this.choixb.TabStop = true;
            this.choixb.Text = "CHOIX B";
            this.choixb.UseVisualStyleBackColor = true;
            this.choixb.CheckedChanged += new System.EventHandler(this.choixb_CheckedChanged);
            // 
            // choixc
            // 
            this.choixc.AutoSize = true;
            this.choixc.Location = new System.Drawing.Point(499, 165);
            this.choixc.Name = "choixc";
            this.choixc.Size = new System.Drawing.Size(68, 17);
            this.choixc.TabIndex = 2;
            this.choixc.TabStop = true;
            this.choixc.Text = "CHOIX C";
            this.choixc.UseVisualStyleBackColor = true;
            this.choixc.CheckedChanged += new System.EventHandler(this.choixc_CheckedChanged);
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.Location = new System.Drawing.Point(320, 9);
            this.labelTitre.MaximumSize = new System.Drawing.Size(130, 0);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(60, 25);
            this.labelTitre.TabIndex = 3;
            this.labelTitre.Text = "Titre";
            // 
            // labelProposition1
            // 
            this.labelProposition1.AutoSize = true;
            this.labelProposition1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProposition1.Location = new System.Drawing.Point(130, 227);
            this.labelProposition1.MaximumSize = new System.Drawing.Size(120, 0);
            this.labelProposition1.Name = "labelProposition1";
            this.labelProposition1.Size = new System.Drawing.Size(47, 16);
            this.labelProposition1.TabIndex = 4;
            this.labelProposition1.Text = "Choix1";
            // 
            // labelProposition2
            // 
            this.labelProposition2.AutoSize = true;
            this.labelProposition2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProposition2.Location = new System.Drawing.Point(306, 227);
            this.labelProposition2.MaximumSize = new System.Drawing.Size(120, 0);
            this.labelProposition2.Name = "labelProposition2";
            this.labelProposition2.Size = new System.Drawing.Size(47, 16);
            this.labelProposition2.TabIndex = 5;
            this.labelProposition2.Text = "Choix2";
            // 
            // labelProposition3
            // 
            this.labelProposition3.AutoSize = true;
            this.labelProposition3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProposition3.Location = new System.Drawing.Point(496, 227);
            this.labelProposition3.MaximumSize = new System.Drawing.Size(120, 0);
            this.labelProposition3.Name = "labelProposition3";
            this.labelProposition3.Size = new System.Drawing.Size(47, 16);
            this.labelProposition3.TabIndex = 6;
            this.labelProposition3.Text = "Choix3";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(313, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // picturePlayer1
            // 
            this.picturePlayer1.Image = global::JeuDePlateau.Properties.Resources.astronauteStarsDeepSkyBlue;
            this.picturePlayer1.Location = new System.Drawing.Point(53, 329);
            this.picturePlayer1.Name = "picturePlayer1";
            this.picturePlayer1.Size = new System.Drawing.Size(50, 50);
            this.picturePlayer1.TabIndex = 8;
            this.picturePlayer1.TabStop = false;
            // 
            // picturePlayer2
            // 
            this.picturePlayer2.Image = global::JeuDePlateau.Properties.Resources.astronauteStarsLimeGreen;
            this.picturePlayer2.Location = new System.Drawing.Point(228, 329);
            this.picturePlayer2.Name = "picturePlayer2";
            this.picturePlayer2.Size = new System.Drawing.Size(50, 50);
            this.picturePlayer2.TabIndex = 9;
            this.picturePlayer2.TabStop = false;
            // 
            // picturePlayer3
            // 
            this.picturePlayer3.Image = global::JeuDePlateau.Properties.Resources.astronauteStarsDarkOrange;
            this.picturePlayer3.Location = new System.Drawing.Point(410, 329);
            this.picturePlayer3.Name = "picturePlayer3";
            this.picturePlayer3.Size = new System.Drawing.Size(50, 50);
            this.picturePlayer3.TabIndex = 10;
            this.picturePlayer3.TabStop = false;
            // 
            // picturePlayer4
            // 
            this.picturePlayer4.Image = global::JeuDePlateau.Properties.Resources.astronauteStarsGold;
            this.picturePlayer4.Location = new System.Drawing.Point(602, 329);
            this.picturePlayer4.Name = "picturePlayer4";
            this.picturePlayer4.Size = new System.Drawing.Size(50, 50);
            this.picturePlayer4.TabIndex = 11;
            this.picturePlayer4.TabStop = false;
            // 
            // labelJoueur
            // 
            this.labelJoueur.AutoSize = true;
            this.labelJoueur.Font = new System.Drawing.Font("Microsoft YaHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJoueur.Location = new System.Drawing.Point(310, 77);
            this.labelJoueur.Name = "labelJoueur";
            this.labelJoueur.Size = new System.Drawing.Size(70, 22);
            this.labelJoueur.TabIndex = 12;
            this.labelJoueur.Text = "Joueur ";
            // 
            // ChoixProposition
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 491);
            this.ControlBox = false;
            this.Controls.Add(this.labelJoueur);
            this.Controls.Add(this.picturePlayer4);
            this.Controls.Add(this.picturePlayer3);
            this.Controls.Add(this.picturePlayer2);
            this.Controls.Add(this.picturePlayer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelProposition3);
            this.Controls.Add(this.labelProposition2);
            this.Controls.Add(this.labelProposition1);
            this.Controls.Add(this.labelTitre);
            this.Controls.Add(this.choixc);
            this.Controls.Add(this.choixb);
            this.Controls.Add(this.choixa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoixProposition";
            this.ShowInTaskbar = false;
            this.Text = "Sélectionner votre choix";
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePlayer4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton choixa;
        private System.Windows.Forms.RadioButton choixb;
        private System.Windows.Forms.RadioButton choixc;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Label labelProposition1;
        private System.Windows.Forms.Label labelProposition2;
        private System.Windows.Forms.Label labelProposition3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picturePlayer1;
        private System.Windows.Forms.PictureBox picturePlayer2;
        private System.Windows.Forms.PictureBox picturePlayer3;
        private System.Windows.Forms.PictureBox picturePlayer4;
        private System.Windows.Forms.Label labelJoueur;
    }
}