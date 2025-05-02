using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSI_MARESCHAL_KHOUJA_MOTTAY;


namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class AjouterPlatForm : Form
    {
        private int idCuisinier;
        private string connectionString = "server=localhost;user=root;database=ta_base;password=;";
        public AjouterPlatForm(int idCuisinier, string connectionString)
        {
            InitializeComponent();
            this.idCuisinier = idCuisinier;
            this.connectionString = connectionString;
        }
        public AjouterPlatForm(int idCuisinier)
        {
            InitializeComponent();
            this.idCuisinier = idCuisinier;
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string typePlat = comboTypePlat.Text.Trim();
            string nationalite = txtNationalite.Text.Trim();
            string ingredients = txtIngredients.Text.Trim();
            #region Test des données saisies
            int nbPortions = 0;
            if (txtPortions.Text.Length == 0 || !int.TryParse(txtPortions.Text, out nbPortions))
            {
                MessageBox.Show("Veuillez entrer un nombre valide pour le nombre de portions.");
                return;
            }
            decimal prix = 0;
            if (txtPrix.Text.Length == 0 || decimal.TryParse(txtPrix.Text, out prix) == false)
            {
                MessageBox.Show("Veuillez entrer un prix valide.");
                return;
            }
            DateTime dateFab = DateTime.MinValue;
            if (dateFabricationPicker.Text.Length == 0 || !DateTime.TryParse(dateFabricationPicker.Text, out dateFab))
            {
                MessageBox.Show("Veuillez entrer une date de fabrication valide.");
                return;
            }
            DateTime datePeremp = DateTime.MinValue;
            if (datePeremptionPicker.Text.Length == 0 || !DateTime.TryParse(datePeremptionPicker.Text, out datePeremp))
            {
                MessageBox.Show("Veuillez entrer une date de péremption valide.");
                return;
            }
            #endregion
            MySqlConnection conn = new MySqlConnection(Program.connectionString);
            conn.Open();
            string query = "INSERT INTO Plat (id_cuisinier, nom, nombre_portion, type_plat, nationalite_plat, prix, ingredients, date_fabrication, date_peremption) " +
                           "VALUES (@Cuisinier, @Nom, @NbPersonnes, @Type, @Nationalite, @Prix, @Ingredients, @DateFabrication, @DatePeremption)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
            cmd.Parameters.AddWithValue("@Nom", nom);
            cmd.Parameters.AddWithValue("@NbPersonnes", nbPortions);
            cmd.Parameters.AddWithValue("@Type", typePlat);
            cmd.Parameters.AddWithValue("@Nationalite", nationalite);
            cmd.Parameters.AddWithValue("@Prix", prix);
            cmd.Parameters.AddWithValue("@Ingredients", ingredients);
            cmd.Parameters.AddWithValue("@DateFabrication", dateFab);
            cmd.Parameters.AddWithValue("@DatePeremption", datePeremp);

            int result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                MessageBox.Show("Plat ajouté avec succès !");
                this.Close();
            }
            else
            {
                MessageBox.Show("Une erreur est survenue lors de l'ajout du plat.");
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

