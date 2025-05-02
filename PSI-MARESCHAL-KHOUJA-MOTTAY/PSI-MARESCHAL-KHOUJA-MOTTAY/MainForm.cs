using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSI_MARESCHAL_KHOUJA_MOTTAY;
using MySql.Data.MySqlClient;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (email == "root" && password == "test")
            {
                AdminMenuForm adminMenu = new AdminMenuForm(this); 
                this.Hide(); 
                adminMenu.Show();  
                return;
            }
            string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password=111222;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string queryClient = "SELECT id_client, prenom FROM Client WHERE email = @Email AND mot_de_passe = @Password LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(queryClient, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id_client = reader.GetInt32(0);
                            string prenom = reader.GetString(1);
                            MessageBox.Show($"Bonjour {prenom} !", "Connexion client");
                            ClientMenuForm menuClient = new ClientMenuForm(id_client, conn, this);
                            this.Hide();
                            menuClient.Show();        
                            return;
                        }
                    }
                }
                string queryCuisinier = "SELECT id_cuisinier, prenom FROM Cuisinier WHERE email = @Email AND mot_de_passe = @Password LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(queryCuisinier, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id_cuisinier = reader.GetInt32(0);
                            string prenom = reader.GetString(1);
                            MessageBox.Show($"Bonjour Cuisinier {prenom} !", "Connexion cuisinier");
                            CuisinierMenuForm menuCuisinier = new CuisinierMenuForm(id_cuisinier, this);
                            this.Hide();
                            menuCuisinier.Show();                      
                            return;
                        }
                    }
                }

                MessageBox.Show("Email ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(this);
            this.Hide();
            registerForm.Show();
        }
        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
