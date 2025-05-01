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
    public partial class GererCuisinierForm : Form
    {
        public GererCuisinierForm()
        {
            InitializeComponent();
        }

        private void GererCuisinierForm_Load(object sender, EventArgs e)
        {
            // Charger les cuisiniers existants au démarrage
            ChargerCuisiniers();
        }

        private void ChargerCuisiniers()
        {
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_cuisinier, prenom, email FROM Cuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dataGridViewCuisiniers.Columns.Clear(); // Très important si on recharge plusieurs fois
                            

                            dataGridViewCuisiniers.Rows.Clear();

                            dataGridViewCuisiniers.Columns.Add("id_cuisinier", "ID");
                            dataGridViewCuisiniers.Columns.Add("prenom", "Prénom");
                            dataGridViewCuisiniers.Columns.Add("email", "Email");
                            while (reader.Read())
                            {
                                dataGridViewCuisiniers.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des cuisiniers : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouterCuisinier_Click(object sender, EventArgs e)
        {
            new AjouterCuisinierForm().ShowDialog();
            ChargerCuisiniers(); // Recharger la liste après ajout
        }

        private void btnModifierCuisinier_Click(object sender, EventArgs e)
        {
            if (dataGridViewCuisiniers.SelectedRows.Count > 0)
            {
                int idCuisinier = Convert.ToInt32(dataGridViewCuisiniers.SelectedRows[0].Cells[0].Value);
                new ModifierCuisinierForm(idCuisinier).ShowDialog();
                ChargerCuisiniers(); // Recharger la liste après modification
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un cuisinier à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSupprimerCuisinier_Click(object sender, EventArgs e)
        {
            if (dataGridViewCuisiniers.SelectedRows.Count > 0)
            {
                int idCuisinier = Convert.ToInt32(dataGridViewCuisiniers.SelectedRows[0].Cells[0].Value);

                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Vérification avant suppression
                    string checkQuery = "SELECT COUNT(*) FROM Commande WHERE id_cuisinier = @idCuisinier";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Impossible de supprimer ce cuisinier car il est associé à des commandes.\nVeuillez d'abord supprimer ses commandes.", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Suppression
                            string deleteQuery = "DELETE FROM Cuisinier WHERE id_cuisinier = @idCuisinier";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                                deleteCmd.ExecuteNonQuery();
                                MessageBox.Show("Cuisinier supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ChargerCuisiniers(); // Recharger la liste après suppression
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un cuisinier à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /*private void btnSupprimerCuisinier_Click(object sender, EventArgs e)
        {
            if (dataGridViewCuisiniers.SelectedRows.Count > 0)
            {
                int idCuisinier = Convert.ToInt32(dataGridViewCuisiniers.SelectedRows[0].Cells[0].Value);
                try
                {
                    string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Cuisinier WHERE id_cuisinier = @idCuisinier";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cuisinier supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerCuisiniers(); // Recharger la liste après suppression
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression du cuisinier : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un cuisinier à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }*/

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
