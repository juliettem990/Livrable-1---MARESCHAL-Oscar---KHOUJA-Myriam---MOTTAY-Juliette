namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class ModifierPlatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNomPlat;
        private System.Windows.Forms.TextBox txtNomPlat;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.Button btnModifier;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifierPlatForm));
            this.lblNomPlat = new System.Windows.Forms.Label();
            this.txtNomPlat = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrix = new System.Windows.Forms.Label();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNomPlat
            // 
            this.lblNomPlat.BackColor = System.Drawing.Color.MistyRose;
            this.lblNomPlat.Location = new System.Drawing.Point(256, 313);
            this.lblNomPlat.Name = "lblNomPlat";
            this.lblNomPlat.Size = new System.Drawing.Size(120, 20);
            this.lblNomPlat.TabIndex = 0;
            this.lblNomPlat.Text = "Nom du Plat";
            // 
            // txtNomPlat
            // 
            this.txtNomPlat.Location = new System.Drawing.Point(396, 313);
            this.txtNomPlat.Name = "txtNomPlat";
            this.txtNomPlat.Size = new System.Drawing.Size(200, 22);
            this.txtNomPlat.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.MistyRose;
            this.lblDescription.Location = new System.Drawing.Point(256, 353);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 20);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(396, 353);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // lblPrix
            // 
            this.lblPrix.BackColor = System.Drawing.Color.MistyRose;
            this.lblPrix.Location = new System.Drawing.Point(256, 433);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(120, 20);
            this.lblPrix.TabIndex = 4;
            this.lblPrix.Text = "Prix (€)";
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(396, 433);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(100, 22);
            this.txtPrix.TabIndex = 5;
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.MistyRose;
            this.btnModifier.Location = new System.Drawing.Point(396, 473);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(100, 30);
            this.btnModifier.TabIndex = 6;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.MistyRose;
            this.btnAnnuler.Location = new System.Drawing.Point(506, 473);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(100, 30);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // ModifierPlatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.lblNomPlat);
            this.Controls.Add(this.txtNomPlat);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPrix);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAnnuler);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModifierPlatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier Plat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}