using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using PSI_MARESCHAL_KHOUJA_MOTTAY;


namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class ClientMenuForm : Form
    {
        private int idClient;
        private MySqlConnection conn;
        private MainForm mainForm;


        public ClientMenuForm(int id_client, MySqlConnection connection, MainForm mainForm)
        //public ClientMenuForm(int id_client, MainForm mainForm)

        {

            InitializeComponent();
            this.idClient = id_client;
            this.conn = connection;
            this.mainForm = mainForm;

            //string prenom = GetPrenomClient();
            //lblMessage.Text = $"Bonjour {prenom} !";

        }
        /*private string GetPrenomClient()
        {
            string prenom = "";

            try
            {
                string query = "SELECT prenom FROM Client WHERE id_client = @idClient";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idClient", idClient);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prenom = reader["prenom"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération du prénom : {ex.Message}");
            }

            return prenom;
        }*/
        private void btnCommanderPlat_Click(object sender, EventArgs e)
        {
            //this.Hide();
            CommanderPlatForm form = new CommanderPlatForm(idClient);
            form.Show(); // ou .Show() si tu veux laisser le menu ouvert
            

        }

        private void btnVoirCommandes_Click(object sender, EventArgs e)
        {
            //VoirCommandesClient(idClient);
            VoirCommandesClientForm form = new VoirCommandesClientForm(idClient);
            form.ShowDialog();
        }

        private void btnValiderReception_Click(object sender, EventArgs e)
        {
            ValiderReceptionCommandeForm form = new ValiderReceptionCommandeForm(idClient);
            form.ShowDialog();
        }

        private void btnNoterCuisinier_Click(object sender, EventArgs e)
        {
            NoterCuisinierForm form = new NoterCuisinierForm(idClient);
            form.ShowDialog();
            /*try
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    "Entrez l'ID de la commande à noter :",
                    "Noter un cuisinier",
                    ""
                );

                if (int.TryParse(input, out int idCommande))
                {
                    NoterCuisinier(idCommande);
                }
                else
                {
                    MessageBox.Show("ID invalide. Veuillez entrer un nombre.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }*/
        }

        private void btnRecommandations_Click(object sender, EventArgs e)
        {
            RecommandationsForm form = new RecommandationsForm(idClient);
            form.ShowDialog();
        }
        
        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }

}
