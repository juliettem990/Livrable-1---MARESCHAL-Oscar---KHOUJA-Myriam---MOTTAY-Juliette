using System.Windows.Forms;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class AdminMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnGererClients;
        private System.Windows.Forms.Button btnGererCuisiniers;
        private System.Windows.Forms.Button btnGererCommandes;
        private System.Windows.Forms.Button btnQuitter;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMenuForm));
            this.btnGererClients = new System.Windows.Forms.Button();
            this.btnGererCuisiniers = new System.Windows.Forms.Button();
            this.btnGererCommandes = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.lblMessageAdmin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGererClients
            // 
            this.btnGererClients.Location = new System.Drawing.Point(321, 285);
            this.btnGererClients.Name = "btnGererClients";
            this.btnGererClients.Size = new System.Drawing.Size(300, 40);
            this.btnGererClients.TabIndex = 0;
            this.btnGererClients.Text = "Gérer les clients";
            this.btnGererClients.Click += new System.EventHandler(this.btnGererClients_Click);
            // 
            // btnGererCuisiniers
            // 
            this.btnGererCuisiniers.Location = new System.Drawing.Point(321, 335);
            this.btnGererCuisiniers.Name = "btnGererCuisiniers";
            this.btnGererCuisiniers.Size = new System.Drawing.Size(300, 40);
            this.btnGererCuisiniers.TabIndex = 1;
            this.btnGererCuisiniers.Text = "Gérer les cuisiniers";
            this.btnGererCuisiniers.Click += new System.EventHandler(this.btnGererCuisiniers_Click);
            // 
            // btnGererCommandes
            // 
            this.btnGererCommandes.Location = new System.Drawing.Point(321, 385);
            this.btnGererCommandes.Name = "btnGererCommandes";
            this.btnGererCommandes.Size = new System.Drawing.Size(300, 40);
            this.btnGererCommandes.TabIndex = 2;
            this.btnGererCommandes.Text = "Gérer les commandes";
            this.btnGererCommandes.Click += new System.EventHandler(this.btnGererCommandes_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(321, 435);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(300, 40);
            this.btnQuitter.TabIndex = 3;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // lblMessageAdmin
            // 
            this.lblMessageAdmin.AutoSize = true;
            this.lblMessageAdmin.Font = new System.Drawing.Font("MS Reference Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageAdmin.Location = new System.Drawing.Point(339, 90);
            this.lblMessageAdmin.Name = "lblMessageAdmin";
            this.lblMessageAdmin.Size = new System.Drawing.Size(247, 35);
            this.lblMessageAdmin.TabIndex = 4;
            this.lblMessageAdmin.Text = "Bonjour Admin !";
            // 
            // AdminMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.lblMessageAdmin);
            this.Controls.Add(this.btnGererClients);
            this.Controls.Add(this.btnGererCuisiniers);
            this.Controls.Add(this.btnGererCommandes);
            this.Controls.Add(this.btnQuitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Administrateur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMessageAdmin;
    }
}