namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class NoterCuisinierForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtCommandeId;
        private System.Windows.Forms.NumericUpDown numNote;
        private System.Windows.Forms.Button btnNoter;
        private System.Windows.Forms.Label lblCommande;
        private System.Windows.Forms.Label lblNote;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoterCuisinierForm));
            this.txtCommandeId = new System.Windows.Forms.TextBox();
            this.numNote = new System.Windows.Forms.NumericUpDown();
            this.btnNoter = new System.Windows.Forms.Button();
            this.lblCommande = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            this.txtCommentaire = new System.Windows.Forms.TextBox();
            this.lblCommentaire = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numNote)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCommandeId
            // 
            this.txtCommandeId.Location = new System.Drawing.Point(349, 318);
            this.txtCommandeId.Name = "txtCommandeId";
            this.txtCommandeId.Size = new System.Drawing.Size(150, 22);
            this.txtCommandeId.TabIndex = 0;
            // 
            // numNote
            // 
            this.numNote.Location = new System.Drawing.Point(349, 398);
            this.numNote.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNote.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNote.Name = "numNote";
            this.numNote.Size = new System.Drawing.Size(120, 22);
            this.numNote.TabIndex = 1;
            this.numNote.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnNoter
            // 
            this.btnNoter.BackColor = System.Drawing.Color.MistyRose;
            this.btnNoter.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoter.Location = new System.Drawing.Point(439, 437);
            this.btnNoter.Name = "btnNoter";
            this.btnNoter.Size = new System.Drawing.Size(120, 30);
            this.btnNoter.TabIndex = 2;
            this.btnNoter.Text = "Noter";
            this.btnNoter.UseVisualStyleBackColor = false;
            this.btnNoter.Click += new System.EventHandler(this.btnNoter_Click);
            // 
            // lblCommande
            // 
            this.lblCommande.AutoSize = true;
            this.lblCommande.BackColor = System.Drawing.Color.Transparent;
            this.lblCommande.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommande.Location = new System.Drawing.Point(146, 318);
            this.lblCommande.Name = "lblCommande";
            this.lblCommande.Size = new System.Drawing.Size(198, 26);
            this.lblCommande.TabIndex = 3;
            this.lblCommande.Text = "ID de commande :";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(269, 394);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(75, 26);
            this.lblNote.TabIndex = 4;
            this.lblNote.Text = "Note :";
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.MistyRose;
            this.btnRetour.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.Location = new System.Drawing.Point(776, 23);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(153, 39);
            this.btnRetour.TabIndex = 5;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // txtCommentaire
            // 
            this.txtCommentaire.Location = new System.Drawing.Point(350, 361);
            this.txtCommentaire.Name = "txtCommentaire";
            this.txtCommentaire.Size = new System.Drawing.Size(460, 22);
            this.txtCommentaire.TabIndex = 6;
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.AutoSize = true;
            this.lblCommentaire.BackColor = System.Drawing.Color.Transparent;
            this.lblCommentaire.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommentaire.Location = new System.Drawing.Point(180, 356);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(164, 26);
            this.lblCommentaire.TabIndex = 7;
            this.lblCommentaire.Text = "Commentaire :";
            this.lblCommentaire.Click += new System.EventHandler(this.lblCommentaire_Click);
            // 
            // NoterCuisinierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.lblCommentaire);
            this.Controls.Add(this.txtCommentaire);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.txtCommandeId);
            this.Controls.Add(this.numNote);
            this.Controls.Add(this.btnNoter);
            this.Controls.Add(this.lblCommande);
            this.Controls.Add(this.lblNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoterCuisinierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Noter un cuisinier";
            ((System.ComponentModel.ISupportInitialize)(this.numNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.TextBox txtCommentaire;
        private System.Windows.Forms.Label lblCommentaire;
    }
}