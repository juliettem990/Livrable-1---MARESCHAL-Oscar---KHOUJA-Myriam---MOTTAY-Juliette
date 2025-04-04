using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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

    public MetroForm(GrapheMetro graphe, List<Station> chemin = null)
    {
        _graphe = graphe;
        _chemin = chemin;

        Text = "Réseau du Métro Parisien";
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

        float baseOffsetX = (float)(-minLon * scale) + ClientSize.Width * padding / 2;
        float baseOffsetY = (float)(-minLat * scale) + ClientSize.Height * padding / 2;

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
                pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5f, 5f);
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

            var brush = _chemin != null && _chemin.Contains(station)
                ? Brushes.Red
                : Brushes.LightBlue;

            e.Graphics.FillEllipse(brush, x - 5, y - 5, 25, 25);
            e.Graphics.DrawString(station.Nom, new Font("Arial", 15), Brushes.Black, x + 6, y - 5);
        }
    }
}

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var graphe = new GrapheMetro();
        graphe.ChargerDonnees();

        Console.WriteLine("=== SYSTÈME DE NAVIGATION MÉTRO ===");
        Console.WriteLine($"Stations: {graphe.Stations.Count}, Connexions: {graphe.Connexions.Count}");

        while (true)
        {
            Console.WriteLine("\n1. Afficher carte\n2. Chercher itinéraire\n3. Quitter");
            Console.Write("Choix: ");
            var choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Application.Run(new MetroForm(graphe));
                    break;

                case "2":
                    Console.Write("ID départ: ");
                    if (!int.TryParse(Console.ReadLine(), out int startId)) break;
                    Console.Write("ID arrivée: ");
                    if (!int.TryParse(Console.ReadLine(), out int endId)) break;

                    var chemin = graphe.Dijkstra(startId, endId);
                    if (chemin == null)
                    {
                        Console.WriteLine("Aucun chemin trouvé");
                    }
                    else
                    {
                        Console.WriteLine($"Itinéraire ({chemin.Count} stations):");
                        foreach (var s in chemin)
                            Console.WriteLine($"{s.Id}. {s.Nom}");

                        Application.Run(new MetroForm(graphe, chemin));
                    }
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Choix invalide");
                    break;
            }
        }
    }
}