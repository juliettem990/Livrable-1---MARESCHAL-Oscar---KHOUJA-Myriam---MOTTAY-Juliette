using System.Collections.Generic;
using System.Windows.Forms;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTypeUtilisateur;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.Label lblTypeClient;
        private System.Windows.Forms.ComboBox comboClient;
        private System.Windows.Forms.Label lblSpecialite;
        private System.Windows.Forms.TextBox txtSpecialite;
        private System.Windows.Forms.Button btnInscription;
        private System.Windows.Forms.Button btnRetour;  // Bouton retour
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblRue;
        private System.Windows.Forms.Label lblNumeroRue;
        private System.Windows.Forms.Label lblCodePostal;
        private System.Windows.Forms.Label lblVille;
        private System.Windows.Forms.Label lblMetro;
        


        private Dictionary<string, TextBox> textFields;

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
        /*private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.SuspendLayout();
            // 
            // RegisterForm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.ResumeLayout(false);

        }*/
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.lblTypeUtilisateur = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.lblTypeClient = new System.Windows.Forms.Label();
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.lblSpecialite = new System.Windows.Forms.Label();
            this.txtSpecialite = new System.Windows.Forms.TextBox();
            this.btnInscription = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblVille = new System.Windows.Forms.Label();
            this.txtVille = new System.Windows.Forms.TextBox();
            this.lblRue = new System.Windows.Forms.Label();
            this.txtRue = new System.Windows.Forms.TextBox();
            this.lblNumeroRue = new System.Windows.Forms.Label();
            this.txtNumeroRue = new System.Windows.Forms.TextBox();
            this.lblCodePostal = new System.Windows.Forms.Label();
            this.txtCodePostal = new System.Windows.Forms.TextBox();
            this.lblMetro = new System.Windows.Forms.Label();
            this.txtMetro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTypeUtilisateur
            // 
            this.lblTypeUtilisateur.AutoSize = true;
            this.lblTypeUtilisateur.BackColor = System.Drawing.Color.MistyRose;
            this.lblTypeUtilisateur.Location = new System.Drawing.Point(324, 140);
            this.lblTypeUtilisateur.Name = "lblTypeUtilisateur";
            this.lblTypeUtilisateur.Size = new System.Drawing.Size(109, 16);
            this.lblTypeUtilisateur.TabIndex = 0;
            this.lblTypeUtilisateur.Text = "Type d\'utilisateur";
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "Client",
            "Cuisinier"});
            this.comboType.Location = new System.Drawing.Point(442, 137);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(121, 24);
            this.comboType.TabIndex = 1;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.comboType_SelectedIndexChanged);
            // 
            // lblTypeClient
            // 
            this.lblTypeClient.AutoSize = true;
            this.lblTypeClient.BackColor = System.Drawing.Color.MistyRose;
            this.lblTypeClient.Location = new System.Drawing.Point(324, 176);
            this.lblTypeClient.Name = "lblTypeClient";
            this.lblTypeClient.Size = new System.Drawing.Size(75, 16);
            this.lblTypeClient.TabIndex = 2;
            this.lblTypeClient.Text = "Type Client";
            // 
            // comboClient
            // 
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Items.AddRange(new object[] {
            "Particulier",
            "Professionnel"});
            this.comboClient.Location = new System.Drawing.Point(442, 170);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(121, 24);
            this.comboClient.TabIndex = 3;
            // 
            // lblSpecialite
            // 
            this.lblSpecialite.AutoSize = true;
            this.lblSpecialite.BackColor = System.Drawing.Color.MistyRose;
            this.lblSpecialite.Location = new System.Drawing.Point(324, 211);
            this.lblSpecialite.Name = "lblSpecialite";
            this.lblSpecialite.Size = new System.Drawing.Size(67, 16);
            this.lblSpecialite.TabIndex = 4;
            this.lblSpecialite.Text = "Spécialité";
            // 
            // txtSpecialite
            // 
            this.txtSpecialite.Location = new System.Drawing.Point(430, 208);
            this.txtSpecialite.Name = "txtSpecialite";
            this.txtSpecialite.Size = new System.Drawing.Size(200, 22);
            this.txtSpecialite.TabIndex = 5;
            // 
            // btnInscription
            // 
            this.btnInscription.BackColor = System.Drawing.Color.MistyRose;
            this.btnInscription.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscription.Location = new System.Drawing.Point(358, 552);
            this.btnInscription.Name = "btnInscription";
            this.btnInscription.Size = new System.Drawing.Size(120, 41);
            this.btnInscription.TabIndex = 6;
            this.btnInscription.Text = "S\'inscrire";
            this.btnInscription.UseVisualStyleBackColor = false;
            this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.MistyRose;
            this.btnRetour.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.Location = new System.Drawing.Point(504, 552);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(114, 41);
            this.btnRetour.TabIndex = 7;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lblNom
            // 
            this.lblNom.BackColor = System.Drawing.Color.MistyRose;
            this.lblNom.Location = new System.Drawing.Point(324, 100);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(100, 23);
            this.lblNom.TabIndex = 8;
            this.lblNom.Text = "Nom:";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(430, 101);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 22);
            this.txtNom.TabIndex = 9;
            // 
            // lblPrenom
            // 
            this.lblPrenom.BackColor = System.Drawing.Color.MistyRose;
            this.lblPrenom.Location = new System.Drawing.Point(324, 54);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(100, 23);
            this.lblPrenom.TabIndex = 10;
            this.lblPrenom.Text = "Prénom:";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(430, 55);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(200, 22);
            this.txtPrenom.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.MistyRose;
            this.lblEmail.Location = new System.Drawing.Point(324, 323);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(430, 320);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 13;
            // 
            // lblTelephone
            // 
            this.lblTelephone.BackColor = System.Drawing.Color.MistyRose;
            this.lblTelephone.Location = new System.Drawing.Point(324, 285);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(100, 23);
            this.lblTelephone.TabIndex = 14;
            this.lblTelephone.Text = "Téléphone:";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(430, 286);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(200, 22);
            this.txtTelephone.TabIndex = 15;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.MistyRose;
            this.lblPassword.Location = new System.Drawing.Point(324, 250);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 23);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Mot de passe:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(430, 247);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.TabIndex = 17;
            // 
            // lblVille
            // 
            this.lblVille.BackColor = System.Drawing.Color.MistyRose;
            this.lblVille.Location = new System.Drawing.Point(324, 432);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(100, 23);
            this.lblVille.TabIndex = 18;
            this.lblVille.Text = "Ville:";
            // 
            // txtVille
            // 
            this.txtVille.Location = new System.Drawing.Point(430, 433);
            this.txtVille.Name = "txtVille";
            this.txtVille.Size = new System.Drawing.Size(200, 22);
            this.txtVille.TabIndex = 19;
            // 
            // lblRue
            // 
            this.lblRue.BackColor = System.Drawing.Color.MistyRose;
            this.lblRue.Location = new System.Drawing.Point(324, 364);
            this.lblRue.Name = "lblRue";
            this.lblRue.Size = new System.Drawing.Size(100, 23);
            this.lblRue.TabIndex = 20;
            this.lblRue.Text = "Rue:";
            // 
            // txtRue
            // 
            this.txtRue.Location = new System.Drawing.Point(430, 364);
            this.txtRue.Name = "txtRue";
            this.txtRue.Size = new System.Drawing.Size(200, 22);
            this.txtRue.TabIndex = 21;
            // 
            // lblNumeroRue
            // 
            this.lblNumeroRue.BackColor = System.Drawing.Color.MistyRose;
            this.lblNumeroRue.Location = new System.Drawing.Point(324, 398);
            this.lblNumeroRue.Name = "lblNumeroRue";
            this.lblNumeroRue.Size = new System.Drawing.Size(100, 23);
            this.lblNumeroRue.TabIndex = 22;
            this.lblNumeroRue.Text = "Numéro de rue:";
            // 
            // txtNumeroRue
            // 
            this.txtNumeroRue.Location = new System.Drawing.Point(430, 399);
            this.txtNumeroRue.Name = "txtNumeroRue";
            this.txtNumeroRue.Size = new System.Drawing.Size(200, 22);
            this.txtNumeroRue.TabIndex = 23;
            // 
            // lblCodePostal
            // 
            this.lblCodePostal.BackColor = System.Drawing.Color.MistyRose;
            this.lblCodePostal.Location = new System.Drawing.Point(324, 467);
            this.lblCodePostal.Name = "lblCodePostal";
            this.lblCodePostal.Size = new System.Drawing.Size(100, 23);
            this.lblCodePostal.TabIndex = 24;
            this.lblCodePostal.Text = "Code Postal:";
            // 
            // txtCodePostal
            // 
            this.txtCodePostal.Location = new System.Drawing.Point(430, 464);
            this.txtCodePostal.Name = "txtCodePostal";
            this.txtCodePostal.Size = new System.Drawing.Size(200, 22);
            this.txtCodePostal.TabIndex = 25;
            // 
            // lblMetro
            // 
            this.lblMetro.BackColor = System.Drawing.Color.MistyRose;
            this.lblMetro.Location = new System.Drawing.Point(324, 503);
            this.lblMetro.Name = "lblMetro";
            this.lblMetro.Size = new System.Drawing.Size(100, 23);
            this.lblMetro.TabIndex = 26;
            this.lblMetro.Text = "Métro le plus proche:";
            // 
            // txtMetro
            // 
            this.txtMetro.Location = new System.Drawing.Point(430, 500);
            this.txtMetro.Name = "txtMetro";
            this.txtMetro.Size = new System.Drawing.Size(200, 22);
            this.txtMetro.TabIndex = 27;
            // 
            // RegisterForm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblVille);
            this.Controls.Add(this.txtVille);
            this.Controls.Add(this.lblRue);
            this.Controls.Add(this.txtRue);
            this.Controls.Add(this.lblNumeroRue);
            this.Controls.Add(this.txtNumeroRue);
            this.Controls.Add(this.lblCodePostal);
            this.Controls.Add(this.txtCodePostal);
            this.Controls.Add(this.lblMetro);
            this.Controls.Add(this.txtMetro);
            this.Controls.Add(this.lblTypeUtilisateur);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.lblTypeClient);
            this.Controls.Add(this.comboClient);
            this.Controls.Add(this.lblSpecialite);
            this.Controls.Add(this.txtSpecialite);
            this.Controls.Add(this.btnInscription);
            this.Controls.Add(this.btnRetour);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.Text = "Formulaire d\'Inscription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
    }
}