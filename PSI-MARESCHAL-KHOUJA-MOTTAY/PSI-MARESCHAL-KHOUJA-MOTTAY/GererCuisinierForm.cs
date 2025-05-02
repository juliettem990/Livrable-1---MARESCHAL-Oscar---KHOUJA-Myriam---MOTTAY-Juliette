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
    public partial class GererCuisinierForm : Form
    {
        public GererCuisinierForm()
        {
            InitializeComponent();
        }
        private void GererCuisinierForm_Load(object sender, EventArgs e)
        {
            ChargerCuisiniers();
        }
        private void ChargerCuisiniers()
        {
            try
            {
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_cuisinier, prenom, email FROM Cuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dataGridViewCuisiniers.Columns.Clear();
                            dataGridViewCuisiniers.Rows.Clear();

                            dataGridViewCuisiniers.Columns.Add("id_cuisinier", "ID");
                            dataGridViewCuisiniers.Columns.Add("prenom", "Prénom");
                            dataGridViewCuisiniers.Columns.Add("email", "Email");
                            while (reader.Read())
                            {
                                dataGridViewCuisiniers.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des cuisiniers : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAjouterCuisinier_Click(object sender, EventArgs e)
        {
            new AjouterCuisinierForm().ShowDialog();
            ChargerCuisiniers(); 
        }
        private void btnModifierCuisinier_Click(object sender, EventArgs e)
        {
            if (dataGridViewCuisiniers.SelectedRows.Count > 0)
            {
                int idCuisinier = Convert.ToInt32(dataGridViewCuisiniers.SelectedRows[0].Cells[0].Value);
                new ModifierCuisinierForm(idCuisinier).ShowDialog();
                ChargerCuisiniers(); 
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un cuisinier à modifier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSupprimerCuisinier_Click(object sender, EventArgs e)
        {
            if (dataGridViewCuisiniers.SelectedRows.Count > 0)
            {
                int idCuisinier = Convert.ToInt32(dataGridViewCuisiniers.SelectedRows[0].Cells[0].Value);
                string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Commande WHERE id_cuisinier = @idCuisinier";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Impossible de supprimer ce cuisinier car il est associé à des commandes.\nVeuillez d'abord supprimer ses commandes.", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            string deleteQuery = "DELETE FROM Cuisinier WHERE id_cuisinier = @idCuisinier";
                            using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                            {
                                deleteCmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);
                                deleteCmd.ExecuteNonQuery();
                                MessageBox.Show("Cuisinier supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ChargerCuisiniers(); 
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un cuisinier à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private List<Cuisinier> GetAllCuisiniers()
        {
            List<Cuisinier> cuisiniers = new List<Cuisinier>();

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Cuisinier";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cuisiniers.Add(new Cuisinier
                        {
                            id_cuisinier = reader.GetInt32("id_cuisinier"),
                            nom = reader.GetString("nom"),
                            prenom = reader.GetString("prenom"),
                            email = reader.GetString("email"),
                            telephone = reader.GetString("telephone"),
                            rue = reader.IsDBNull(reader.GetOrdinal("rue")) ? "" : reader.GetString("rue"),
                            numeroRue = reader.IsDBNull(reader.GetOrdinal("numeroRue")) ? "" : reader.GetString("numeroRue"),
                            codePostal = reader.IsDBNull(reader.GetOrdinal("codePostal")) ? 0 : reader.GetInt32("codePostal"),
                            ville = reader.IsDBNull(reader.GetOrdinal("ville")) ? "" : reader.GetString("ville"),
                            metroLePlusProche = reader.GetString("metroLePlusProche"),
                            specialite_culinaire = reader.IsDBNull(reader.GetOrdinal("specialite_culinaire")) ? "" : reader.GetString("specialite_culinaire"),
                            mot_de_passe = reader.GetString("mot_de_passe"),
                            note_moyenne = reader.IsDBNull(reader.GetOrdinal("note_moyenne")) ? 0 : reader.GetDecimal("note_moyenne")
                        });
                    }
                }
            }
            return cuisiniers;
        }
        private void btnJSON_Click(object sender, EventArgs e)
        {
            List<Cuisinier> cuisiniers = GetAllCuisiniers();
            if (cuisiniers.Count == 0)
            {
                MessageBox.Show("Aucun cuisinier trouvé.");
                return;
            }
            string json = JsonConvert.SerializeObject(cuisiniers, Formatting.Indented);
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Fichiers JSON (*.json)|*.json";
                saveFileDialog.Title = "Enregistrer les cuisiniers au format JSON";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Export JSON des cuisiniers réussi !");
                }
                else
                {
                    MessageBox.Show("L'exportation a été annulée.");
                }
            }
        }
        private void btnXML_Click(object sender, EventArgs e)
        {
            List<Cuisinier> cuisiniers = GetAllCuisiniers();
            if (cuisiniers.Count == 0)
            {
                MessageBox.Show("Aucun cuisinier trouvé.");
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cuisinier>));
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
                saveFileDialog.Title = "Enregistrer les cuisiniers au format XML";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        serializer.Serialize(fs, cuisiniers);
                    }
                    MessageBox.Show("Export XML des cuisiniers réussi !");
                }
                else
                {
                    MessageBox.Show("L'exportation a été annulée.");
                }
            }
        }

    }
}
