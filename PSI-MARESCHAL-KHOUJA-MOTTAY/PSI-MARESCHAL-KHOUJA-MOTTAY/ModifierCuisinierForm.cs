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
    public partial class ModifierCuisinierForm : Form
    {
        private int idCuisinier;

        public ModifierCuisinierForm(int cuisinierId)
        {
            InitializeComponent();
            idCuisinier = cuisinierId;
        }

        private void ModifierCuisinierForm_Load(object sender, EventArgs e)
        {
            // Ici, tu peux récupérer les informations du cuisinier et les afficher dans des TextBoxes
            DisplayCuisinierInfo();
        }

        private void DisplayCuisinierInfo()
        {
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT prenom, email, mot_de_passe FROM Cuisinier WHERE id_cuisinier = @idCuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtPrenom.Text = reader.GetString("prenom");
                                txtEmail.Text = reader.GetString("email");
                                txtMotDePasse.Text = reader.GetString("mot_de_passe");
                            }
                            else
                            {
                                MessageBox.Show("Cuisinier introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des informations : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                string prenom = txtPrenom.Text.Trim();
                string email = txtEmail.Text.Trim();
                string motDePasse = txtMotDePasse.Text.Trim();

                if (string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
                {
                    MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE Cuisinier SET prenom = @prenom, email = @email, mot_de_passe = @motDePasse WHERE id_cuisinier = @idCuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prenom", prenom);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@motDePasse", motDePasse);
                        cmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Informations du cuisinier modifiées avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Ferme le formulaire après modification
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de la mise à jour des informations.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Close(); // Annuler, ferme simplement le formulaire sans rien faire
        }
    }
}
