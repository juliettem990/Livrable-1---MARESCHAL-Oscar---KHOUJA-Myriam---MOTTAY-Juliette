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
        }
    }

    internal class Noeud
    {
        public int IdNoeud { get; set; }
        public List<int> Voisins { get; set; }
        public Point Position { get; set; }  

        public Noeud(int idNoeud)
        {
            IdNoeud = idNoeud;
            Voisins = new List<int>();
        }
    }

    internal class Graphe
    {
        public Dictionary<int, Noeud> Noeuds { get; set; } = new Dictionary<int, Noeud>();
        public List<Tuple<int, int>> Liens { get; set; } = new List<Tuple<int, int>>();

        public void AjouterLien(int antecedant, int suivant)
        {
            if (!Noeuds.ContainsKey(antecedant))
                Noeuds[antecedant] = new Noeud(antecedant);
            if (!Noeuds.ContainsKey(suivant))
                Noeuds[suivant] = new Noeud(suivant);

            Noeuds[antecedant].Voisins.Add(suivant);
            Noeuds[suivant].Voisins.Add(antecedant);
            Liens.Add(new Tuple<int, int>(antecedant, suivant));
        }

        public void ChargerDepuisMTX(string cheminFichier)
        {
            using (StreamReader sr = new StreamReader(cheminFichier))
            {
                string ligne;
                bool lectureArêtes = false;

                while ((ligne = sr.ReadLine()) != null)
                {
                    if (ligne.StartsWith("%")) 
                        continue;

                    string[] parties = ligne.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    if (!lectureArêtes)
                    {
                        lectureArêtes = true;
                    }
                    else if (parties.Length == 2)
                    {
                        int u = int.Parse(parties[0]);
                        int v = int.Parse(parties[1]);
                        AjouterLien(u, v);
                    }
                }
            }

           
            int centerX = 400, centerY = 300, rayon = 200;
            int nbNoeuds = Noeuds.Count;
            int i = 0;

            foreach (var noeud in Noeuds.Values)
            {
                double angle = (2 * Math.PI * i) / nbNoeuds;
                noeud.Position = new Point(
                    centerX + (int)(rayon * Math.Cos(angle)),
                    centerY + (int)(rayon * Math.Sin(angle))
                );
                i++;
            }
        }
    }

    internal class VisualisationGraph : Form
    {
        private Graphe _graphe;

        public VisualisationGraph(Graphe graphe)
        {
            _graphe = graphe;
            this.Text = "Visualisation du Graphe";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(DessinerGraphe);
        }

        private void DessinerGraphe(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Yellow, 1);
            Brush brush = new SolidBrush(Color.Blue);
            Font font = new Font("Arial", 7);

         
            foreach (var lien in _graphe.Liens)
            {
                Noeud fromNode = _graphe.Noeuds[lien.Item1];
                Noeud toNode = _graphe.Noeuds[lien.Item2];
                g.DrawLine(pen, fromNode.Position, toNode.Position);
            }

            
            foreach (var noeud in _graphe.Noeuds.Values)
            {
                g.FillEllipse(brush, noeud.Position.X - 10, noeud.Position.Y - 10, 20, 20);
                g.DrawString(noeud.IdNoeud.ToString(), font, Brushes.White, noeud.Position.X - 5, noeud.Position.Y - 5);
            }
        }
    }
}
