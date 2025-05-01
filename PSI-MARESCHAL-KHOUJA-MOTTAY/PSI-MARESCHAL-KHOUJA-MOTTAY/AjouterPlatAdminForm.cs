using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class AjouterPlatAdminForm : Form
    {
        public AjouterPlatAdminForm()
        {
            InitializeComponent();
        }

        private void btnAjouterPlat_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtNomPlat.Text.Trim();
                string description = txtDescription.Text.Trim();
                decimal prix;

                // Validation des champs
                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(description) || !decimal.TryParse(txtPrix.Text, out prix))
                {
                    MessageBox.Show("Veuillez remplir tous les champs correctement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Requête d'insertion dans la base de données
                    string query = "INSERT INTO Plat (nom, description, prix) VALUES (@nom, @description, @prix)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", nom);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@prix", prix);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Plat ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Ferme le formulaire après l'ajout
                        }
                        else
                        {
                            MessageBox.Show("Une erreur est survenue lors de l'ajout du plat.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout du plat : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme simplement le formulaire sans ajout
        }
    }
}
