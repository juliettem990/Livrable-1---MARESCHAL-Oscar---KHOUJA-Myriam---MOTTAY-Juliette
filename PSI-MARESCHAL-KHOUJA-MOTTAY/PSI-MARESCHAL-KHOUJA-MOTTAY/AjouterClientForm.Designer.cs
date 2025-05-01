namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class AjouterClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjouterClientForm));
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtCodePostal = new System.Windows.Forms.TextBox();
            this.txtVille = new System.Windows.Forms.TextBox();
            this.txtMetro = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtRue = new System.Windows.Forms.TextBox();
            this.txtNumeroRue = new System.Windows.Forms.TextBox();
            this.lblRue = new System.Windows.Forms.Label();
            this.lblNumeroRue = new System.Windows.Forms.Label();
            this.lblCodePostal = new System.Windows.Forms.Label();
            this.lblVille = new System.Windows.Forms.Label();
            this.lblMetro = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(473, 98);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(100, 22);
            this.txtNom.TabIndex = 0;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(473, 138);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(100, 22);
            this.txtPrenom.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(473, 178);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 22);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(473, 218);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.MistyRose;
            this.btnAjouter.Location = new System.Drawing.Point(392, 486);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(94, 30);
            this.btnAjouter.TabIndex = 4;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // lblNom
            // 
            this.lblNom.BackColor = System.Drawing.Color.MistyRose;
            this.lblNom.Location = new System.Drawing.Point(353, 98);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(100, 23);
            this.lblNom.TabIndex = 5;
            this.lblNom.Text = "Nom :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.BackColor = System.Drawing.Color.MistyRose;
            this.lblPrenom.Location = new System.Drawing.Point(353, 138);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(100, 23);
            this.lblPrenom.TabIndex = 6;
            this.lblPrenom.Text = "Prénom :";
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.MistyRose;
            this.lblEmail.Location = new System.Drawing.Point(353, 178);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 7;
            this.lblEmail.Text = "Email :";
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.MistyRose;
            this.lblPassword.Location = new System.Drawing.Point(353, 218);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 23);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Mot de passe :";
            // 
            // txtCodePostal
            // 
            this.txtCodePostal.Location = new System.Drawing.Point(473, 339);
            this.txtCodePostal.Name = "txtCodePostal";
            this.txtCodePostal.Size = new System.Drawing.Size(100, 22);
            this.txtCodePostal.TabIndex = 9;
            // 
            // txtVille
            // 
            this.txtVille.Location = new System.Drawing.Point(473, 381);
            this.txtVille.Name = "txtVille";
            this.txtVille.Size = new System.Drawing.Size(100, 22);
            this.txtVille.TabIndex = 10;
            // 
            // txtMetro
            // 
            this.txtMetro.Location = new System.Drawing.Point(473, 420);
            this.txtMetro.Name = "txtMetro";
            this.txtMetro.Size = new System.Drawing.Size(100, 22);
            this.txtMetro.TabIndex = 11;
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(473, 458);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(100, 22);
            this.txtTelephone.TabIndex = 12;
            // 
            // txtRue
            // 
            this.txtRue.Location = new System.Drawing.Point(473, 258);
            this.txtRue.Name = "txtRue";
            this.txtRue.Size = new System.Drawing.Size(100, 22);
            this.txtRue.TabIndex = 13;
            // 
            // txtNumeroRue
            // 
            this.txtNumeroRue.Location = new System.Drawing.Point(473, 298);
            this.txtNumeroRue.Name = "txtNumeroRue";
            this.txtNumeroRue.Size = new System.Drawing.Size(100, 22);
            this.txtNumeroRue.TabIndex = 14;
            // 
            // lblRue
            // 
            this.lblRue.AutoSize = true;
            this.lblRue.BackColor = System.Drawing.Color.MistyRose;
            this.lblRue.Location = new System.Drawing.Point(389, 258);
            this.lblRue.Name = "lblRue";
            this.lblRue.Size = new System.Drawing.Size(32, 16);
            this.lblRue.TabIndex = 15;
            this.lblRue.Text = "Rue";
            this.lblRue.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNumeroRue
            // 
            this.lblNumeroRue.AutoSize = true;
            this.lblNumeroRue.BackColor = System.Drawing.Color.MistyRose;
            this.lblNumeroRue.Location = new System.Drawing.Point(369, 298);
            this.lblNumeroRue.Name = "lblNumeroRue";
            this.lblNumeroRue.Size = new System.Drawing.Size(80, 16);
            this.lblNumeroRue.TabIndex = 16;
            this.lblNumeroRue.Text = "NumeroRue";
            // 
            // lblCodePostal
            // 
            this.lblCodePostal.AutoSize = true;
            this.lblCodePostal.BackColor = System.Drawing.Color.MistyRose;
            this.lblCodePostal.Location = new System.Drawing.Point(369, 342);
            this.lblCodePostal.Name = "lblCodePostal";
            this.lblCodePostal.Size = new System.Drawing.Size(78, 16);
            this.lblCodePostal.TabIndex = 17;
            this.lblCodePostal.Text = "CodePostal";
            // 
            // lblVille
            // 
            this.lblVille.AutoSize = true;
            this.lblVille.BackColor = System.Drawing.Color.MistyRose;
            this.lblVille.Location = new System.Drawing.Point(389, 387);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(33, 16);
            this.lblVille.TabIndex = 18;
            this.lblVille.Text = "Ville";
            // 
            // lblMetro
            // 
            this.lblMetro.AutoSize = true;
            this.lblMetro.BackColor = System.Drawing.Color.MistyRose;
            this.lblMetro.Location = new System.Drawing.Point(339, 423);
            this.lblMetro.Name = "lblMetro";
            this.lblMetro.Size = new System.Drawing.Size(128, 16);
            this.lblMetro.TabIndex = 19;
            this.lblMetro.Text = "Metro le plus proche";
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.BackColor = System.Drawing.Color.MistyRose;
            this.lblTelephone.Location = new System.Drawing.Point(353, 464);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(73, 16);
            this.lblTelephone.TabIndex = 20;
            this.lblTelephone.Text = "Telephone";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.MistyRose;
            this.btnAnnuler.Location = new System.Drawing.Point(511, 486);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(100, 30);
            this.btnAnnuler.TabIndex = 21;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // AjouterClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.lblMetro);
            this.Controls.Add(this.lblVille);
            this.Controls.Add(this.lblCodePostal);
            this.Controls.Add(this.lblNumeroRue);
            this.Controls.Add(this.lblRue);
            this.Controls.Add(this.txtNumeroRue);
            this.Controls.Add(this.txtRue);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtMetro);
            this.Controls.Add(this.txtVille);
            this.Controls.Add(this.txtCodePostal);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AjouterClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodePostal;
        private System.Windows.Forms.TextBox txtVille;
        private System.Windows.Forms.TextBox txtMetro;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtRue;
        private System.Windows.Forms.TextBox txtNumeroRue;
        private System.Windows.Forms.Label lblRue;
        private System.Windows.Forms.Label lblNumeroRue;
        private System.Windows.Forms.Label lblCodePostal;
        private System.Windows.Forms.Label lblVille;
        private System.Windows.Forms.Label lblMetro;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Button btnAnnuler;
    }
}