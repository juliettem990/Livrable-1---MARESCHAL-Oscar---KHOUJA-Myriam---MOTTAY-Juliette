using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Livrable_1_PSI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Graphe monGraphe = new Graphe();
            string cheminMTX = "soc-karate.mtx";  
            monGraphe.ChargerDepuisMTX(cheminMTX);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VisualisationGraph(monGraphe));

            
            Console.WriteLine("Matrice d'adjacence :");
            monGraphe.AfficherMatriceAdjacence();
            Console.WriteLine();

            Console.WriteLine("Liste d'adjacence :");
            monGraphe.AfficherListeAdjacence();
            Console.WriteLine();

            Console.WriteLine("\nParcours en largeur (BFS) à partir du sommet 1 :");
            monGraphe.ParcoursLargeurBFS(1);

            Console.WriteLine("\nParcours en profondeur (DFS) à partir du sommet 1 :");
            monGraphe.ParcoursProfondeurDFS(1);

            Console.WriteLine("\nLe graphe est-il connecté ? " + (monGraphe.EstConnecte() ? "Oui" : "Non"));
            Console.WriteLine("Le graphe contient-il un cycle ? " + (monGraphe.ContientCycle() ? "Oui" : "Non"));
            Console.WriteLine("Ordre du graphe : " + monGraphe.OrdreGraphe());
            Console.WriteLine("Taille du graphe : " + monGraphe.TailleGraphe());

            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            //Console.ReadKey();
            
        }
    }

   
}
