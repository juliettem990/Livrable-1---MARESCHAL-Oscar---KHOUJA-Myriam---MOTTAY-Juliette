namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class GererCommandesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewCommandes;
        private System.Windows.Forms.Button btnAjouterCommande;
        private System.Windows.Forms.Button btnModifierCommande;
        private System.Windows.Forms.Button btnSupprimerCommande;
        private System.Windows.Forms.Button btnAnnuler;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GererCommandesForm));
            this.dataGridViewCommandes = new System.Windows.Forms.DataGridView();
            this.btnAjouterCommande = new System.Windows.Forms.Button();
            this.btnModifierCommande = new System.Windows.Forms.Button();
            this.btnSupprimerCommande = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommandes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCommandes
            // 
            this.dataGridViewCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCommandes.Location = new System.Drawing.Point(133, 261);
            this.dataGridViewCommandes.Name = "dataGridViewCommandes";
            this.dataGridViewCommandes.RowHeadersWidth = 51;
            this.dataGridViewCommandes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCommandes.Size = new System.Drawing.Size(614, 200);
            this.dataGridViewCommandes.TabIndex = 0;
            // 
            // btnAjouterCommande
            // 
            this.btnAjouterCommande.BackColor = System.Drawing.Color.MistyRose;
            this.btnAjouterCommande.Location = new System.Drawing.Point(772, 261);
            this.btnAjouterCommande.Name = "btnAjouterCommande";
            this.btnAjouterCommande.Size = new System.Drawing.Size(75, 30);
            this.btnAjouterCommande.TabIndex = 1;
            this.btnAjouterCommande.Text = "Ajouter";
            this.btnAjouterCommande.UseVisualStyleBackColor = false;
            this.btnAjouterCommande.Click += new System.EventHandler(this.btnAjouterCommande_Click);
            // 
            // btnModifierCommande
            // 
            this.btnModifierCommande.BackColor = System.Drawing.Color.MistyRose;
            this.btnModifierCommande.Location = new System.Drawing.Point(772, 318);
            this.btnModifierCommande.Name = "btnModifierCommande";
            this.btnModifierCommande.Size = new System.Drawing.Size(75, 30);
            this.btnModifierCommande.TabIndex = 2;
            this.btnModifierCommande.Text = "Modifier";
            this.btnModifierCommande.UseVisualStyleBackColor = false;
            this.btnModifierCommande.Click += new System.EventHandler(this.btnModifierCommande_Click);
            // 
            // btnSupprimerCommande
            // 
            this.btnSupprimerCommande.BackColor = System.Drawing.Color.MistyRose;
            this.btnSupprimerCommande.Location = new System.Drawing.Point(772, 378);
            this.btnSupprimerCommande.Name = "btnSupprimerCommande";
            this.btnSupprimerCommande.Size = new System.Drawing.Size(75, 30);
            this.btnSupprimerCommande.TabIndex = 3;
            this.btnSupprimerCommande.Text = "Supprimer";
            this.btnSupprimerCommande.UseVisualStyleBackColor = false;
            this.btnSupprimerCommande.Click += new System.EventHandler(this.btnSupprimerCommande_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.MistyRose;
            this.btnAnnuler.Location = new System.Drawing.Point(772, 431);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 30);
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // GererCommandesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimerCommande);
            this.Controls.Add(this.btnModifierCommande);
            this.Controls.Add(this.btnAjouterCommande);
            this.Controls.Add(this.dataGridViewCommandes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GererCommandesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Commandes";
            this.Load += new System.EventHandler(this.GererCommandesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCommandes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}