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
        private MainForm mainForm;  // Référence à l'instance de MainForm

        public AdminMenuForm(MainForm mainForm)
        {
            this.mainForm = mainForm;  // Stocker la référence
            InitializeComponent();
        }
        public AdminMenuForm()
        {

            InitializeComponent();
        }
        private void btnGererClients_Click(object sender, EventArgs e)
        {
            // Redirection vers la fenêtre de gestion des clients
            GererClientsForm gererClientsForm = new GererClientsForm();
            //this.Hide();
            gererClientsForm.Show();
            
        }

        private void btnGererCuisiniers_Click(object sender, EventArgs e)
        {
            // Redirection vers la fenêtre de gestion des cuisiniers
            GererCuisinierForm gererCuisiniersForm = new GererCuisinierForm();
            //this.Hide();
            gererCuisiniersForm.Show();
        }

        private void btnGererCommandes_Click(object sender, EventArgs e)
        {
            // Redirection vers la fenêtre de gestion des commandes
            GererCommandesForm gererCommandesForm = new GererCommandesForm();
            //this.Hide();
            gererCommandesForm.Show();
        }


        private void btnQuitter_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }
}
