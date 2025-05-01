namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class GererCuisinierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridViewCuisiniers;
        private System.Windows.Forms.Button btnAjouterCuisinier;
        private System.Windows.Forms.Button btnModifierCuisinier;
        private System.Windows.Forms.Button btnSupprimerCuisinier;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GererCuisinierForm));
            this.dataGridViewCuisiniers = new System.Windows.Forms.DataGridView();
            this.btnAjouterCuisinier = new System.Windows.Forms.Button();
            this.btnModifierCuisinier = new System.Windows.Forms.Button();
            this.btnSupprimerCuisinier = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuisiniers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCuisiniers
            // 
            this.dataGridViewCuisiniers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCuisiniers.Location = new System.Drawing.Point(165, 288);
            this.dataGridViewCuisiniers.Name = "dataGridViewCuisiniers";
            this.dataGridViewCuisiniers.RowHeadersWidth = 51;
            this.dataGridViewCuisiniers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCuisiniers.Size = new System.Drawing.Size(554, 257);
            this.dataGridViewCuisiniers.TabIndex = 0;
            // 
            // btnAjouterCuisinier
            // 
            this.btnAjouterCuisinier.BackColor = System.Drawing.Color.MistyRose;
            this.btnAjouterCuisinier.Location = new System.Drawing.Point(750, 288);
            this.btnAjouterCuisinier.Name = "btnAjouterCuisinier";
            this.btnAjouterCuisinier.Size = new System.Drawing.Size(75, 30);
            this.btnAjouterCuisinier.TabIndex = 1;
            this.btnAjouterCuisinier.Text = "Ajouter";
            this.btnAjouterCuisinier.UseVisualStyleBackColor = false;
            this.btnAjouterCuisinier.Click += new System.EventHandler(this.btnAjouterCuisinier_Click);
            // 
            // btnModifierCuisinier
            // 
            this.btnModifierCuisinier.BackColor = System.Drawing.Color.MistyRose;
            this.btnModifierCuisinier.Location = new System.Drawing.Point(750, 348);
            this.btnModifierCuisinier.Name = "btnModifierCuisinier";
            this.btnModifierCuisinier.Size = new System.Drawing.Size(75, 30);
            this.btnModifierCuisinier.TabIndex = 2;
            this.btnModifierCuisinier.Text = "Modifier";
            this.btnModifierCuisinier.UseVisualStyleBackColor = false;
            this.btnModifierCuisinier.Click += new System.EventHandler(this.btnModifierCuisinier_Click);
            // 
            // btnSupprimerCuisinier
            // 
            this.btnSupprimerCuisinier.BackColor = System.Drawing.Color.MistyRose;
            this.btnSupprimerCuisinier.Location = new System.Drawing.Point(750, 405);
            this.btnSupprimerCuisinier.Name = "btnSupprimerCuisinier";
            this.btnSupprimerCuisinier.Size = new System.Drawing.Size(75, 30);
            this.btnSupprimerCuisinier.TabIndex = 3;
            this.btnSupprimerCuisinier.Text = "Supprimer";
            this.btnSupprimerCuisinier.UseVisualStyleBackColor = false;
            this.btnSupprimerCuisinier.Click += new System.EventHandler(this.btnSupprimerCuisinier_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.MistyRose;
            this.btnAnnuler.Location = new System.Drawing.Point(750, 458);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 30);
            this.btnAnnuler.TabIndex = 4;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // GererCuisinierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimerCuisinier);
            this.Controls.Add(this.btnModifierCuisinier);
            this.Controls.Add(this.btnAjouterCuisinier);
            this.Controls.Add(this.dataGridViewCuisiniers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GererCuisinierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des Cuisiniers";
            this.Load += new System.EventHandler(this.GererCuisinierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuisiniers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}