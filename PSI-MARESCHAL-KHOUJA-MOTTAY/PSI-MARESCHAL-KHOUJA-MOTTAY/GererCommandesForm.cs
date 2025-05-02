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
using System.Xml.Serialization;

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
                            dataGridViewCommandes.Columns.Clear();
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
            ChargerCommandes();
        }
        private void btnModifierCommande_Click(object sender, EventArgs e)
        {
            if (dataGridViewCommandes.SelectedRows.Count > 0)
            {
                int idCommande = Convert.ToInt32(dataGridViewCommandes.SelectedRows[0].Cells[0].Value);
                new ModifierPlatForm(idCommande).ShowDialog();
                ChargerCommandes(); 
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
                            ChargerCommandes(); 
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
        private List<Commande> GetAllCommandes()
        {
            List<Commande> commandes = new List<Commande>();

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Commande";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        commandes.Add(new Commande
                        {
                            id_commande = reader.GetInt32("id_commande"),
                            id_client = reader.GetInt32("id_client"),
                            id_cuisinier = reader.GetInt32("id_cuisinier"),
                            id_plat = reader.GetInt32("id_plat"),
                            date_heure_commande = reader.GetDateTime("date_heure_commande"),
                            nombre_portion = reader.GetInt32("nombre_portion"),
                            statut_commande = reader.GetString("statut_commande"),
                            adresse_livraison = reader.GetString("adresse_livraison")
                        });
                    }
                }
            }

            return commandes;
        }
        private void btnJSON_Click(object sender, EventArgs e)
        {
            List<Commande> commandes = GetAllCommandes();
            if (commandes.Count == 0)
            {
                MessageBox.Show("Aucune commande trouvée.");
                return;
            }

            string json = JsonConvert.SerializeObject(commandes, Formatting.Indented);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Fichiers JSON (*.json)|*.json";
                saveFileDialog.Title = "Enregistrer les commandes au format JSON";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Export JSON des commandes réussi !");
                }
                else
                {
                    MessageBox.Show("L'exportation a été annulée.");
                }
            }
        }
        private void btnXML_Click(object sender, EventArgs e)
        {
            List<Commande> commandes = GetAllCommandes();
            if (commandes.Count == 0)
            {
                MessageBox.Show("Aucune commande trouvée.");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Commande>));

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
                saveFileDialog.Title = "Enregistrer les commandes au format XML";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(fs, commandes);
                    }
                    MessageBox.Show("Export XML des commandes réussi !");
                }
                else
                {
                    MessageBox.Show("L'exportation a été annulée.");
                }
            }
        }

    }
}
