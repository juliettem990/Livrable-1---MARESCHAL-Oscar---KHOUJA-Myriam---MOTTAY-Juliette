using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livrable_1_PSI
{
    internal class VisualisationGraph : Form
    {
        private Graphe mongraphe;

        public VisualisationGraph(Graphe graphe)
        {
            mongraphe = graphe;
            this.Text = "Visualisation du Graphe";
            this.Size = new Size(800, 600);
            this.Paint += new PaintEventHandler(DessinerGraphe);
        }

        private void DessinerGraphe(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                using (Pen pen = new Pen(Color.Yellow, 1))
                using (Brush brush = new SolidBrush(Color.Blue))
                using (Font font = new Font("Arial", 7))
                {                   
                    foreach (var lien in mongraphe.Liens)
                    {
                        Noeud fromNode = mongraphe.Noeuds[lien.Item1];
                        Noeud toNode = mongraphe.Noeuds[lien.Item2];
                        g.DrawLine(pen, fromNode.Position, toNode.Position);
                    }
                    foreach (KeyValuePair<int, Noeud> entry in mongraphe.Noeuds)
                    {
                        Noeud noeud = entry.Value;
                        g.FillEllipse(brush, noeud.Position.X - 10, noeud.Position.Y - 10, 20, 20);
                        g.DrawString(noeud.IdNoeud.ToString(), font, Brushes.White, noeud.Position.X - 5, noeud.Position.Y - 5);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du dessin du graphe : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
