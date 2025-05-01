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
    public partial class MettreAJourPlatForm : Form
    {
        private int idCuisinier;

        public MettreAJourPlatForm(int idCuisinier)
        {
            InitializeComponent();
            this.idCuisinier = idCuisinier;
            lstPlats.View = View.Details;
            lstPlats.Columns.Add("ID", 50);
            lstPlats.Columns.Add("Nom", 150);
            lstPlats.Columns.Add("Prix", 100);
            lstPlats.Columns.Add("Quantité", 100);

            ChargerPlats();
        }

        private void ChargerPlats()
        {
            lstPlats.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "SELECT id_plat, nom, prix, nombre_portion FROM Plat WHERE id_cuisinier = @Cuisinier";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cuisinier", idCuisinier);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idPlat = reader.GetInt32("id_plat");
                            string nom = reader.GetString("nom");
                            decimal prix = reader.GetDecimal("prix");
                            int portions = reader.GetInt32("nombre_portion");

                            lstPlats.Items.Add(new ListViewItem(new[] {
                                idPlat.ToString(), nom, prix.ToString("0.00"), portions.ToString()
                            }));
                        }
                    }
                }
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (lstPlats.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un plat à modifier.");
                return;
            }

            var item = lstPlats.SelectedItems[0];
            int idPlat = int.Parse(item.SubItems[0].Text);
            decimal oldPrix = decimal.Parse(item.SubItems[2].Text);
            int oldQuantite = int.Parse(item.SubItems[3].Text);

            if (!decimal.TryParse(txtPrix.Text, out decimal newPrix))
                newPrix = oldPrix;

            if (!int.TryParse(txtQuantite.Text, out int newQuantite))
                newQuantite = oldQuantite;

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE Plat SET prix = @Prix, nombre_portion = @Quantite WHERE id_plat = @Plat";
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Prix", newPrix);
                    cmd.Parameters.AddWithValue("@Quantite", newQuantite);
                    cmd.Parameters.AddWithValue("@Plat", idPlat);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Plat mis à jour avec succès !");
            ChargerPlats();
            txtPrix.Text = "";
            txtQuantite.Text = "";
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
