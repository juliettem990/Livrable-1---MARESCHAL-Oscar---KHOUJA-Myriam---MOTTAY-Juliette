namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class RecommandationsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.ListView listViewRecommandations;
        private System.Windows.Forms.ColumnHeader columnNom;
        private System.Windows.Forms.ColumnHeader columnNote;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecommandationsForm));
            this.listViewRecommandations = new System.Windows.Forms.ListView();
            this.columnNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRetour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewRecommandations
            // 
            this.listViewRecommandations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNom,
            this.columnNote});
            this.listViewRecommandations.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewRecommandations.FullRowSelect = true;
            this.listViewRecommandations.GridLines = true;
            this.listViewRecommandations.HideSelection = false;
            this.listViewRecommandations.Location = new System.Drawing.Point(121, 395);
            this.listViewRecommandations.Name = "listViewRecommandations";
            this.listViewRecommandations.Size = new System.Drawing.Size(731, 187);
            this.listViewRecommandations.TabIndex = 0;
            this.listViewRecommandations.UseCompatibleStateImageBehavior = false;
            this.listViewRecommandations.View = System.Windows.Forms.View.Details;
            // 
            // columnNom
            // 
            this.columnNom.Text = "Cuisinier";
            this.columnNom.Width = 374;
            // 
            // columnNote
            // 
            this.columnNote.Text = "Note Moyenne";
            this.columnNote.Width = 293;
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.MistyRose;
            this.btnRetour.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.Location = new System.Drawing.Point(802, 23);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(121, 37);
            this.btnRetour.TabIndex = 1;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // RecommandationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.listViewRecommandations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecommandationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recommandation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRetour;
    }
}