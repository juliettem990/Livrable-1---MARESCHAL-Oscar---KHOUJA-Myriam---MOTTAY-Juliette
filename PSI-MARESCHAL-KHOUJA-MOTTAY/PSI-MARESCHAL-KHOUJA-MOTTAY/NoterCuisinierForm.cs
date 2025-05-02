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
    public partial class NoterCuisinierForm : Form
    {
        public NoterCuisinierForm()
        {
            InitializeComponent();
        }
        public NoterCuisinierForm(int idCuisinier)
        {
            InitializeComponent();
            this.idCuisinier = idCuisinier;
        }
        private int idCuisinier;
        private void btnNoter_Click(object sender, EventArgs e)
        {
            int id_commande;
            if (!int.TryParse(txtCommandeId.Text.Trim(), out id_commande))
            {
                MessageBox.Show("Veuillez entrer un ID de commande valide.");
                return;
            }
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = "SELECT id_cuisinier, id_client FROM Commande WHERE id_commande = @Commande";
                int id_cuisinier, id_client;
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Commande", id_commande);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id_cuisinier = reader.GetInt32("id_cuisinier");
                            id_client = reader.GetInt32("id_client");
                        }
                        else
                        {
                            MessageBox.Show("Commande introuvable.");
                            return;
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM Notation WHERE id_commande = @Commande", conn))
                {
                    cmd.Parameters.AddWithValue("@Commande", id_commande);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Vous avez déjà noté cette commande.");
                        return;
                    }
                }
                int note = (int)numNote.Value;
                string commentaire = txtCommentaire.Text.Trim(); 
                if (note < 1 || note > 5)
                {
                    MessageBox.Show("La note doit être comprise entre 1 et 5.");
                    return;
                }
                string insertQuery = @"INSERT INTO Notation (id_commande, id_client, id_cuisinier, note_attribuee, commentaire)
                               VALUES (@Commande, @Client, @Cuisinier, @Note, @Commentaire)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Commande", id_commande);
                    cmd.Parameters.AddWithValue("@Client", id_client);
                    cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                    cmd.Parameters.AddWithValue("@Note", note);
                    cmd.Parameters.AddWithValue("@Commentaire", commentaire); 
                    cmd.ExecuteNonQuery();
                }
                string updateQuery = @"UPDATE Cuisinier 
                               SET note_moyenne = (SELECT AVG(note_attribuee) FROM Notation WHERE id_cuisinier = @Cuisinier)
                               WHERE id_cuisinier = @Cuisinier";
                using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Merci ! Votre note et votre commentaire ont été enregistrés.");
            }
        }
        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblCommentaire_Click(object sender, EventArgs e)
        {

        }
    }
}
