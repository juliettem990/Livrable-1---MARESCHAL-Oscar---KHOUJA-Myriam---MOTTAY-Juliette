using System.Windows.Forms;
using System;
using System.Drawing;
using PSI_MARESCHAL_KHOUJA_MOTTAY;


namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class AfficherGraphe : Form
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblInfos;
        private System.Windows.Forms.TextBox txtDepart;
        private System.Windows.Forms.TextBox txtArrivee;
        private System.Windows.Forms.Button btnCarte;
        private System.Windows.Forms.Button btnItineraire;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AfficherGraphe));
            this.lblInfos = new System.Windows.Forms.Label();
            this.btnCarte = new System.Windows.Forms.Button();
            this.btnItineraire = new System.Windows.Forms.Button();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.txtArrivee = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInfos
            // 
            this.lblInfos.BackColor = System.Drawing.Color.Transparent;
            this.lblInfos.Location = new System.Drawing.Point(12, 9);
            this.lblInfos.Name = "lblInfos";
            this.lblInfos.Size = new System.Drawing.Size(300, 59);
            this.lblInfos.TabIndex = 0;
            this.lblInfos.Text = "Chargement...";
            this.lblInfos.Click += new System.EventHandler(this.lblInfos_Click);
            // 
            // btnCarte
            // 
            this.btnCarte.BackColor = System.Drawing.Color.MistyRose;
            this.btnCarte.Location = new System.Drawing.Point(82, 123);
            this.btnCarte.Name = "btnCarte";
            this.btnCarte.Size = new System.Drawing.Size(75, 23);
            this.btnCarte.TabIndex = 3;
            this.btnCarte.Text = "Afficher carte";
            this.btnCarte.UseVisualStyleBackColor = false;
            this.btnCarte.Click += new System.EventHandler(this.btnCarte_Click);
            // 
            // btnItineraire
            // 
            this.btnItineraire.BackColor = System.Drawing.Color.MistyRose;
            this.btnItineraire.Location = new System.Drawing.Point(167, 123);
            this.btnItineraire.Name = "btnItineraire";
            this.btnItineraire.Size = new System.Drawing.Size(75, 23);
            this.btnItineraire.TabIndex = 4;
            this.btnItineraire.Text = "Chercher itinéraire";
            this.btnItineraire.UseVisualStyleBackColor = false;
            this.btnItineraire.Click += new System.EventHandler(this.btnItineraire_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(57, 83);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(100, 22);
            this.txtDepart.TabIndex = 1;
            // 
            // txtArrivee
            // 
            this.txtArrivee.Location = new System.Drawing.Point(167, 83);
            this.txtArrivee.Name = "txtArrivee";
            this.txtArrivee.Size = new System.Drawing.Size(100, 22);
            this.txtArrivee.TabIndex = 2;
            // 
            // AfficherGraphe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(344, 177);
            this.Controls.Add(this.lblInfos);
            this.Controls.Add(this.txtDepart);
            this.Controls.Add(this.txtArrivee);
            this.Controls.Add(this.btnCarte);
            this.Controls.Add(this.btnItineraire);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AfficherGraphe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itinéraire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        

        
    }
}

