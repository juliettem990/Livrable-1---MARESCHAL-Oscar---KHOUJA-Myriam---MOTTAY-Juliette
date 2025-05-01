using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PSI_MARESCHAL_KHOUJA_MOTTAY;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class CommanderPlatForm : Form
    {
        private int id_client;

        public CommanderPlatForm(int id_client)
        {
            InitializeComponent();
            this.id_client = id_client;
            listPlats.View = View.Details;
            listPlats.Columns.Add("ID", 50);
            listPlats.Columns.Add("Nom", 150);
            listPlats.Columns.Add("Prix", 70);
            listPlats.Columns.Add("Portions", 100);
            ChargerPlatsDisponibles();
        }

        private void ChargerPlatsDisponibles()
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "SELECT id_plat, nom, prix, nombre_portion FROM Plat";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nom = reader.GetString(1);
                        decimal prix = reader.GetDecimal(2);
                        int portions = reader.GetInt32(3);
                        listPlats.Items.Add(new ListViewItem(new string[]
                        {
                        id.ToString(), nom, prix.ToString() + "€", portions.ToString() + " portions"
                        })
                        { Tag = id });
                    }
                }
            }
        }

        private void btnCommander_Click(object sender, EventArgs e)
        {
            if (listPlats.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un plat.");
                return;
            }

            int id_plat = (int)listPlats.SelectedItems[0].Tag;
            int nbPortions = (int)numPortions.Value;

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                // Vérifier stock
                string checkStock = "SELECT nombre_portion FROM Plat WHERE id_plat = @Plat";
                int stockRestant;
                using (MySqlCommand cmd = new MySqlCommand(checkStock, conn))
                {
                    cmd.Parameters.AddWithValue("@Plat", id_plat);
                    stockRestant = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (stockRestant < nbPortions)
                {
                    MessageBox.Show("Désolé, seulement " + stockRestant + " portions disponibles.");
                    return;
                }

                // Adresse
                string adresseLivraison = "";
                using (MySqlCommand cmd = new MySqlCommand("SELECT metroLePlusProche FROM Client WHERE id_client = @Client", conn))
                {
                    cmd.Parameters.AddWithValue("@Client", id_client);
                    var result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Erreur : adresse de livraison introuvable.");
                        return;
                    }
                    adresseLivraison = result.ToString();
                }

                // ID cuisinier
                int id_cuisinier;
                using (MySqlCommand cmd = new MySqlCommand("SELECT id_cuisinier FROM Plat WHERE id_plat = @Plat", conn))
                {
                    cmd.Parameters.AddWithValue("@Plat", id_plat);
                    id_cuisinier = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Insertion commande
                string insertCommande = @"INSERT INTO Commande (id_client, id_cuisinier, id_plat, date_heure_commande, nombre_portion, statut_commande, adresse_livraison)
                                      VALUES (@Client, @Cuisinier, @Plat, NOW(), @Portions, 'En attente', @Adresse)";
                using (MySqlCommand cmd = new MySqlCommand(insertCommande, conn))
                {
                    cmd.Parameters.AddWithValue("@Client", id_client);
                    cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                    cmd.Parameters.AddWithValue("@Plat", id_plat);
                    cmd.Parameters.AddWithValue("@Portions", nbPortions);
                    cmd.Parameters.AddWithValue("@Adresse", adresseLivraison);
                    cmd.ExecuteNonQuery();
                }

                // Mise à jour stock
                using (MySqlCommand cmd = new MySqlCommand("UPDATE Plat SET nombre_portion = nombre_portion - @Portions WHERE id_plat = @Plat", conn))
                {
                    cmd.Parameters.AddWithValue("@Plat", id_plat);
                    cmd.Parameters.AddWithValue("@Portions", nbPortions);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Commande passée avec succès !");
            }
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
