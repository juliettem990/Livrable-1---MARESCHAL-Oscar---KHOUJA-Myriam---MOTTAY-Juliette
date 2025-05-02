using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSI_MARESCHAL_KHOUJA_MOTTAY;


namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public partial class AfficherGraphe : Form
    {
        private GrapheMetro graphe;
        private string adresseClient;
        private string adresseCuisinier;
        private bool autoGenerer;
        public AfficherGraphe(string adresseClient, string adresseCuisinier)
        {
            InitializeComponent();
            graphe = new GrapheMetro();
            graphe.ChargerDonnees();

            this.adresseClient = adresseClient;
            this.adresseCuisinier = adresseCuisinier;
            this.autoGenerer = true;

            lblInfos.Text = $"Stations: {graphe.Stations.Count}, Connexions: {graphe.Connexions.Count}";
            GenererItineraireDepuisAdresses();
        }
        public AfficherGraphe()
        {
            InitializeComponent();
            graphe = new GrapheMetro();
            graphe.ChargerDonnees();
            this.autoGenerer = false;
            lblInfos.Text = $"Il y a : {graphe.Stations.Count} stations, et : {graphe.Connexions.Count} connexions \n Selectionnez en 2 puis recherchez ou affichez seulement le graphe";
            
        }
        private void btnItineraire_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDepart.Text, out int startId) || !int.TryParse(txtArrivee.Text, out int endId))
            {
                MessageBox.Show("Entrez des ID valides !");
                return;
            }

            AfficherItineraire(startId, endId);
        }

        private void AfficherItineraire(int departId, int arriveeId)
        {
            var chemin = graphe.Dijkstra(departId, arriveeId);
            if (chemin == null)
            {
                MessageBox.Show("Aucun chemin trouvé.");
            }
            else
            {
                var formResult = new MetroForm(graphe, chemin);
                formResult.Show();
            }
        }
        
        private void GenererItineraireDepuisAdresses()
        {
            try
            {
                int idDepart = graphe.TrouverStationParNom(adresseCuisinier);
                int idArrivee = graphe.TrouverStationParNom(adresseClient);

                if (idDepart == -1 || idArrivee == -1)
                {
                    MessageBox.Show("Une des stations est introuvable.");
                    return;
                }

                AfficherItineraire(idDepart, idArrivee);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la génération automatique : " + ex.Message);
            }
        }
        private void btnCarte_Click(object sender, EventArgs e)
        {
            var formCarte = new MetroForm(graphe);
            formCarte.Show();
        }
        private void lblInfos_Click(object sender, EventArgs e)
        {

        }
    }
}


