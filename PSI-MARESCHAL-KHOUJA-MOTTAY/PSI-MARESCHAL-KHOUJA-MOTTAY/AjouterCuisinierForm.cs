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
    public partial class AjouterCuisinierForm : Form
    {
        public AjouterCuisinierForm()
        {
            InitializeComponent();
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtNom.Text.Trim();
                string prenom = txtPrenom.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telephone = txtTelephone.Text.Trim();
                string rue = txtRue.Text.Trim();
                string numeroRue = txtNumeroRue.Text.Trim();
                string ville = txtVille.Text.Trim();
                string codePostalText = txtCodePostal.Text.Trim();
                string metroLePlusProche = txtMetro.Text.Trim();
                string motDePasse = txtMotDePasse.Text.Trim();
                string specialiteCulinaire = txtSpecialite.Text.Trim(); 
                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse) || string.IsNullOrEmpty(telephone) || string.IsNullOrEmpty(metroLePlusProche))
                {
                    MessageBox.Show("Veuillez remplir tous les champs obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int codePostal = 0;
                if (!int.TryParse(codePostalText, out codePostal))
                {
                    MessageBox.Show("Le code postal doit être un nombre valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Cuisinier 
                            (nom, prenom, email, telephone, rue, numeroRue, codePostal, ville, metroLePlusProche, specialite_culinaire, mot_de_passe)
                            VALUES
                            (@nom, @prenom, @email, @telephone, @rue, @numeroRue, @codePostal, @ville, @metroLePlusProche, @specialiteCulinaire, @motDePasse)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", nom);
                        cmd.Parameters.AddWithValue("@prenom", prenom);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@telephone", telephone);
                        cmd.Parameters.AddWithValue("@rue", rue);
                        cmd.Parameters.AddWithValue("@numeroRue", numeroRue);
                        cmd.Parameters.AddWithValue("@codePostal", codePostal);
                        cmd.Parameters.AddWithValue("@ville", ville);
                        cmd.Parameters.AddWithValue("@metroLePlusProche", metroLePlusProche);
                        cmd.Parameters.AddWithValue("@specialiteCulinaire", specialiteCulinaire);
                        cmd.Parameters.AddWithValue("@motDePasse", motDePasse);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cuisinier ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Erreur lors de l'ajout du cuisinier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
