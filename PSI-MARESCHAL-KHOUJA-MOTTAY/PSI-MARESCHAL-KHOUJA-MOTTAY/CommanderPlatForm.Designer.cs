using System.Windows.Forms;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class CommanderPlatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listPlats;
        private System.Windows.Forms.NumericUpDown numPortions;
        private System.Windows.Forms.Button btnCommander;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommanderPlatForm));
            this.listPlats = new System.Windows.Forms.ListView();
            this.numPortions = new System.Windows.Forms.NumericUpDown();
            this.btnCommander = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPortions)).BeginInit();
            this.SuspendLayout();
            // 
            // listPlats
            // 
            this.listPlats.FullRowSelect = true;
            this.listPlats.HideSelection = false;
            this.listPlats.Location = new System.Drawing.Point(208, 268);
            this.listPlats.Name = "listPlats";
            this.listPlats.Size = new System.Drawing.Size(503, 258);
            this.listPlats.TabIndex = 0;
            this.listPlats.UseCompatibleStateImageBehavior = false;
            this.listPlats.View = System.Windows.Forms.View.Details;
            // 
            // numPortions
            // 
            this.numPortions.Location = new System.Drawing.Point(311, 536);
            this.numPortions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPortions.Name = "numPortions";
            this.numPortions.Size = new System.Drawing.Size(120, 22);
            this.numPortions.TabIndex = 1;
            this.numPortions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCommander
            // 
            this.btnCommander.BackColor = System.Drawing.Color.MistyRose;
            this.btnCommander.Location = new System.Drawing.Point(441, 536);
            this.btnCommander.Name = "btnCommander";
            this.btnCommander.Size = new System.Drawing.Size(120, 30);
            this.btnCommander.TabIndex = 2;
            this.btnCommander.Text = "Commander";
            this.btnCommander.UseVisualStyleBackColor = false;
            this.btnCommander.Click += new System.EventHandler(this.btnCommander_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.BackColor = System.Drawing.Color.MistyRose;
            this.btnRetour.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetour.Location = new System.Drawing.Point(790, 35);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(138, 40);
            this.btnRetour.TabIndex = 3;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = false;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // CommanderPlatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.listPlats);
            this.Controls.Add(this.numPortions);
            this.Controls.Add(this.btnCommander);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommanderPlatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commander un plat";
            ((System.ComponentModel.ISupportInitialize)(this.numPortions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRetour;
    }
}