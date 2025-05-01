namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class SupprimerPlatAdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblPlatId;
        private System.Windows.Forms.TextBox txtPlatId;
        private System.Windows.Forms.Button btnSupprimerPlat;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupprimerPlatAdminForm));
            this.lblPlatId = new System.Windows.Forms.Label();
            this.txtPlatId = new System.Windows.Forms.TextBox();
            this.btnSupprimerPlat = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlatId
            // 
            this.lblPlatId.Location = new System.Drawing.Point(20, 20);
            this.lblPlatId.Name = "lblPlatId";
            this.lblPlatId.Size = new System.Drawing.Size(120, 20);
            this.lblPlatId.TabIndex = 0;
            this.lblPlatId.Text = "ID du Plat";
            // 
            // txtPlatId
            // 
            this.txtPlatId.Location = new System.Drawing.Point(160, 20);
            this.txtPlatId.Name = "txtPlatId";
            this.txtPlatId.Size = new System.Drawing.Size(200, 22);
            this.txtPlatId.TabIndex = 1;
            // 
            // btnSupprimerPlat
            // 
            this.btnSupprimerPlat.Location = new System.Drawing.Point(160, 60);
            this.btnSupprimerPlat.Name = "btnSupprimerPlat";
            this.btnSupprimerPlat.Size = new System.Drawing.Size(100, 30);
            this.btnSupprimerPlat.TabIndex = 2;
            this.btnSupprimerPlat.Text = "Supprimer Plat";
            this.btnSupprimerPlat.Click += new System.EventHandler(this.btnSupprimerPlat_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(270, 60);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(100, 30);
            this.btnAnnuler.TabIndex = 3;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // SupprimerPlatAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(400, 120);
            this.Controls.Add(this.lblPlatId);
            this.Controls.Add(this.txtPlatId);
            this.Controls.Add(this.btnSupprimerPlat);
            this.Controls.Add(this.btnAnnuler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SupprimerPlatAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supprimer Plat (Admin)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}