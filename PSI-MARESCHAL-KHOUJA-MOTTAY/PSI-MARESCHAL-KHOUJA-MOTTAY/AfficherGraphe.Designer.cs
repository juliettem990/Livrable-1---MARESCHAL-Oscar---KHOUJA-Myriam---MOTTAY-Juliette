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
            this.lblInfos = new System.Windows.Forms.Label();
            this.btnCarte = new System.Windows.Forms.Button();
            this.btnItineraire = new System.Windows.Forms.Button();
            this.txtDepart = new System.Windows.Forms.TextBox();
            this.txtArrivee = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblInfos
            // 
            this.lblInfos.Location = new System.Drawing.Point(20, 20);
            this.lblInfos.Name = "lblInfos";
            this.lblInfos.Size = new System.Drawing.Size(300, 20);
            this.lblInfos.TabIndex = 0;
            this.lblInfos.Text = "Chargement...";
            // 
            // btnCarte
            // 
            this.btnCarte.Location = new System.Drawing.Point(23, 100);
            this.btnCarte.Name = "btnCarte";
            this.btnCarte.Size = new System.Drawing.Size(75, 23);
            this.btnCarte.TabIndex = 3;
            this.btnCarte.Text = "Afficher carte";
            this.btnCarte.Click += new System.EventHandler(this.btnCarte_Click);
            // 
            // btnItineraire
            // 
            this.btnItineraire.Location = new System.Drawing.Point(130, 100);
            this.btnItineraire.Name = "btnItineraire";
            this.btnItineraire.Size = new System.Drawing.Size(75, 23);
            this.btnItineraire.TabIndex = 4;
            this.btnItineraire.Text = "Chercher itinéraire";
            this.btnItineraire.Click += new System.EventHandler(this.btnItineraire_Click);
            // 
            // txtDepart
            // 
            this.txtDepart.Location = new System.Drawing.Point(20, 60);
            this.txtDepart.Name = "txtDepart";
            this.txtDepart.Size = new System.Drawing.Size(100, 22);
            this.txtDepart.TabIndex = 1;
            // 
            // txtArrivee
            // 
            this.txtArrivee.Location = new System.Drawing.Point(130, 60);
            this.txtArrivee.Name = "txtArrivee";
            this.txtArrivee.Size = new System.Drawing.Size(100, 22);
            this.txtArrivee.TabIndex = 2;
            // 
            // AfficherGraphe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 450);
            this.Controls.Add(this.lblInfos);
            this.Controls.Add(this.txtDepart);
            this.Controls.Add(this.txtArrivee);
            this.Controls.Add(this.btnCarte);
            this.Controls.Add(this.btnItineraire);
            this.Name = "AfficherGraphe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        

        
    }
}

