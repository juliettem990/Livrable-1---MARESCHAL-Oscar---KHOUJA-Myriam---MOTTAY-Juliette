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
    public partial class AfficherColoration : Form
    {
        public GrapheMetro graphe;

        public AfficherColoration()
        {
            InitializeComponent();
            this.graphe = new GrapheMetro();
            this.graphe.ChargerDonnees();
            AfficherStationsAvecCouleurs();
        }
        public AfficherColoration(GrapheMetro graphe)
        {
            InitializeComponent();
            this.graphe = graphe;
            AfficherStationsAvecCouleurs();
        }    
        public void AfficherStationsAvecCouleurs()
        {
            var couleurs = graphe.ColorerGraphe();
            int y = 10;

            foreach (var kvp in couleurs)
            {
                Station station = kvp.Key;
                int couleur = kvp.Value;

                Label lbl = new Label();
                lbl.Text = $"{station.Nom} (Couleur {couleur})";
                lbl.Location = new Point(10, y);
                lbl.AutoSize = true;
                lbl.BackColor = ObtenirCouleur(couleur);
                lbl.Padding = new Padding(5);
                this.Controls.Add(lbl);

                y += 30;
            }
        }

        public Color ObtenirCouleur(int couleurId)
        {
            Color[] palette = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple,
                Color.Cyan, Color.Yellow, Color.Pink, Color.Brown, Color.Gray
            };

            if (couleurId - 1 < palette.Length)
                return palette[couleurId - 1];
            else
                return Color.Black; 
        }
    }
}

