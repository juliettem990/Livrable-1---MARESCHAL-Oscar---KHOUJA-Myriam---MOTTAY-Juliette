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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "RegisterForm";

            this.lblTypeUtilisateur = new System.Windows.Forms.Label();
            this.lblTypeUtilisateur.Text = "Type d'utilisateur :";
            this.lblTypeUtilisateur.Location = new System.Drawing.Point(20, 20);
            this.lblTypeUtilisateur.Size = new System.Drawing.Size(150, 20);

            this.comboType = new System.Windows.Forms.ComboBox();
            this.comboType.Items.AddRange(new object[] { "Client", "Cuisinier" });
            this.comboType.Location = new System.Drawing.Point(180, 20);
            this.comboType.Size = new System.Drawing.Size(150, 20);
            this.comboType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboType.SelectedIndexChanged += new System.EventHandler(this.comboType_SelectedIndexChanged);

            this.lblTypeClient = new System.Windows.Forms.Label();
            this.lblTypeClient.Text = "Type de client :";
            this.lblTypeClient.Location = new System.Drawing.Point(20, 50);
            this.lblTypeClient.Size = new System.Drawing.Size(150, 20);

            this.comboClient = new System.Windows.Forms.ComboBox();
            this.comboClient.Items.AddRange(new object[] { "Particulier", "Entreprise" });
            this.comboClient.Location = new System.Drawing.Point(180, 50);
            this.comboClient.Size = new System.Drawing.Size(150, 20);
            this.comboClient.DropDownStyle = ComboBoxStyle.DropDownList;
            /*
                        int y = 80;
                        string[] labels = { "Nom", "Prénom", "Email", "Téléphone", "Mot de passe", "Ville", "Rue", "Numéro de rue", "Code postal", "Métro le plus proche" };
                        TextBox[] textBoxes = new TextBox[labels.Length];
                        this.textFields = new Dictionary<string, TextBox>();

                        for (int i = 0; i < labels.Length; i++)
                        {
                            Label lbl = new Label();
                            lbl.Text = labels[i] + " :";
                            lbl.Location = new System.Drawing.Point(20, y + i * 30);
                            lbl.Size = new System.Drawing.Size(150, 20);
                            this.Controls.Add(lbl);

                            TextBox txt = new TextBox();
                            txt.Name = "txt" + labels[i].Replace(" ", "");
                            txt.Location = new System.Drawing.Point(180, y + i * 30);
                            txt.Size = new System.Drawing.Size(200, 20);
                            this.Controls.Add(txt);

                            this.textFields.Add(labels[i], txt);
                            textBoxes[i] = txt;
                        }

                        this.lblSpecialite = new System.Windows.Forms.Label();
                        this.lblSpecialite.Text = "Spécialité culinaire :";
                        this.lblSpecialite.Location = new System.Drawing.Point(20, y + labels.Length * 30);
                        this.lblSpecialite.Size = new System.Drawing.Size(150, 20);
                        this.lblSpecialite.Visible = false;

                        this.txtSpecialite = new System.Windows.Forms.TextBox();
                        this.txtSpecialite.Location = new System.Drawing.Point(180, y + labels.Length * 30);
                        this.txtSpecialite.Size = new System.Drawing.Size(200, 20);
                        this.txtSpecialite.Visible = false;

                        this.btnInscription = new System.Windows.Forms.Button();
                        this.btnInscription.Text = "S'inscrire";
                        this.btnInscription.Location = new System.Drawing.Point(180, y + (labels.Length + 2) * 30);
                        this.btnInscription.Size = new System.Drawing.Size(100, 30);
                        this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);

                        this.Controls.Add(this.lblTypeUtilisateur);
                        this.Controls.Add(this.comboType);
                        this.Controls.Add(this.lblTypeClient);
                        this.Controls.Add(this.comboClient);
                        this.Controls.Add(this.lblSpecialite);
                        this.Controls.Add(this.txtSpecialite);
                        this.Controls.Add(this.btnInscription);
                        */
            // === CHAMPS DE TEXTE COMMUNS ===
            // Position de départ pour les champs de texte
            int yPosition = 80;

            // Champ "Nom"
            Label lblNom = new Label();
            lblNom.Text = "Nom :";
            lblNom.Location = new System.Drawing.Point(20, yPosition);
            lblNom.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblNom);

            TextBox txtNom = new TextBox();
            txtNom.Name = "txtNom";
            txtNom.Location = new System.Drawing.Point(180, yPosition);
            txtNom.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtNom);

            // Champ "Prénom"
            yPosition += 30;
            Label lblPrenom = new Label();
            lblPrenom.Text = "Prénom :";
            lblPrenom.Location = new System.Drawing.Point(20, yPosition);
            lblPrenom.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblPrenom);

            TextBox txtPrenom = new TextBox();
            txtPrenom.Name = "txtPrenom";
            txtPrenom.Location = new System.Drawing.Point(180, yPosition);
            txtPrenom.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtPrenom);

            // Champ "Email"
            yPosition += 30;
            Label lblEmail = new Label();
            lblEmail.Text = "Email :";
            lblEmail.Location = new System.Drawing.Point(20, yPosition);
            lblEmail.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblEmail);

            TextBox txtEmail = new TextBox();
            txtEmail.Name = "txtEmail";
            txtEmail.Location = new System.Drawing.Point(180, yPosition);
            txtEmail.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtEmail);

            // Champ "Téléphone"
            yPosition += 30;
            Label lblTel = new Label();
            lblTel.Text = "Téléphone :";
            lblTel.Location = new System.Drawing.Point(20, yPosition);
            lblTel.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblTel);

            TextBox txtTel = new TextBox();
            txtTel.Name = "txtTel";
            txtTel.Location = new System.Drawing.Point(180, yPosition);
            txtTel.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtTel);

            // Champ "Mot de passe"
            yPosition += 30;
            Label lblMotDePasse = new Label();
            lblMotDePasse.Text = "Mot de passe :";
            lblMotDePasse.Location = new System.Drawing.Point(20, yPosition);
            lblMotDePasse.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblMotDePasse);

            TextBox txtMotDePasse = new TextBox();
            txtMotDePasse.Name = "txtMotDePasse";
            txtMotDePasse.Location = new System.Drawing.Point(180, yPosition);
            txtMotDePasse.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtMotDePasse);

            // Champ "Ville"
            yPosition += 30;
            Label lblVille = new Label();
            lblVille.Text = "Ville :";
            lblVille.Location = new System.Drawing.Point(20, yPosition);
            lblVille.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblVille);

            TextBox txtVille = new TextBox();
            txtVille.Name = "txtVille";
            txtVille.Location = new System.Drawing.Point(180, yPosition);
            txtVille.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtVille);

            // Champ "Rue"
            yPosition += 30;
            Label lblRue = new Label();
            lblRue.Text = "Rue :";
            lblRue.Location = new System.Drawing.Point(20, yPosition);
            lblRue.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblRue);

            TextBox txtRue = new TextBox();
            txtRue.Name = "txtRue";
            txtRue.Location = new System.Drawing.Point(180, yPosition);
            txtRue.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtRue);

            // Champ "Numéro de rue"
            yPosition += 30;
            Label lblNumRue = new Label();
            lblNumRue.Text = "Numéro de rue :";
            lblNumRue.Location = new System.Drawing.Point(20, yPosition);
            lblNumRue.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblNumRue);

            TextBox txtNumRue = new TextBox();
            txtNumRue.Name = "txtNumRue";
            txtNumRue.Location = new System.Drawing.Point(180, yPosition);
            txtNumRue.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtNumRue);

            // Champ "Code postal"
            yPosition += 30;
            Label lblCodePostal = new Label();
            lblCodePostal.Text = "Code postal :";
            lblCodePostal.Location = new System.Drawing.Point(20, yPosition);
            lblCodePostal.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblCodePostal);

            TextBox txtCodePostal = new TextBox();
            txtCodePostal.Name = "txtCodePostal";
            txtCodePostal.Location = new System.Drawing.Point(180, yPosition);
            txtCodePostal.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtCodePostal);

            // Champ "Métro le plus proche"
            yPosition += 30;
            Label lblMetro = new Label();
            lblMetro.Text = "Métro le plus proche :";
            lblMetro.Location = new System.Drawing.Point(20, yPosition);
            lblMetro.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(lblMetro);

            TextBox txtMetro = new TextBox();
            txtMetro.Name = "txtMetro";
            txtMetro.Location = new System.Drawing.Point(180, yPosition);
            txtMetro.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(txtMetro);

            // === SPÉCIALITÉ CULINAIRE ===
            yPosition += 30;
            this.lblSpecialite = new System.Windows.Forms.Label();
            this.lblSpecialite.Text = "Spécialité culinaire :";
            this.lblSpecialite.Location = new System.Drawing.Point(20, yPosition);
            this.lblSpecialite.Size = new System.Drawing.Size(150, 20);
            this.lblSpecialite.Visible = false;

            this.txtSpecialite = new System.Windows.Forms.TextBox();
            this.txtSpecialite.Location = new System.Drawing.Point(180, yPosition);
            this.txtSpecialite.Size = new System.Drawing.Size(200, 20);
            this.txtSpecialite.Visible = false;

            // === BOUTON D'INSCRIPTION ===
            yPosition += 30;
            this.btnInscription = new System.Windows.Forms.Button();
            this.btnInscription.Text = "S'inscrire";
            this.btnInscription.Location = new System.Drawing.Point(180, yPosition);
            this.btnInscription.Size = new System.Drawing.Size(100, 30);
            this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);

            this.btnRetour = new System.Windows.Forms.Button();
            this.btnRetour.Text = "Retour";
            this.btnRetour.Location = new System.Drawing.Point(180, yPosition + 40);  // Positionner le bouton sous les champs
            this.btnRetour.Size = new System.Drawing.Size(100, 30);


        }

        #endregion
    }
}