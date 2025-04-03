using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Livrable_1_PSI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var graphe = new GrapheMetro();
            graphe.ChargerDonnees();

            if (graphe.Stations.Count > 0 && graphe.Connexions.Count > 0)
            {
                Application.Run(new MetroForm(graphe));
            }
            else
            {
                MessageBox.Show("Erreur: Impossible de charger les données du métro",
                              "Erreur",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }


    public class Station
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Ligne { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }


}
