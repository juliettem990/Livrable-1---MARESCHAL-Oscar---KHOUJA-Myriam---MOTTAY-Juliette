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
        private GrapheMetro graphe;

        public AdminMenuForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            graphe = new GrapheMetro();
            graphe.ChargerDonnees();
            InitializeComponent();
            
        }
        public AdminMenuForm()
        {
            
            graphe = new GrapheMetro();
            graphe.ChargerDonnees();
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
            var couleurs = graphe.ColorerGraphe();
            var formCarte = new MetroForm(graphe, couleurs);
            formCarte.Show();
        }
        private void btnGraphe_Click(object sender, EventArgs e)
        {
            AfficherGraphe form = new AfficherGraphe();
            form.ShowDialog();
        }

        private void btnACPM_Click(object sender, EventArgs e)
        {
            int rootId = 1; 
            var newarc = graphe.ChuLiuEdmonds(rootId);
            
            var formCarte = new MetroForm(graphe, newarc);
            formCarte.Show();
        }
    }
}
