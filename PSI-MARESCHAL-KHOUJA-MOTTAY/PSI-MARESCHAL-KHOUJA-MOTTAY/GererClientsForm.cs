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
    }
}
