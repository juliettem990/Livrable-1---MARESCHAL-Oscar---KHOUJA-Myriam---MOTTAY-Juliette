using System.Windows.Forms;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    partial class AjouterPlatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtPortions;
        private System.Windows.Forms.ComboBox comboTypePlat;
        private System.Windows.Forms.TextBox txtNationalite;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.TextBox txtIngredients;
        private System.Windows.Forms.DateTimePicker dateFabricationPicker;
        private System.Windows.Forms.DateTimePicker datePeremptionPicker;
        private System.Windows.Forms.Button btnAjouter;

        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjouterPlatForm));
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtPortions = new System.Windows.Forms.TextBox();
            this.comboTypePlat = new System.Windows.Forms.ComboBox();
            this.txtNationalite = new System.Windows.Forms.TextBox();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.txtIngredients = new System.Windows.Forms.TextBox();
            this.dateFabricationPicker = new System.Windows.Forms.DateTimePicker();
            this.datePeremptionPicker = new System.Windows.Forms.DateTimePicker();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPortions = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblNationalite = new System.Windows.Forms.Label();
            this.lblPrix = new System.Windows.Forms.Label();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.lblFabrication = new System.Windows.Forms.Label();
            this.lblPeremption = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(397, 202);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(200, 22);
            this.txtNom.TabIndex = 8;
            // 
            // txtPortions
            // 
            this.txtPortions.Location = new System.Drawing.Point(397, 230);
            this.txtPortions.Name = "txtPortions";
            this.txtPortions.Size = new System.Drawing.Size(200, 22);
            this.txtPortions.TabIndex = 9;
            // 
            // comboTypePlat
            // 
            this.comboTypePlat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTypePlat.Items.AddRange(new object[] {
            "Entrée",
            "Plat principal",
            "Dessert"});
            this.comboTypePlat.Location = new System.Drawing.Point(397, 259);
            this.comboTypePlat.Name = "comboTypePlat";
            this.comboTypePlat.Size = new System.Drawing.Size(200, 24);
            this.comboTypePlat.TabIndex = 10;
            // 
            // txtNationalite
            // 
            this.txtNationalite.Location = new System.Drawing.Point(397, 289);
            this.txtNationalite.Name = "txtNationalite";
            this.txtNationalite.Size = new System.Drawing.Size(200, 22);
            this.txtNationalite.TabIndex = 11;
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(397, 317);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Size = new System.Drawing.Size(200, 22);
            this.txtPrix.TabIndex = 12;
            // 
            // txtIngredients
            // 
            this.txtIngredients.Location = new System.Drawing.Point(397, 345);
            this.txtIngredients.Multiline = true;
            this.txtIngredients.Name = "txtIngredients";
            this.txtIngredients.Size = new System.Drawing.Size(200, 60);
            this.txtIngredients.TabIndex = 13;
            // 
            // dateFabricationPicker
            // 
            this.dateFabricationPicker.Location = new System.Drawing.Point(397, 411);
            this.dateFabricationPicker.Name = "dateFabricationPicker";
            this.dateFabricationPicker.Size = new System.Drawing.Size(200, 22);
            this.dateFabricationPicker.TabIndex = 14;
            // 
            // datePeremptionPicker
            // 
            this.datePeremptionPicker.Location = new System.Drawing.Point(397, 439);
            this.datePeremptionPicker.Name = "datePeremptionPicker";
            this.datePeremptionPicker.Size = new System.Drawing.Size(200, 22);
            this.datePeremptionPicker.TabIndex = 15;
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.MistyRose;
            this.btnAjouter.Location = new System.Drawing.Point(440, 504);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(120, 30);
            this.btnAjouter.TabIndex = 16;
            this.btnAjouter.Text = "Ajouter le plat";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // lblNom
            // 
            this.lblNom.BackColor = System.Drawing.Color.MistyRose;
            this.lblNom.Location = new System.Drawing.Point(241, 200);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(150, 20);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom :";
            // 
            // lblPortions
            // 
            this.lblPortions.BackColor = System.Drawing.Color.MistyRose;
            this.lblPortions.Location = new System.Drawing.Point(241, 233);
            this.lblPortions.Name = "lblPortions";
            this.lblPortions.Size = new System.Drawing.Size(150, 20);
            this.lblPortions.TabIndex = 1;
            this.lblPortions.Text = "Portions :";
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.MistyRose;
            this.lblType.Location = new System.Drawing.Point(241, 263);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(150, 20);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type de plat :";
            // 
            // lblNationalite
            // 
            this.lblNationalite.BackColor = System.Drawing.Color.MistyRose;
            this.lblNationalite.Location = new System.Drawing.Point(241, 292);
            this.lblNationalite.Name = "lblNationalite";
            this.lblNationalite.Size = new System.Drawing.Size(150, 20);
            this.lblNationalite.TabIndex = 3;
            this.lblNationalite.Text = "Nationalité :";
            // 
            // lblPrix
            // 
            this.lblPrix.BackColor = System.Drawing.Color.MistyRose;
            this.lblPrix.Location = new System.Drawing.Point(241, 320);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(150, 20);
            this.lblPrix.TabIndex = 4;
            this.lblPrix.Text = "Prix (€) :";
            // 
            // lblIngredients
            // 
            this.lblIngredients.BackColor = System.Drawing.Color.MistyRose;
            this.lblIngredients.Location = new System.Drawing.Point(241, 365);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(150, 20);
            this.lblIngredients.TabIndex = 5;
            this.lblIngredients.Text = "Ingrédients :";
            // 
            // lblFabrication
            // 
            this.lblFabrication.BackColor = System.Drawing.Color.MistyRose;
            this.lblFabrication.Location = new System.Drawing.Point(241, 411);
            this.lblFabrication.Name = "lblFabrication";
            this.lblFabrication.Size = new System.Drawing.Size(150, 20);
            this.lblFabrication.TabIndex = 6;
            this.lblFabrication.Text = "Date fabrication :";
            // 
            // lblPeremption
            // 
            this.lblPeremption.BackColor = System.Drawing.Color.MistyRose;
            this.lblPeremption.Location = new System.Drawing.Point(241, 444);
            this.lblPeremption.Name = "lblPeremption";
            this.lblPeremption.Size = new System.Drawing.Size(150, 20);
            this.lblPeremption.TabIndex = 7;
            this.lblPeremption.Text = "Date péremption :";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.MistyRose;
            this.btnAnnuler.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(801, 31);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(127, 45);
            this.btnAnnuler.TabIndex = 17;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // AjouterPlatForm
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblPortions);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblNationalite);
            this.Controls.Add(this.lblPrix);
            this.Controls.Add(this.lblIngredients);
            this.Controls.Add(this.lblFabrication);
            this.Controls.Add(this.lblPeremption);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtPortions);
            this.Controls.Add(this.comboTypePlat);
            this.Controls.Add(this.txtNationalite);
            this.Controls.Add(this.txtPrix);
            this.Controls.Add(this.txtIngredients);
            this.Controls.Add(this.dateFabricationPicker);
            this.Controls.Add(this.datePeremptionPicker);
            this.Controls.Add(this.btnAjouter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AjouterPlatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajouter un plat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNom;
        private Label lblPortions;
        private Label lblType;
        private Label lblNationalite;
        private Label lblPrix;
        private Label lblIngredients;
        private Label lblFabrication;
        private Label lblPeremption;
        private Button btnAnnuler;
    }
}