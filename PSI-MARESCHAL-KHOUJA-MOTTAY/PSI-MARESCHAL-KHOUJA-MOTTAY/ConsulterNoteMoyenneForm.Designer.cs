namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class ConsulterNoteMoyenneForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

       

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsulterNoteMoyenneForm));
            this.lblNoteMoyenne = new System.Windows.Forms.Label();
            this.dgvAvis = new System.Windows.Forms.DataGridView();
            this.lblTitreAvis = new System.Windows.Forms.Label();
            this.lblAucunAvis = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvis)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNoteMoyenne
            // 
            this.lblNoteMoyenne.AutoSize = true;
            this.lblNoteMoyenne.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNoteMoyenne.Location = new System.Drawing.Point(30, 20);
            this.lblNoteMoyenne.Name = "lblNoteMoyenne";
            this.lblNoteMoyenne.Size = new System.Drawing.Size(0, 28);
            this.lblNoteMoyenne.TabIndex = 0;
            // 
            // dgvAvis
            // 
            this.dgvAvis.AllowUserToAddRows = false;
            this.dgvAvis.AllowUserToDeleteRows = false;
            this.dgvAvis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvis.Location = new System.Drawing.Point(30, 120);
            this.dgvAvis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAvis.Name = "dgvAvis";
            this.dgvAvis.ReadOnly = true;
            this.dgvAvis.RowHeadersWidth = 51;
            this.dgvAvis.RowTemplate.Height = 29;
            this.dgvAvis.Size = new System.Drawing.Size(881, 240);
            this.dgvAvis.TabIndex = 1;
            // 
            // lblTitreAvis
            // 
            this.lblTitreAvis.AutoSize = true;
            this.lblTitreAvis.BackColor = System.Drawing.Color.MistyRose;
            this.lblTitreAvis.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitreAvis.Location = new System.Drawing.Point(30, 60);
            this.lblTitreAvis.Name = "lblTitreAvis";
            this.lblTitreAvis.Size = new System.Drawing.Size(144, 25);
            this.lblTitreAvis.TabIndex = 2;
            this.lblTitreAvis.Text = "Avis des clients";
            // 
            // lblAucunAvis
            // 
            this.lblAucunAvis.AutoSize = true;
            this.lblAucunAvis.BackColor = System.Drawing.Color.MistyRose;
            this.lblAucunAvis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAucunAvis.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAucunAvis.Location = new System.Drawing.Point(30, 90);
            this.lblAucunAvis.Name = "lblAucunAvis";
            this.lblAucunAvis.Size = new System.Drawing.Size(277, 23);
            this.lblAucunAvis.TabIndex = 3;
            this.lblAucunAvis.Text = "Vous n\'avez pas encore reçu d\'avis.";
            this.lblAucunAvis.Visible = false;
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.MistyRose;
            this.btnRetour.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.Location = new System.Drawing.Point(797, 20);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(125, 39);
            this.btnRetour.TabIndex = 4;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // ConsulterNoteMoyenneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 683);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.lblAucunAvis);
            this.Controls.Add(this.lblTitreAvis);
            this.Controls.Add(this.dgvAvis);
            this.Controls.Add(this.lblNoteMoyenne);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ConsulterNoteMoyenneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulter les Avis & Note Moyenne";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNoteMoyenne;
        private System.Windows.Forms.DataGridView dgvAvis;
        private System.Windows.Forms.Label lblTitreAvis;
        private System.Windows.Forms.Label lblAucunAvis;
        private System.Windows.Forms.Button btnRetour;
    }
}