using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using PSI_MARESCHAL_KHOUJA_MOTTAY;


namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public class MetroForm : Form
    {
        private GrapheMetro _graphe;
        private List<Station> _chemin;
        private float zoom = 1.5f;
        private const float ZoomStep = 0.1f;
        private float offsetX = 0;
        private float offsetY = 0;
        private bool isDragging = false;
        private Point lastMousePosition;
        private List<Station> arborescence;

        public MetroForm(GrapheMetro graphe, List<Station> chemin = null, Dictionary<Station, int> coloration = null)
        {
            _graphe = graphe;
            _chemin = chemin;
            _coloration = coloration;

            Text = "Réseau du Métro Parisien";
            Size = new Size(1600, 1400);
            DoubleBuffered = true;
            BackColor = Color.White;

            MouseWheel += MetroForm_MouseWheel;
            MouseDown += MetroForm_MouseDown;
            MouseUp += MetroForm_MouseUp;
            MouseMove += MetroForm_MouseMove;
        }



        private Dictionary<Station, int> _coloration;

        
        public MetroForm(GrapheMetro graphe, Dictionary<Station, int> coloration)
        {
            _graphe = graphe;
            _coloration = coloration;

            Text = "Réseau du Métro Parisien - Coloration";
            Size = new Size(1600, 1400);
            DoubleBuffered = true;
            BackColor = Color.White;

            MouseWheel += MetroForm_MouseWheel;
            MouseDown += MetroForm_MouseDown;
            MouseUp += MetroForm_MouseUp;
            MouseMove += MetroForm_MouseMove;
        }


        private void MetroForm_MouseWheel(object sender, MouseEventArgs e)
        {
            float oldZoom = zoom;
            zoom = Math.Max(0.2f, Math.Min(5f, zoom + (e.Delta > 0 ? ZoomStep : -ZoomStep)));
            offsetX = e.X - (e.X - offsetX) * (zoom / oldZoom);
            offsetY = e.Y - (e.Y - offsetY) * (zoom / oldZoom);
            Invalidate();
        }
        private void MetroForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePosition = e.Location;
            }
        }
        private void MetroForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void MetroForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                offsetX += e.X - lastMousePosition.X;
                offsetY += e.Y - lastMousePosition.Y;
                lastMousePosition = e.Location;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_graphe.Stations.Count == 0)
            {
                e.Graphics.DrawString("Aucune donnée chargée", new Font("Arial", 15), Brushes.Pink, 20, 20);
                return;
            }

            double minLon = _graphe.Stations.Min(s => s.Longitude);
            double maxLon = _graphe.Stations.Max(s => s.Longitude);
            double minLat = _graphe.Stations.Min(s => s.Latitude);
            double maxLat = _graphe.Stations.Max(s => s.Latitude);

            float padding = 0.4f;
            float scale = zoom * 1.3f * (float)Math.Min(
                ClientSize.Width * (1 - padding) / (maxLon - minLon),
                ClientSize.Height * (1 - padding) / (maxLat - minLat));

            float baseOffsetX = (float)(-minLon * scale) + ClientSize.Width * padding / 2-280;
            float baseOffsetY = (float)(-minLat * scale) + ClientSize.Height * padding / 2-120;

            float finalOffsetX = baseOffsetX + offsetX;
            float finalOffsetY = baseOffsetY + offsetY;
            foreach (var (from, to) in _graphe.Connexions)
            {
                float x1 = (float)(from.Longitude * scale) + finalOffsetX;
                float y1 = ClientSize.Height - ((float)(from.Latitude * scale) + finalOffsetY);
                float x2 = (float)(to.Longitude * scale) + finalOffsetX;
                float y2 = ClientSize.Height - ((float)(to.Latitude * scale) + finalOffsetY);

                using (Pen pen = new Pen(Color.Pink, 0.4f))
                {
                    pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4f, 4f);
                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                }
            }
            if (_chemin != null)
            {
                for (int i = 0; i < _chemin.Count - 1; i++)
                {
                    var from = _chemin[i];
                    var to = _chemin[i + 1];

                    float x1 = (float)(from.Longitude * scale) + finalOffsetX;
                    float y1 = ClientSize.Height - ((float)(from.Latitude * scale) + finalOffsetY);
                    float x2 = (float)(to.Longitude * scale) + finalOffsetX;
                    float y2 = ClientSize.Height - ((float)(to.Latitude * scale) + finalOffsetY);

                    using (Pen pen = new Pen(Color.Red, 3f))
                    {
                        e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                    }
                }
            }

            foreach (var station in _graphe.Stations)
            {
                float x = (float)(station.Longitude * scale) + finalOffsetX;
                float y = ClientSize.Height - ((float)(station.Latitude * scale) + finalOffsetY);

                
                Brush brush;
                if (_coloration != null && _coloration.TryGetValue(station, out int couleurId))
                {
                    brush = new SolidBrush(CouleurDepuisIndice(couleurId));
                }
                else if (_chemin != null && _chemin.Contains(station))
                {
                    brush = Brushes.Red;
                }
                else
                {
                    brush = Brushes.LightBlue;
                }


                e.Graphics.FillEllipse(brush, x - 5, y - 5, 8, 8);
                e.Graphics.DrawString(station.Nom, new Font("Arial", 6), Brushes.Black, x + 6, y - 5);
            }
        }
        private Color CouleurDepuisIndice(int id)
        {
            Color[] palette = new Color[]
            {
        Color.LightBlue,
        Color.LightGreen,
        Color.LightPink,
        Color.LightYellow,
        Color.Orange,
        Color.Violet,
        Color.Cyan,
        Color.Brown,
        Color.LightGray,
        Color.Salmon
            };
            return palette[id % palette.Length]; 
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetroForm));
            this.SuspendLayout();
            // 
            // MetroForm
            // 
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(952, 783);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MetroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}
