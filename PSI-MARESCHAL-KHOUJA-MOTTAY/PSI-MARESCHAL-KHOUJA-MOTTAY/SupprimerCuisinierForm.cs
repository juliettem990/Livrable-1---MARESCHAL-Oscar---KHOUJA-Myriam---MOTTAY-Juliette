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

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class SupprimerCuisinierForm : Form
    {
        public SupprimerCuisinierForm()
        {
            InitializeComponent();
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int idCuisinier;
                if (int.TryParse(txtID.Text.Trim(), out idCuisinier))
                {
                    string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM Cuisinier WHERE id_cuisinier = @idCuisinier";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@idCuisinier", idCuisinier);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cuisinier supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close(); // Ferme le formulaire après suppression
                            }
                            else
                            {
                                MessageBox.Show("Aucun cuisinier trouvé avec cet ID.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un ID valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); // Annuler, ferme simplement le formulaire sans rien faire
        }
    }
}