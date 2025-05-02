using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using PSI_MARESCHAL_KHOUJA_MOTTAY;


namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class ClientMenuForm : Form
    {
        private int idClient;
        private MySqlConnection conn;
        private MainForm mainForm;
        public ClientMenuForm(int id_client, MySqlConnection connection, MainForm mainForm)
        {
            InitializeComponent();
            this.idClient = id_client;
            this.conn = connection;
            this.mainForm = mainForm;
        }        
        private void btnCommanderPlat_Click(object sender, EventArgs e)
        {
            CommanderPlatForm form = new CommanderPlatForm(idClient);
            form.Show(); 
        }
        private void btnVoirCommandes_Click(object sender, EventArgs e)
        {
            VoirCommandesClientForm form = new VoirCommandesClientForm(idClient);
            form.Show();
        }
        private void btnValiderReception_Click(object sender, EventArgs e)
        {
            ValiderReceptionCommandeForm form = new ValiderReceptionCommandeForm(idClient);
            form.Show();
        }
        private void btnNoterCuisinier_Click(object sender, EventArgs e)
        {
            NoterCuisinierForm form = new NoterCuisinierForm(idClient);
            form.ShowDialog();
        }
        private void btnRecommandations_Click(object sender, EventArgs e)
        {
            RecommandationsForm form = new RecommandationsForm(idClient);
            form.ShowDialog();
        }       
        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }
    }

}
