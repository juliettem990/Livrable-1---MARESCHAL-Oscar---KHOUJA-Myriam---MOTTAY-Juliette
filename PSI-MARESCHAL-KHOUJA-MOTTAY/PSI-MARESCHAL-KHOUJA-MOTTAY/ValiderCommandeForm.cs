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
    public partial class ValiderCommandeForm : Form
    {
        private int idCuisinier;
        public ValiderCommandeForm(int idCuisinier)
        {
            InitializeComponent();
            this.idCuisinier = idCuisinier;
            ChargerCommandes();
        }
        private void ChargerCommandes()
        {
            listBoxCommandes.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "SELECT id_commande, id_client, nombre_portion, adresse_livraison FROM Commande " +
                               "WHERE id_cuisinier = @Cuisinier AND statut_commande = 'En attente'";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            lblMessage.Text = "Aucune commande en attente pour le moment.";
                            btnValider.Enabled = false;
                            return;
                        }
                        while (reader.Read())
                        {
                            int idCommande = reader.GetInt32("id_commande");
                            int idClient = reader.GetInt32("id_client");
                            int portions = reader.GetInt32("nombre_portion");
                            string adresse = reader.GetString("adresse_livraison");
                            string display = $"Commande {idCommande} - Client {idClient} - {portions} portions - {adresse}";
                            listBoxCommandes.Items.Add(display);
                        }
                        lblMessage.Text = "Sélectionnez une commande à valider :";
                        btnValider.Enabled = true;
                    }
                }
            }
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (listBoxCommandes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande.");
                return;
            }
            string selected = listBoxCommandes.SelectedItem.ToString();
            int idCommande = int.Parse(selected.Split(' ')[1]); 
            string adresseClient = selected.Split(new[] { '-' }, 4)[3].Trim(); 
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string adresseCuisinier = string.Empty;
                string cuisinierQuery = "SELECT metroLePlusProche FROM Cuisinier WHERE id_cuisinier = @Cuisinier";
                using (MySqlCommand cuisinierCmd = new MySqlCommand(cuisinierQuery, conn))
                {
                    cuisinierCmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
                    object result = cuisinierCmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        adresseCuisinier = result.ToString();
                        AfficherGraphe form = new AfficherGraphe(adresseClient, adresseCuisinier);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Adresse du cuisinier introuvable.");
                        return;
                    }
                }
                string updateQuery = "UPDATE Commande SET statut_commande = 'En cours' WHERE id_commande = @Commande AND id_cuisinier = @Cuisinier";
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Commande", idCommande);
                    cmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Commande validée et en cours de livraison !");
                        ChargerCommandes();                        
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
