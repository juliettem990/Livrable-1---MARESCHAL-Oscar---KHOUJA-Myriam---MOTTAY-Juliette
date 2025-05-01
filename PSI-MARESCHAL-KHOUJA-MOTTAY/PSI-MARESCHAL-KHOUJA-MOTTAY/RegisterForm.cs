using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class RegisterForm : Form
    {
        private TextBox txtNom;
        private TextBox txtPrenom;
        private TextBox txtEmail;
        private TextBox txtTelephone;
        private TextBox txtPassword;
        private TextBox txtVille;
        private TextBox txtRue;
        private TextBox txtNumeroRue;
        private TextBox txtCodePostal;
        private TextBox txtMetro;
        private MainForm mainForm;

        public RegisterForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string telephone = txtTelephone.Text.Trim();
            string motDePasse = txtPassword.Text.Trim();
            string ville = txtVille.Text.Trim();
            string rue = txtRue.Text.Trim();
            string numeroRue = txtNumeroRue.Text.Trim();
            string codePostal = txtCodePostal.Text.Trim();
            string metro = txtMetro.Text.Trim();
            string specialite = txtSpecialite.Text.Trim();

            string typeUtilisateur = comboType.SelectedItem?.ToString();
            string typeClient = comboClient.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(typeUtilisateur))
            {
                MessageBox.Show("Veuillez sélectionner un type d'utilisateur.");
                return;
            }

            if (!EmailEstUnique(email))
            {
                MessageBox.Show("Cet e-mail est déjà utilisé.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "";

                if (typeUtilisateur == "Client")
                {
                    query = "INSERT INTO Client (nom, prenom, email, telephone, mot_de_passe, ville, rue, numeroRue, codePostal, metroLePlusProche) " +
                            "VALUES (@Nom, @Prenom, @Email, @Telephone, @Password, @Ville, @Rue, @NumeroRue, @CodePostal, @Metro)";

                }
                else if (typeUtilisateur == "Cuisinier")
                {
                    query = "INSERT INTO Cuisinier (nom, prenom, email, telephone, mot_de_passe, ville, rue, numeroRue, codePostal, metroLePlusProche, specialite_culinaire) " +
                            "VALUES (@Nom, @Prenom, @Email, @Telephone, @Password, @Ville, @Rue, @NumeroRue, @CodePostal, @Metro, @Specialite)";
                }

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nom", nom);
                    cmd.Parameters.AddWithValue("@Prenom", prenom);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Telephone", telephone);
                    cmd.Parameters.AddWithValue("@Password", motDePasse);
                    cmd.Parameters.AddWithValue("@Ville", ville);
                    cmd.Parameters.AddWithValue("@Rue", rue);
                    cmd.Parameters.AddWithValue("@NumeroRue", numeroRue);
                    cmd.Parameters.AddWithValue("@CodePostal", codePostal);
                    cmd.Parameters.AddWithValue("@Metro", metro);

                    if (typeUtilisateur == "Cuisinier")
                    {
                        cmd.Parameters.AddWithValue("@Specialite", specialite);
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Inscription réussie !");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de l'inscription : " + ex.Message);
                    }
                }
            }
        }

        private bool EmailEstUnique(string email)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Client WHERE email = @Email UNION ALL SELECT COUNT(*) FROM Cuisinier WHERE email = @Email";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 0;
                }
            }
        }

        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool estClient = comboType.SelectedItem?.ToString() == "Client";
            comboClient.Enabled = estClient;
            lblSpecialite.Visible = txtSpecialite.Visible = !estClient;
        }
        private void btnRetour_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close(); 
        }

    }
}
