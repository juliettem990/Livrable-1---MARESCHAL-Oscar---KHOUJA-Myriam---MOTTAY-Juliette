using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Livrable_1_PSI
{
    public class MetroForm : Form
    {
        private readonly GrapheMetro _graphe;

        public MetroForm(GrapheMetro graphe)
        {
            _graphe = graphe ?? throw new ArgumentNullException(nameof(graphe));
            Text = "Réseau du Métro Parisien";
            Size = new Size(2000, 2000);
            DoubleBuffered = true;
            BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_graphe.Stations.Count == 0 || _graphe.Connexions.Count == 0)
            {
                e.Graphics.DrawString("Aucune donnée à afficher",
                    new Font("Arial", 15),
                    Brushes.Pink,
                    new PointF(12, 12));
                return;
            }

            // Calcul des bornes
            double minLon = _graphe.Stations.Min(s => s.Longitude);
            double maxLon = _graphe.Stations.Max(s => s.Longitude);
            double minLat = _graphe.Stations.Min(s => s.Latitude);
            double maxLat = _graphe.Stations.Max(s => s.Latitude);


            // Facteurs d'échelle
            float scaleX = (float)(ClientSize.Width * 4 / (maxLon - minLon));
            float scaleY = (float)(ClientSize.Height * 6 / (maxLat - minLat));
            float scale = Math.Min(scaleX, scaleY);
            // Ajustement automatique du zoom
            float padding = 0.1f * 0.1f;  // 10% de marge
            double width = maxLon - minLon;
            double height = maxLat - minLat;
            scale = (float)(Math.Min(
                ClientSize.Width * (1 - padding) / width,
                ClientSize.Height * (1 - padding) / height
            ));

            // Point de référence
            float offsetX = (float)(-minLon * scale) + (ClientSize.Width * 0.1f * 0.2f);
            float offsetY = (float)(-minLat * scale) + (ClientSize.Height * 0.1f);

            // Dessin des connexions
            foreach (var (from, to) in _graphe.Connexions)
            {
                float x1 = (float)(from.Longitude * scale) + offsetX;
                float y1 = ClientSize.Height - ((float)(from.Latitude * scale) + offsetY); // Inversion Y
                float x2 = (float)(to.Longitude * scale) + offsetX;
                float y2 = ClientSize.Height - ((float)(to.Latitude * scale) + offsetY); // Inversion Y

                e.Graphics.DrawLine(new Pen(Color.Pink, 1), x1, y1, x2, y2);
            }

            // Dessin des stations
            foreach (var station in _graphe.Stations)
            {
                float x = (float)(station.Longitude * scale) + offsetX;
                float y = ClientSize.Height - ((float)(station.Latitude * scale) + offsetY); // Inversion Y

                e.Graphics.FillEllipse(Brushes.PaleGreen, x - 3, y - 3, 14, 14);
                e.Graphics.DrawString(station.Nom, Font, Brushes.Black, x + 2, y - 5);
            }
        }
    }
}