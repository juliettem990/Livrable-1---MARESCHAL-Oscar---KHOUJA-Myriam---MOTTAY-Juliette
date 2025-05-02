using System.Windows.Forms;
using System;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class MettreAJourPlatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView lstPlats;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.Button btnModifier;

        

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MettreAJourPlatForm));
            this.lstPlats = new System.Windows.Forms.ListView();
            this.lblPrix = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstPlats
            // 
            this.lstPlats.FullRowSelect = true;
            this.lstPlats.HideSelection = false;
            this.lstPlats.Location = new System.Drawing.Point(261, 187);
            this.lstPlats.Name = "lstPlats";
            this.lstPlats.Size = new System.Drawing.Size(500, 200);
            this.lstPlats.TabIndex = 0;
            this.lstPlats.UseCompatibleStateImageBehavior = false;
            this.lstPlats.View = System.Windows.Forms.View.Details;
            // 
            // lblPrix
            // 
            this.lblPrix.BackColor = System.Drawing.Color.MistyRose;
            this.lblPrix.Location = new System.Drawing.Point(261, 407);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(100, 20);
            this.lblPrix.TabIndex = 1;
            this.lblPrix.Text = "Nouveau prix :";
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(371, 407);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(100, 22);
            this.txtPrix.TabIndex = 2;
            // 
            // lblQuantite
            // 
            this.lblQuantite.BackColor = System.Drawing.Color.MistyRose;
            this.lblQuantite.Location = new System.Drawing.Point(261, 437);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(120, 20);
            this.lblQuantite.TabIndex = 3;
            this.lblQuantite.Text = "Nouvelles portions :";
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(391, 437);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(100, 22);
            this.txtQuantite.TabIndex = 4;
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.MistyRose;
            this.btnModifier.Location = new System.Drawing.Point(261, 477);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(100, 30);
            this.btnModifier.TabIndex = 5;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.MistyRose;
            this.btnAnnuler.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(773, 27);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(153, 40);
            this.btnAnnuler.TabIndex = 6;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // MettreAJourPlatForm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.lstPlats);
            this.Controls.Add(this.lblPrix);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.lblQuantite);
            this.Controls.Add(this.txtQuantite);
            this.Controls.Add(this.btnModifier);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MettreAJourPlatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mettre à jour un plat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAnnuler;
    }
}