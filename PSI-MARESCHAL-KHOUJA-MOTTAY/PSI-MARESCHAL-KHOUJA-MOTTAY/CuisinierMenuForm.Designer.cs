namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class CuisinierMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAjouterPlat;
        private System.Windows.Forms.Button btnMettreAJourPlat;
        private System.Windows.Forms.Button btnValiderCommande;
        private System.Windows.Forms.Button btnNoteMoyenne;
        private System.Windows.Forms.Button btnClassement;
        private System.Windows.Forms.Button btnDeconnexion;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuisinierMenuForm));
            this.btnAjouterPlat = new System.Windows.Forms.Button();
            this.btnMettreAJourPlat = new System.Windows.Forms.Button();
            this.btnValiderCommande = new System.Windows.Forms.Button();
            this.btnNoteMoyenne = new System.Windows.Forms.Button();
            this.btnClassement = new System.Windows.Forms.Button();
            this.btnDeconnexion = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAjouterPlat
            // 
            this.btnAjouterPlat.BackColor = System.Drawing.Color.MistyRose;
            this.btnAjouterPlat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAjouterPlat.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterPlat.Location = new System.Drawing.Point(301, 199);
            this.btnAjouterPlat.Name = "btnAjouterPlat";
            this.btnAjouterPlat.Size = new System.Drawing.Size(381, 40);
            this.btnAjouterPlat.TabIndex = 0;
            this.btnAjouterPlat.Text = "Ajouter un plat";
            this.btnAjouterPlat.UseVisualStyleBackColor = false;
            this.btnAjouterPlat.Click += new System.EventHandler(this.BtnAjouterPlat_Click);
            // 
            // btnMettreAJourPlat
            // 
            this.btnMettreAJourPlat.BackColor = System.Drawing.Color.MistyRose;
            this.btnMettreAJourPlat.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMettreAJourPlat.Location = new System.Drawing.Point(301, 256);
            this.btnMettreAJourPlat.Name = "btnMettreAJourPlat";
            this.btnMettreAJourPlat.Size = new System.Drawing.Size(381, 40);
            this.btnMettreAJourPlat.TabIndex = 1;
            this.btnMettreAJourPlat.Text = "Mettre à jour un plat";
            this.btnMettreAJourPlat.UseVisualStyleBackColor = false;
            this.btnMettreAJourPlat.Click += new System.EventHandler(this.BtnMettreAJourPlat_Click);
            // 
            // btnValiderCommande
            // 
            this.btnValiderCommande.BackColor = System.Drawing.Color.MistyRose;
            this.btnValiderCommande.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderCommande.Location = new System.Drawing.Point(301, 315);
            this.btnValiderCommande.Name = "btnValiderCommande";
            this.btnValiderCommande.Size = new System.Drawing.Size(381, 40);
            this.btnValiderCommande.TabIndex = 2;
            this.btnValiderCommande.Text = "Valider et envoyer une commande";
            this.btnValiderCommande.UseVisualStyleBackColor = false;
            this.btnValiderCommande.Click += new System.EventHandler(this.BtnValiderCommande_Click);
            // 
            // btnNoteMoyenne
            // 
            this.btnNoteMoyenne.BackColor = System.Drawing.Color.MistyRose;
            this.btnNoteMoyenne.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoteMoyenne.Location = new System.Drawing.Point(301, 378);
            this.btnNoteMoyenne.Name = "btnNoteMoyenne";
            this.btnNoteMoyenne.Size = new System.Drawing.Size(381, 40);
            this.btnNoteMoyenne.TabIndex = 3;
            this.btnNoteMoyenne.Text = "Consulter ma note moyenne";
            this.btnNoteMoyenne.UseVisualStyleBackColor = false;
            this.btnNoteMoyenne.Click += new System.EventHandler(this.BtnNoteMoyenne_Click);
            // 
            // btnClassement
            // 
            this.btnClassement.BackColor = System.Drawing.Color.MistyRose;
            this.btnClassement.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassement.Location = new System.Drawing.Point(301, 438);
            this.btnClassement.Name = "btnClassement";
            this.btnClassement.Size = new System.Drawing.Size(381, 40);
            this.btnClassement.TabIndex = 4;
            this.btnClassement.Text = "Voir le classement des cuisiniers";
            this.btnClassement.UseVisualStyleBackColor = false;
            this.btnClassement.Click += new System.EventHandler(this.BtnClassement_Click);
            // 
            // btnDeconnexion
            // 
            this.btnDeconnexion.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeconnexion.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeconnexion.Location = new System.Drawing.Point(327, 499);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(319, 40);
            this.btnDeconnexion.TabIndex = 5;
            this.btnDeconnexion.Text = "Se déconnecter";
            this.btnDeconnexion.UseVisualStyleBackColor = false;
            this.btnDeconnexion.Click += new System.EventHandler(this.BtnDeconnexion_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(385, 51);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(199, 26);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "Bonjour cuisinier !";
            // 
            // CuisinierMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAjouterPlat);
            this.Controls.Add(this.btnMettreAJourPlat);
            this.Controls.Add(this.btnValiderCommande);
            this.Controls.Add(this.btnNoteMoyenne);
            this.Controls.Add(this.btnClassement);
            this.Controls.Add(this.btnDeconnexion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CuisinierMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Cuisinier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
    }
}