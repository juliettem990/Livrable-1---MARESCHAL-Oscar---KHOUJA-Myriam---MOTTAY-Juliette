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
using PSI_MARESCHAL_KHOUJA_MOTTAY;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class CuisinierMenuForm : Form
    {
        private int id_cuisinier;
        private MainForm mainForm;
        //private MySqlConnection conn;


        public CuisinierMenuForm(int id_cuisinier, MainForm mainForm)
        {
            InitializeComponent();
            this.id_cuisinier = id_cuisinier;
            this.mainForm = mainForm;
        }

        private void BtnAjouterPlat_Click(object sender, EventArgs e)
        {
            AjouterPlat(id_cuisinier);
        }

        private void BtnMettreAJourPlat_Click(object sender, EventArgs e)
        {
            MettreAJourPlat(id_cuisinier);
        }

        private void BtnValiderCommande_Click(object sender, EventArgs e)
        {
            ValiderEnvoyerCommande(id_cuisinier);
        }

        private void BtnNoteMoyenne_Click(object sender, EventArgs e)
        {
            ConsulterNoteMoyenne(id_cuisinier);
        }

        private void BtnClassement_Click(object sender, EventArgs e)
        {
            AfficherClassementCuisiniers(id_cuisinier);
        }
        
        private void AjouterPlat(int idCuisinier)
        {
            AjouterPlatForm form = new AjouterPlatForm(idCuisinier);
            form.ShowDialog();
        }

        private void MettreAJourPlat(int idCuisinier)
        {
            MettreAJourPlatForm form = new MettreAJourPlatForm(idCuisinier);
            form.ShowDialog();
        }

        private void ValiderEnvoyerCommande(int idCuisinier)
        {
            ValiderCommandeForm form = new ValiderCommandeForm(idCuisinier);
            form.ShowDialog();
        }

        private void ConsulterNoteMoyenne(int idCuisinier)
        {
            ConsulterNoteMoyenneForm form = new ConsulterNoteMoyenneForm(idCuisinier);
            form.ShowDialog();
        }

        private void AfficherClassementCuisiniers(int idCuisinier)
        {
            ClassementForm form = new ClassementForm(idCuisinier);
            form.ShowDialog();
        }
        
        private void BtnDeconnexion_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close(); // Ferme le formulaire => déconnexion
        }
    }

}
