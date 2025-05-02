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
using PSI_MARESCHAL_KHOUJA_MOTTAY;
using System.IO;
using Newtonsoft.Json;
//using System.Text.Json; // pour JSON
using System.Xml.Serialization; // pour XML

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class GererClientsForm : Form
    {
        private string connectionString = "Server=localhost;Database=LivInParis;Uid=root;Pwd=111222;";
        public GererClientsForm()
        {
            InitializeComponent();
        }
        private void GererClientsForm_Load(object sender, EventArgs e)
        {
            ChargerClients();
        }
        private void ChargerClients()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_client, nom, prenom, email FROM Client";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvClients.DataSource = dt;
            }
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            var formAjout = new AjouterClientForm();
            if (formAjout.ShowDialog() == DialogResult.OK)
            {
                ChargerClients();
            }
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClients.CurrentRow.Cells["id_client"].Value);
                var formModif = new ModifierClientForm(id);
                if (formModif.ShowDialog() == DialogResult.OK)
                {
                    ChargerClients();
                }
            }
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClients.CurrentRow.Cells["id_client"].Value);
                var result = MessageBox.Show("Supprimer ce client ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Client WHERE id_client = @id";
                        MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    ChargerClients();
                }
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
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Client", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                File.WriteAllText("clients.json", json);
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Fichiers JSON (*.json)|*.json";
                    saveFileDialog.Title = "Enregistrer les clients au format JSON";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, json);
                        MessageBox.Show("Export JSON réussi !");
                    }
                }

            }
        }


        private void btnXML_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Client", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("Client");
                adapter.Fill(dt);
                DataSet ds = new DataSet("Clients");
                ds.Tables.Add(dt);
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Fichiers XML (*.xml)|*.xml";
                    saveFileDialog.Title = "Enregistrer les clients au format XML";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
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
