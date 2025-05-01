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
    public partial class ConsulterNoteMoyenneForm : Form
    {
        private int idCuisinier;

        public ConsulterNoteMoyenneForm(int idCuisinier)
        {
            InitializeComponent();
            this.idCuisinier = idCuisinier;
            AfficherNoteMoyenne();
            AfficherAvis();
        }

        private void AfficherNoteMoyenne()
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string countQuery = "SELECT COUNT(*) FROM Notation WHERE id_cuisinier = @Cuisinier";
                using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
                    int count = Convert.ToInt32(countCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        lblNoteMoyenne.Text = "Vous n'avez pas encore reçu de notes.\nContinuez à cuisiner pour impressionner vos clients !";
                        return;
                    }
                }

                string query = "SELECT AVG(note_attribuee) FROM Notation WHERE id_cuisinier = @Cuisinier";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        double moyenne = Math.Round(Convert.ToDouble(result), 2);
                        lblNoteMoyenne.Text = $"Votre note moyenne est : {moyenne.ToString("0.00")}/5 ";
                    }
                    else
                    {
                        lblNoteMoyenne.Text = "Aucune note reçue pour l'instant.";
                    }
                }
            }
        }

        private void AfficherAvis()
        {
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        n.note_attribuee,
                        n.commentaire,
                        n.date_note,
                        CONCAT(c.nom, ' ', c.prenom) as client
                    FROM Notation n
                    JOIN Client c ON n.id_client = c.id_client
                    WHERE n.id_cuisinier = @Cuisinier
                    ORDER BY n.date_note DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
                    
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                            lblAucunAvis.Visible = true;
                            dgvAvis.Visible = false;
                        }
                        else
                        {
                            lblAucunAvis.Visible = false;
                            dgvAvis.Visible = true;
                        }
                        dgvAvis.DataSource = dt;
                        
                        // Configuration des colonnes
                        dgvAvis.Columns["note_attribuee"].HeaderText = "Note";
                        dgvAvis.Columns["commentaire"].HeaderText = "Commentaire";
                        dgvAvis.Columns["date_note"].HeaderText = "Date";
                        dgvAvis.Columns["client"].HeaderText = "Client";

                        // Ajustement de la largeur des colonnes
                       /* if (dgvAvis.Columns.Contains("note_attribuee"))
                            dgvAvis.Columns["note_attribuee"].Width = 60;
                        if (dgvAvis.Columns.Contains("commentaire"))
                            dgvAvis.Columns["commentaire"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (dgvAvis.Columns.Contains("date_note"))
                            dgvAvis.Columns["date_note"].Width = 120;
                        if (dgvAvis.Columns.Contains("client"))
                            dgvAvis.Columns["client"].Width = 150;
*/
                        
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
