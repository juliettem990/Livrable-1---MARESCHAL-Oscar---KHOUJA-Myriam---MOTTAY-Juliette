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
    public partial class ModifierPlatForm : Form
    {
        private int idPlat;
        public ModifierPlatForm(int platId)
        {
            InitializeComponent();
            idPlat = platId;
            LoadPlatData();
        }
        private void LoadPlatData()
        {
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT nom, description, prix FROM Plat WHERE id_plat = @idPlat";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPlat", idPlat);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNomPlat.Text = reader.GetString("nom");
                                txtDescription.Text = reader.GetString("description");
                                txtPrix.Text = reader.GetDecimal("prix").ToString();
                            }
                            else
                            {
                                MessageBox.Show("Plat non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtNomPlat.Text.Trim();
                string description = txtDescription.Text.Trim();
                decimal prix;
                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(description) || !decimal.TryParse(txtPrix.Text, out prix))
                {
                    MessageBox.Show("Veuillez remplir tous les champs correctement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Plat SET nom = @nom, description = @description, prix = @prix WHERE id_plat = @idPlat";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", nom);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@prix", prix);
                        cmd.Parameters.AddWithValue("@idPlat", idPlat);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Plat modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Aucune modification effectuée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
