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
    public partial class VoirCommandesClientForm : Form
    {
        private int idClient;

        public VoirCommandesClientForm(int idClient)
        {
            InitializeComponent();
            this.idClient = idClient;
            ChargerCommandesClient();
        }

        private void ChargerCommandesClient()
        {
            listBoxCommandes.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string countQuery = "SELECT COUNT(*) FROM Commande WHERE id_client = @Client";
                using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@Client", idClient);
                    int count = Convert.ToInt32(countCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        lblMessage.Text = "Vous n'avez encore passé aucune commande.\nEssayez un nouveau plat dès maintenant !";
                        return;
                    }
                }

                string query = "SELECT id_commande, statut_commande FROM Commande WHERE id_client = @Client";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Client", idClient);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idCommande = reader.GetInt32("id_commande");
                            string statut = reader.GetString("statut_commande");

                            listBoxCommandes.Items.Add($"Commande {idCommande} - Statut : {statut}");
                        }

                        lblMessage.Text = "Vos commandes :";
                    }
                }
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
