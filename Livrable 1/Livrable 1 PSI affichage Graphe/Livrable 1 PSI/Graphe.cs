using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace Livrable_1_PSI
{
    public class GrapheMetro
    {
        public List<Station> Stations { get; } = new List<Station>();
        public List<(Station From, Station To)> Connexions { get; } = new List<(Station, Station)>();

        public void ChargerDonnees()
        {
            // Vérification des fichiers
            if (!File.Exists("MetroParis(Noeuds).csv") || !File.Exists("MetroParis(Arcs).csv"))
            {
                MessageBox.Show("Fichiers CSV introuvables dans le dossier bin/Debug");
                return;
            }

            // Charger stations avec gestion d'erreur améliorée
            try
            {
                var lines = File.ReadAllLines("MetroParis(Noeuds).csv");
                for (int i = 1; i < lines.Length; i++) // Skip header
                {
                    var parts = lines[i].Split(';');
                    if (parts.Length < 5) continue;

                    Stations.Add(new Station
                    {
                        Id = int.Parse(parts[0].Trim()),
                        Ligne = parts[1].Trim(),
                        Nom = parts[2].Trim(),
                        Longitude = ParseCoordinate(parts[3]),
                        Latitude = ParseCoordinate(parts[4])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lecture stations: {ex.Message}");
            }

            // Charger connexions
            try
            {
                var stationDict = Stations.ToDictionary(s => s.Id);
                var lines = File.ReadAllLines("MetroParis(Arcs).csv");

                for (int i = 1; i < lines.Length; i++) // Skip header
                {
                    var parts = lines[i].Split(';');
                    if (parts.Length < 4) continue;

                    if (int.TryParse(parts[0].Trim(), out int fromId) &&
                        int.TryParse(parts[3].Trim(), out int toId) &&
                        stationDict.TryGetValue(fromId, out Station from) &&
                        stationDict.TryGetValue(toId, out Station to))
                    {
                        Connexions.Add((from, to));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lecture connexions: {ex.Message}");
            }
        }

        private double ParseCoordinate(string value)
        {
            // Normalisation des coordonnées GPS
            value = value.Trim().Replace(',', '.');
            if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
            throw new FormatException($"Coordonnée invalide: {value}");
        }
    }
}
