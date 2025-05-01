using System.Windows.Forms;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class ClientMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button btnCommanderPlat;
        private Button btnVoirCommandes;
        private Button btnValiderReception;
        private Button btnNoterCuisinier;
        private Button btnRecommandations;
        private Button btnDeconnexion;
        //private System.Windows.Forms.Label lblMessage;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMenuForm));
            this.btnCommanderPlat = new System.Windows.Forms.Button();
            this.btnVoirCommandes = new System.Windows.Forms.Button();
            this.btnValiderReception = new System.Windows.Forms.Button();
            this.btnNoterCuisinier = new System.Windows.Forms.Button();
            this.btnRecommandations = new System.Windows.Forms.Button();
            this.btnDeconnexion = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCommanderPlat
            // 
            this.btnCommanderPlat.BackColor = System.Drawing.Color.MistyRose;
            this.btnCommanderPlat.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommanderPlat.Location = new System.Drawing.Point(332, 180);
            this.btnCommanderPlat.Name = "btnCommanderPlat";
            this.btnCommanderPlat.Size = new System.Drawing.Size(297, 40);
            this.btnCommanderPlat.TabIndex = 0;
            this.btnCommanderPlat.Text = "Commander un plat";
            this.btnCommanderPlat.UseVisualStyleBackColor = false;
            this.btnCommanderPlat.Click += new System.EventHandler(this.btnCommanderPlat_Click);
            // 
            // btnVoirCommandes
            // 
            this.btnVoirCommandes.BackColor = System.Drawing.Color.MistyRose;
            this.btnVoirCommandes.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoirCommandes.Location = new System.Drawing.Point(332, 236);
            this.btnVoirCommandes.Name = "btnVoirCommandes";
            this.btnVoirCommandes.Size = new System.Drawing.Size(297, 40);
            this.btnVoirCommandes.TabIndex = 1;
            this.btnVoirCommandes.Text = "Voir mes commandes";
            this.btnVoirCommandes.UseVisualStyleBackColor = false;
            this.btnVoirCommandes.Click += new System.EventHandler(this.btnVoirCommandes_Click);
            // 
            // btnValiderReception
            // 
            this.btnValiderReception.BackColor = System.Drawing.Color.MistyRose;
            this.btnValiderReception.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderReception.Location = new System.Drawing.Point(332, 292);
            this.btnValiderReception.Name = "btnValiderReception";
            this.btnValiderReception.Size = new System.Drawing.Size(297, 40);
            this.btnValiderReception.TabIndex = 2;
            this.btnValiderReception.Text = "Valider réception commande";
            this.btnValiderReception.UseVisualStyleBackColor = false;
            this.btnValiderReception.Click += new System.EventHandler(this.btnValiderReception_Click);
            // 
            // btnNoterCuisinier
            // 
            this.btnNoterCuisinier.BackColor = System.Drawing.Color.MistyRose;
            this.btnNoterCuisinier.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoterCuisinier.Location = new System.Drawing.Point(332, 351);
            this.btnNoterCuisinier.Name = "btnNoterCuisinier";
            this.btnNoterCuisinier.Size = new System.Drawing.Size(297, 40);
            this.btnNoterCuisinier.TabIndex = 3;
            this.btnNoterCuisinier.Text = "Noter un cuisinier";
            this.btnNoterCuisinier.UseVisualStyleBackColor = false;
            this.btnNoterCuisinier.Click += new System.EventHandler(this.btnNoterCuisinier_Click);
            // 
            // btnRecommandations
            // 
            this.btnRecommandations.BackColor = System.Drawing.Color.MistyRose;
            this.btnRecommandations.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecommandations.Location = new System.Drawing.Point(332, 411);
            this.btnRecommandations.Name = "btnRecommandations";
            this.btnRecommandations.Size = new System.Drawing.Size(297, 40);
            this.btnRecommandations.TabIndex = 4;
            this.btnRecommandations.Text = "Voir mes recommandations";
            this.btnRecommandations.UseVisualStyleBackColor = false;
            this.btnRecommandations.Click += new System.EventHandler(this.btnRecommandations_Click);
            // 
            // btnDeconnexion
            // 
            this.btnDeconnexion.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeconnexion.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeconnexion.Location = new System.Drawing.Point(332, 470);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(297, 40);
            this.btnDeconnexion.TabIndex = 5;
            this.btnDeconnexion.Text = "Déconnexion";
            this.btnDeconnexion.UseVisualStyleBackColor = false;
            this.btnDeconnexion.Click += new System.EventHandler(this.btnDeconnexion_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(430, 49);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(107, 26);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Bonjour !";
            // 
            // ClientMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnCommanderPlat);
            this.Controls.Add(this.btnVoirCommandes);
            this.Controls.Add(this.btnValiderReception);
            this.Controls.Add(this.btnNoterCuisinier);
            this.Controls.Add(this.btnRecommandations);
            this.Controls.Add(this.btnDeconnexion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblMessage;
    }
}