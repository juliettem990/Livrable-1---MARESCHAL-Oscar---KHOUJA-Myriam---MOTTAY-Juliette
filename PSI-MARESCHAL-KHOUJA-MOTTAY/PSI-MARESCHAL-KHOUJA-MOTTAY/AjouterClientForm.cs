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
    public partial class AjouterClientForm : Form
    {
        private string connectionString = "Server=localhost;Database=LivInParis;Uid=root;Pwd=111222;";

        public AjouterClientForm()
        {
            InitializeComponent();
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Récupération des données
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string rue = txtRue.Text.Trim();
            string numeroRue = txtNumeroRue.Text.Trim();
            string ville = txtVille.Text.Trim();
            string codePostalText = txtCodePostal.Text.Trim();
            string metroLePlusProche = txtMetro.Text.Trim();
            string telephone = txtTelephone.Text.Trim();


            if (!int.TryParse(codePostalText, out int codePostal))
            {
                MessageBox.Show("Code postal invalide !");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Client 
                        (nom, prenom, email, rue, numeroRue, codePostal, ville, metroLePlusProche, telephone, mot_de_passe) 
                         VALUES 
                        (@nom, @prenom, @email, @rue, @numeroRue, @codePostal, @ville, @metro, @telephone, @password)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@rue", rue);
                cmd.Parameters.AddWithValue("@numeroRue", numeroRue);
                cmd.Parameters.AddWithValue("@codePostal", codePostal);
                cmd.Parameters.AddWithValue("@ville", ville);
                cmd.Parameters.AddWithValue("@metro", metroLePlusProche);
                cmd.Parameters.AddWithValue("@telephone", telephone);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Client ajouté avec succès.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); // Annuler, ferme simplement le formulaire sans rien faire
        }

        /* private void btnAjouter_Click(object sender, EventArgs e)
         {
             string nom = txtNom.Text.Trim();
             string prenom = txtPrenom.Text.Trim();
             string email = txtEmail.Text.Trim();
             string password = txtPassword.Text;

             using (MySqlConnection conn = new MySqlConnection(connectionString))
             {
                 conn.Open();
                 string query = "INSERT INTO Client (nom, prenom, email, mot_de_passe) VALUES (@nom, @prenom, @email, @password)";
                 MySqlCommand cmd = new MySqlCommand(query, conn);
                 cmd.Parameters.AddWithValue("@nom", nom);
                 cmd.Parameters.AddWithValue("@prenom", prenom);
                 cmd.Parameters.AddWithValue("@email", email);
                 cmd.Parameters.AddWithValue("@password", password);

                 cmd.ExecuteNonQuery();
             }

             MessageBox.Show("Client ajouté avec succès.");
             this.DialogResult = DialogResult.OK;
             this.Close();
         }*/
    }
}
