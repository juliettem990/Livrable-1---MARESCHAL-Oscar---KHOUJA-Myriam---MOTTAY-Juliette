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
    public partial class AdminMenuForm : Form
    {
        private MainForm mainForm; 
        public AdminMenuForm(MainForm mainForm)
        {
            this.mainForm = mainForm;  
            InitializeComponent();
        }
        public AdminMenuForm()
        {
            InitializeComponent();
        }
        private void btnGererClients_Click(object sender, EventArgs e)
        {
            GererClientsForm gererClientsForm = new GererClientsForm();
            gererClientsForm.Show();
        }
        private void btnGererCuisiniers_Click(object sender, EventArgs e)
        {
            GererCuisinierForm gererCuisiniersForm = new GererCuisinierForm();
            gererCuisiniersForm.Show();
        }
        private void btnGererCommandes_Click(object sender, EventArgs e)
        {
            GererCommandesForm gererCommandesForm = new GererCommandesForm();
            gererCommandesForm.Show();
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
        private void btnColoration_Click(object sender, EventArgs e)
        {
            GrapheMetro monGraphe = new GrapheMetro(); 
            Dictionary<Station, int> resultats = monGraphe.ColorerGraphe();

            string message = "Résultat de la coloration :\n\n";
            foreach (var pair in resultats)
            {
                message += $"{pair.Key.Nom} : Couleur {pair.Value}\n"; 
            }
            MessageBox.Show(message, "Coloration du graphe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
