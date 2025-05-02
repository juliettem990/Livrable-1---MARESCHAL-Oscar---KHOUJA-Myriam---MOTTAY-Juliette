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
    public partial class ValiderReceptionCommandeForm : Form
    {
        private int idClient;
        public ValiderReceptionCommandeForm(int idClient)
        {
            InitializeComponent();
            this.idClient = idClient;
            ChargerCommandesEnCours();
        }
        private void ChargerCommandesEnCours()
        {
            listBoxCommandes.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string countQuery = "SELECT COUNT(*) FROM Commande WHERE id_client = @Client AND statut_commande = 'En cours'";
                using (MySqlCommand cmd = new MySqlCommand(countQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Client", idClient);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        lblMessage.Text = "Vous n'avez aucune commande en cours de réception.";
                        btnValider.Enabled = false;
                        return;
                    }
                }
                string query = "SELECT id_commande FROM Commande WHERE id_client = @Client AND statut_commande = 'En cours'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Client", idClient);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idCommande = reader.GetInt32("id_commande");
                            listBoxCommandes.Items.Add(idCommande);
                        }
                    }
                }
                lblMessage.Text = "Commandes en cours :";
                btnValider.Enabled = true;
            }
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (listBoxCommandes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande à valider.");
                return;
            }
            int idCommande = (int)listBoxCommandes.SelectedItem;
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Commande SET statut_commande = 'Livré' WHERE id_commande = @Commande AND id_client = @Client";
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Commande", idCommande);
                    cmd.Parameters.AddWithValue("@Client", idClient);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Commande livrée ! Vous pouvez maintenant noter le cuisinier.");
                        var noterForm = new NoterCuisinierForm(idCommande);
                        noterForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Commande non trouvée.");
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
