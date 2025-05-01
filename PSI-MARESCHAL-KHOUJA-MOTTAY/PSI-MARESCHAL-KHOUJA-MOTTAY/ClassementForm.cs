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
    public partial class ClassementForm : Form
    {
        private int idCuisinier;

        public ClassementForm(int idCuisinier)
        {
            InitializeComponent();
            this.idCuisinier = idCuisinier;
            ChargerClassement();
        }

        private void ChargerClassement()
        {
            listViewClassement.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = @"
                SELECT id_cuisinier, nom, note_moyenne,
                       RANK() OVER (ORDER BY note_moyenne DESC) AS classement
                FROM Cuisinier 
                WHERE note_moyenne IS NOT NULL";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    int rangCuisinier = 0;
                    /*while (reader.Read())
                    {
                        int id = reader.GetInt32("id_cuisinier");
                        string nom = reader.GetString("nom");
                        double note = Math.Round(reader.GetDouble("note_moyenne"), 2);
                        int rang = reader.GetInt32("classement");

                        var item = new ListViewItem(rang.ToString());
                        item.SubItems.Add(nom);
                        item.SubItems.Add(note + "/5");

                        if (id == idCuisinier)
                        {
                            item.BackColor = System.Drawing.Color.LightGreen;
                            rangCuisinier = rang;
                        }

                        listViewClassement.Items.Add(item);
                    }*/
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id_cuisinier");
                        string nom = reader.GetString("nom");
                        double note = Math.Round(reader.GetDouble("note_moyenne"), 2);
                        int rang = reader.GetInt32("classement");

                        string medal;
                        if (rang == 1)
                        {
                            medal = "🥇 ";
                        }
                        else if (rang == 2)
                        {
                            medal = "🥈 ";
                        }
                        else if (rang == 3)
                        {
                            medal = "🥉 ";
                        }
                        else
                        {
                            medal = "";
                        }

                        var item = new ListViewItem(rang.ToString());
                        item.SubItems.Add(medal + nom); // On ajoute la médaille ici
                        item.SubItems.Add(note + "/5");

                        if (id == idCuisinier)
                        {
                            item.BackColor = System.Drawing.Color.LightGreen;
                            rangCuisinier = rang;
                        }

                        listViewClassement.Items.Add(item);
                    }

                    // Afficher le bilan personnel
                    if (rangCuisinier > 0)
                    {
                        if (rangCuisinier == 1)
                            labelBilan.Text = "Bravo ! Vous êtes le meilleur cuisinier ! Continuez comme ça !";
                        else if (rangCuisinier <= 3)
                            labelBilan.Text = "Vous êtes dans le top 3 ! Gardez le cap !";
                        else if (rangCuisinier <= 10)
                            labelBilan.Text = "Vous êtes bien classé, continuez à vous améliorer !";
                        else
                            labelBilan.Text = "Vous êtes en bas du classement... Changez peut-être de cuisine !";
                    }
                    else
                    {
                        labelBilan.Text = "Aucune donnée de note disponible pour vous.";
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
