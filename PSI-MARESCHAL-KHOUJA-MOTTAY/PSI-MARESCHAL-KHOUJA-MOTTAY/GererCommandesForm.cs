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
using Newtonsoft.Json;
using System.IO;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class GererCommandesForm : Form
    {
        public GererCommandesForm()
        {
            InitializeComponent();
        }

        private void GererCommandesForm_Load(object sender, EventArgs e)
        {
            // Charger les commandes existantes au démarrage
            ChargerCommandes();
        }

        private void ChargerCommandes()
        {
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_commande, id_client, id_cuisinier, id_plat, statut_commande FROM Commande";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dataGridViewCommandes.Rows.Clear();
                            dataGridViewCommandes.Columns.Clear(); // Très important si on recharge
                            dataGridViewCommandes.Columns.Add("id_commande", "ID Commande");
                            dataGridViewCommandes.Columns.Add("id_client", "ID Client");
                            dataGridViewCommandes.Columns.Add("id_cuisinier", "ID Cuisinier");
                            dataGridViewCommandes.Columns.Add("id_plat", "ID Plat");
                            dataGridViewCommandes.Columns.Add("statut_commande", "Statut");

                            while (reader.Read())
                            {
                                dataGridViewCommandes.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des commandes : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouterCommande_Click(object sender, EventArgs e)
        {
            new AjouterPlatAdminForm().ShowDialog();
            ChargerCommandes(); // Recharger la liste après ajout
        }

        private void btnModifierCommande_Click(object sender, EventArgs e)
        {
            if (dataGridViewCommandes.SelectedRows.Count > 0)
            {
                int idCommande = Convert.ToInt32(dataGridViewCommandes.SelectedRows[0].Cells[0].Value);
                new ModifierPlatForm(idCommande).ShowDialog();
                ChargerCommandes(); // Recharger la liste après modification
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimerCommande_Click(object sender, EventArgs e)
        {
            if (dataGridViewCommandes.SelectedRows.Count > 0)
            {
                int idCommande = Convert.ToInt32(dataGridViewCommandes.SelectedRows[0].Cells[0].Value);
                try
                {
                    string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Commande WHERE id_commande = @idCommande";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@idCommande", idCommande);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Commande supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChargerCommandes(); // Recharger la liste après suppression
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression de la commande : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une commande à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                // Modification de la requête pour récupérer les données de la table Commande
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Commande", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Sérialisation des données en JSON
                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);

                // Boîte de dialogue pour enregistrer le fichier JSON
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Fichiers JSON (*.json)|*.json";
                    saveFileDialog.Title = "Enregistrer les commandes au format JSON";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Écrire le fichier JSON à l'emplacement choisi par l'utilisateur
                        File.WriteAllText(saveFileDialog.FileName, json);
                        MessageBox.Show("Export JSON réussi !");
                    }
                    else
                    {
                        MessageBox.Show("L'exportation a été annulée.");
                    }
                }
            }
        }


        private void btnXML_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                // Modification de la requête pour récupérer les données de la table Commande
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Commande", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Commande");
                adapter.Fill(dt);

                DataSet ds = new DataSet("Commandes");
                ds.Tables.Add(dt);

                // Boîte de dialogue pour enregistrer le fichier XML
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
                    saveFileDialog.Title = "Enregistrer les commandes au format XML";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Écrire le fichier XML à l'emplacement choisi par l'utilisateur
                        ds.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
                        MessageBox.Show("Export XML réussi !");
                    }
                    else
                    {
                        MessageBox.Show("L'exportation a été annulée.");
                    }
                }
            }
        }

    }
}
