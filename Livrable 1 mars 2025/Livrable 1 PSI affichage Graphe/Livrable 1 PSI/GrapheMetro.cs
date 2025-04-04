using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
public class GrapheMetro
{
    public List<Station> Stations { get; } = new List<Station>();
    public List<(Station From, Station To)> Connexions { get; } = new List<(Station, Station)>();

    public void ChargerDonnees()
    {
        if (!File.Exists("MetroParis(Noeuds).csv") || !File.Exists("MetroParis(Arcs).csv"))
        {
            MessageBox.Show("Fichiers CSV introuvables");
            return;
        }

        string[] lignesStations = File.ReadAllLines("MetroParis(Noeuds).csv");

        for (int i = 1; i < lignesStations.Length; i++)
        {
            string[] champs = lignesStations[i].Split(';');
            if (champs.Length < 5) continue;

            Station s = new Station();
            s.Id = int.Parse(champs[0].Trim());
            s.Nom = champs[2].Trim();
            s.Longitude = double.Parse(champs[3].Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
            s.Latitude = double.Parse(champs[4].Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
            s.Lignes.Add(champs[1].Trim());
            Stations.Add(s);
        }

        for (int i = 0; i < Stations.Count; i++)
        {
            Station s1 = Stations[i];
            List<string> lignesTrouvees = new List<string>();

            for (int l = 0; l < s1.Lignes.Count; l++)
            {
                string ligne = s1.Lignes[l];
                if (!lignesTrouvees.Contains(ligne))
                {
                    lignesTrouvees.Add(ligne);
                }
            }

            for (int j = 0; j < Stations.Count; j++)
            {
                if (i != j && Stations[j].Nom == s1.Nom)
                {
                    Station s2 = Stations[j];
                    for (int k = 0; k < s2.Lignes.Count; k++)
                    {
                        string ligne = s2.Lignes[k];
                        if (!lignesTrouvees.Contains(ligne))
                        {
                            lignesTrouvees.Add(ligne);
                        }
                    }
                }
            }

            s1.Lignes = lignesTrouvees;
        }

        string[] lignesArcs = File.ReadAllLines("MetroParis(Arcs).csv");

        for (int i = 1; i < lignesArcs.Length; i++)
        {
            string[] champs = lignesArcs[i].Split(';');
            if (champs.Length < 4) continue;

            int fromId = int.Parse(champs[0].Trim());
            int toId = int.Parse(champs[3].Trim());

            Station from = null;
            Station to = null;

            for (int j = 0; j < Stations.Count; j++)
            {
                if (Stations[j].Id == fromId)
                {
                    from = Stations[j];
                }
                if (Stations[j].Id == toId)
                {
                    to = Stations[j];
                }
            }

            if (from != null && to != null)
            {
                Connexions.Add((from, to));
            }
        }
    }
    public List<Station> Dijkstra(int départId, int arrivéeId)
    {
        bool départ = false;
        bool arrivée = false;

        foreach (Station station in Stations)
        {
            if (station.Id == départId || station.Nom == "départ")
            {
                départ = true;
            }
            if (station.Id == arrivéeId || station.Nom == "arrivée")
            {
                arrivée = true;
            }

            if (départ && arrivée)
            {
                break;
            }
        }

        if (!départ || !arrivée)
        {
            Console.WriteLine("Une des stations n'existe pas");
            return null;
        }

        Dictionary<int, double> distance = new Dictionary<int, double>();
        Dictionary<int, int> station_avant = new Dictionary<int, int>();
        List<int> station_nonvisité = new List<int>();

        foreach (Station station in Stations)
        {
            station_nonvisité.Add(station.Id);
            if (station.Id == départId)
            {
                distance[station.Id] = 0;
            }
            else
            {
                distance[station.Id] = double.MaxValue;
            }
            station_avant[station.Id] = -1;
        }

        while (station_nonvisité.Count > 0)
        {
            int currentId = -1;
            double distance_min = double.MaxValue;

            foreach (int id in station_nonvisité)
            {
                if (distance[id] < distance_min)
                {
                    distance_min = distance[id];
                    currentId = id;
                }
            }

            if (currentId == arrivéeId || distance[currentId] == double.MaxValue)
            {
                break;
            }

            station_nonvisité.Remove(currentId);

            List<int> station_voisine = new List<int>();
            foreach (var connexion in Connexions)
            {
                if (connexion.From.Id == currentId)
                {
                    station_voisine.Add(connexion.To.Id);
                }
                else if (connexion.To.Id == currentId)
                {
                    station_voisine.Add(connexion.From.Id);
                }
            }

            Station stationActuelle = null;
            foreach (Station station in Stations)
            {
                if (station.Id == currentId)
                {
                    stationActuelle = station;
                    break;
                }
            }
            if (stationActuelle == null)
            {
                Console.WriteLine("Station avec l'ID " + currentId + " non trouvée.");
            }
            for (int i = 0; i < Stations.Count; i++)
            {
                Station autreStation = Stations[i];
                if (autreStation.Nom == stationActuelle.Nom && autreStation.Id != currentId)
                {
                    station_voisine.Add(autreStation.Id);
                }
            }

            foreach (int voisinId in station_voisine)
            {
                if (!station_nonvisité.Contains(voisinId)) continue;

                double alt = distance[currentId] + 1;

                Station currentStation = null;
                foreach (Station station in Stations)
                {
                    if (station.Id == currentId)
                    {
                        currentStation = station;
                        break;
                    }
                }

                Station voisinStation = null;
                foreach (Station station in Stations)
                {
                    if (station.Id == voisinId)
                    {
                        voisinStation = station;
                        break;
                    }
                }

                bool changementDeLigne = true;
                foreach (string ligneActuelle in currentStation.Lignes)
                {
                    if (voisinStation.Lignes.Contains(ligneActuelle))
                    {
                        changementDeLigne = false;
                        break;
                    }
                }

                if (changementDeLigne)
                {
                    alt += 1;
                }

                if (alt < distance[voisinId])
                {
                    distance[voisinId] = alt;
                    station_avant[voisinId] = currentId;
                }
            }
        }

        List<Station> path = new List<Station>();
        int current = arrivéeId;

        while (current != -1)
        {
            Station station = null;
            foreach (Station s in Stations)
            {
                if (s.Id == current)
                {
                    station = s;
                    break;
                }
            }
            if (station == null)
            {
                Console.WriteLine("Station avec l'ID " + current + " non trouvée.");
            }
            path.Insert(0, station);
            current = station_avant[current];
        }

        if (path.Count == 0 || path[0].Id != départId)
        {
            Console.WriteLine("Aucun chemin trouvé de " + départId + " à " + arrivéeId);
            return null;
        }

        return path;
    }

}
