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
    public partial class RecommandationsForm : Form
    {
        private int idClient;
        public RecommandationsForm()
        {
            InitializeComponent();
            listViewRecommandations.View = View.Details;
            listViewRecommandations.Columns.Add("Cuisinier", 150);
            listViewRecommandations.Columns.Add("Note Moyenne", 100);
            ChargerRecommandations();
        }
        public RecommandationsForm(int idClient)
        {
            InitializeComponent();
            this.idClient = idClient;
            listViewRecommandations.View = View.Details;
            listViewRecommandations.Columns.Add("Cuisinier", 150);
            listViewRecommandations.Columns.Add("Note Moyenne", 100);
            ChargerRecommandations();
        }
        private void ChargerRecommandations()
        {
            listViewRecommandations.Items.Clear();
            using (MySqlConnection conn = new MySqlConnection(Program.connectionString))
            {
                conn.Open();
                string query = @"
                SELECT nom, note_moyenne 
                FROM Cuisinier 
                WHERE note_moyenne IS NOT NULL
                ORDER BY note_moyenne DESC, id_cuisinier ASC
                LIMIT 3";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nom = reader.GetString("nom");
                            double note = Math.Round(Convert.ToDouble(reader.GetDecimal("note_moyenne")), 2);
                            ListViewItem item = new ListViewItem(nom);
                            item.SubItems.Add(note + "/5");
                            listViewRecommandations.Items.Add(item);
                        }
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
