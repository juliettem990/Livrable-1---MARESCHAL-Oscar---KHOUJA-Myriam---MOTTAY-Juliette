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
    public partial class ModifierClientForm : Form
    {
        private int clientId;
        private string connectionString = "Server=localhost;Database=LivInParis;Uid=root;Pwd=111222;";

        public ModifierClientForm(int id)
        {
            InitializeComponent();
            clientId = id;
        }

        private void ModifierClientForm_Load(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT nom, prenom, email, mot_de_passe FROM Client WHERE id_client = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", clientId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNom.Text = reader.GetString(0);
                        txtPrenom.Text = reader.GetString(1);
                        txtEmail.Text = reader.GetString(2);
                        txtPassword.Text = reader.GetString(3);
                    }
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Client SET nom = @nom, prenom = @prenom, email = @email, mot_de_passe = @mdp WHERE id_client = @id";
                MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@mdp", txtPassword.Text);
                cmd.Parameters.AddWithValue("@id", clientId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Client modifié avec succès.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
