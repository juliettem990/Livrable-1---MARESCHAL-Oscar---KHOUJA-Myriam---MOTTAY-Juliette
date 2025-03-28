using Livrable_1_mars_2025;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using SkiaSharp;
using System.Data;
using MySql.Data.MySqlClient;


namespace Livrable_1_PSI
{
    internal static class Programme
    {
        /*public static void Visualiser(Graphe<int> graphe)
        {
            int width = 800, height = 600;
            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);
                var pen = new SKPaint { Color = SKColors.Black, StrokeWidth = 2 };
                var brush = new SKPaint { Color = SKColors.Blue, IsAntialias = true };

                Dictionary<int, SKPoint> positions = new Dictionary<int, SKPoint>();
                int centerX = width / 2, centerY = height / 2, rayon = 200;
                int nbNoeuds = graphe.Noeuds.Count, i = 0;

                foreach (var noeud in graphe.Noeuds.Keys)
                {
                    double angle = (2 * Math.PI * i) / nbNoeuds;
                    float x = centerX + (float)(rayon * Math.Cos(angle));
                    float y = centerY + (float)(rayon * Math.Sin(angle));
                    positions[noeud] = new SKPoint(x, y);
                    i++;
                }

                foreach (var noeud in graphe.Noeuds)
                    foreach (var voisin in noeud.Value.Voisins)
                        canvas.DrawLine(positions[noeud.Key], positions[voisin], pen);

                foreach (var noeud in graphe.Noeuds)
                {
                    var pos = positions[noeud.Key];
                    canvas.DrawCircle(pos, 15, brush);
                    canvas.DrawText(noeud.Key.ToString(), pos.X - 10, pos.Y + 5, new SKPaint { Color = SKColors.White, TextSize = 20 });
                }

                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite("graph.png"))
                    data.SaveTo(stream);
            }

            System.Diagnostics.Process.Start("mspaint", "graph.png");
        }*/
        public static void Visualiser(Dictionary<string, List<Tuple<string, double>>> graphe, Dictionary<string, SKPoint> positions)
        {
            int width = 800, height = 600;

            using (var bitmap = new SKBitmap(width, height))
            using (var canvas = new SKCanvas(bitmap))
            {
                canvas.Clear(SKColors.White);
                var pen = new SKPaint { Color = SKColors.Black, StrokeWidth = 2 };
                var brush = new SKPaint { Color = SKColors.Blue, IsAntialias = true };

                Dictionary<string, SKPoint> mapositions = new Dictionary<string, SKPoint>();
                int centerX = width / 2, centerY = height / 2, rayon = 200;
                int nbNoeuds = graphe.Count, i = 0;

                foreach (var noeud in graphe)
                {
                    foreach (var arc in noeud.Value)
                    {
                        if (mapositions.ContainsKey(noeud.Key) && mapositions.ContainsKey(arc.Item1))
                        {
                            canvas.DrawLine(mapositions[noeud.Key], mapositions[arc.Item1], pen);
                        }
                    }
                }
                foreach (var noeud in graphe)
                {
                    if (positions.ContainsKey(noeud.Key))
                    {
                        var pos = positions[noeud.Key];
                        canvas.DrawCircle(pos, 20, brush);  
                        canvas.DrawText(noeud.Key, pos.X - 10, pos.Y + 5, new SKPaint { Color = SKColors.White, TextSize = 20 });
                    }
                }
                using (var image = SKImage.FromBitmap(bitmap))
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite("graph.png"))
                    data.SaveTo(stream);
            }
            System.Diagnostics.Process.Start("mspaint", "graph.png");
        }
        static string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";

        static void Main()
        {
            Graphe<int> monGraphe = new Graphe<int>();
            string cheminCSV = "metroParis(Arcs).csv";
            string cheminCoords = "metroParis(Noeuds).csv";

            monGraphe.ChargerDepuisCSV(cheminCSV, int.Parse);
            #region Connexion/Inscription
            while (true)
            {
                Console.WriteLine("1. Se connecter");
                Console.WriteLine("2. Créer un compte");
                Console.Write("Choisissez une option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Login();
                }
                else if (choice == "2")
                {
                    Register();
                }
                else
                {
                    Console.WriteLine("Option invalide.");
                }
            }
            #endregion
            #region Etude du graphe (Matrice d'adjacence, connexité...)
            /*Console.WriteLine("Matrice d'adjacence :");
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

            //Visualiser(monGraphe);
            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
            */
            #endregion

            Dictionary<string, List<Tuple<string, double>>> mongraphe = new Dictionary<string, List<Tuple<string, double>>>();

            // Vérifie si le fichier existe
            if (File.Exists(cheminCSV))
            {
                // Lire toutes les lignes du fichier
                string[] lines = File.ReadAllLines(cheminCSV);

                // Parcours de chaque ligne du fichier CSV
                foreach (string line in lines)
                {
                    // Diviser la ligne en colonnes
                    string[] columns = line.Split(',');

                    if (columns.Length >= 5)
                    {
                        string node1 = columns[1]; // Nœud de départ (colonne 2)
                        string node2 = columns[2]; // Nœud de destination (colonne 3)
                        double poids = Convert.ToDouble(columns[4]); // Poids de l'arc (colonne 5)

                        // Ajouter les arcs dans le dictionnaire
                        if (!mongraphe.ContainsKey(node1))
                        {
                            mongraphe[node1] = new List<Tuple<string, double>>();
                        }

                        // Ajouter l'arc avec le poids
                        mongraphe[node1].Add(new Tuple<string, double>(node2, poids));
                    }
                }

                // Appel de la fonction pour visualiser le graphe
               // Visualiser(mongraphe);
            }
            else
            {
                Console.WriteLine("Le fichier spécifié n'existe pas.");
            }


            

            
        }
        public static Dictionary<string, SKPoint> LireCoordonnees(string cheminCoords)
        {
            Dictionary<string, SKPoint> positions = new Dictionary<string, SKPoint>();

            if (File.Exists(cheminCoords))
            {
                string[] lines = File.ReadAllLines(cheminCoords);

                // Trouver les min/max des coordonnées pour effectuer la normalisation
                double minLongitude = double.MaxValue, maxLongitude = double.MinValue;
                double minLatitude = double.MaxValue, maxLatitude = double.MinValue;

                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');

                    if (columns.Length == 3)
                    {
                        string nodeName = columns[2];
                        double longitude = Convert.ToDouble(columns[3]);
                        double latitude = Convert.ToDouble(columns[4]);

                        minLongitude = Math.Min(minLongitude, longitude);
                        maxLongitude = Math.Max(maxLongitude, longitude);
                        minLatitude = Math.Min(minLatitude, latitude);
                        maxLatitude = Math.Max(maxLatitude, latitude);

                        // Stocker les coordonnées géographiques du nœud
                        positions[nodeName] = new SKPoint((float)longitude, (float)latitude);
                    }
                }

                // Normaliser les coordonnées pour les adapter à la taille de la carte (espace 2D)
                double scaleX = 800.0 / (maxLongitude - minLongitude);
                double scaleY = 600.0 / (maxLatitude - minLatitude);

                // Appliquer la normalisation pour positionner les nœuds sur la carte
                Dictionary<string, SKPoint> normalizedPositions = new Dictionary<string, SKPoint>();

                foreach (var position in positions)
                {
                    float x = (position.Value.X - (float)minLongitude) * (float)scaleX;
                    float y = (position.Value.Y - (float)minLatitude) * (float)scaleY;
                    normalizedPositions[position.Key] = new SKPoint(x, y);
                }

                return normalizedPositions;
            }
            else
            {
                Console.WriteLine("Le fichier des coordonnées spécifié n'existe pas.");
                return new Dictionary<string, SKPoint>();
            }
        }
        static void Login()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Mot de passe: ");
            string password = Console.ReadLine();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_client FROM Client WHERE email = @Email AND mot_de_passe = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        Console.WriteLine("Connexion réussie!");
                    }
                    else
                    {
                        Console.WriteLine("Email ou mot de passe incorrect.");
                    }
                }
            }
        }

        static void Register()
        {
            // Demander si l'utilisateur est un client ou un cuisinier
            Console.WriteLine("Quel type d'utilisateur êtes-vous ?");
            Console.WriteLine("1. Client");
            Console.WriteLine("2. Cuisinier");
            string choixType = Console.ReadLine();

            // Variables communes
            Console.Write("Nom: ");
            string nom = Console.ReadLine();
            Console.Write("Prénom: ");
            string prenom = Console.ReadLine();

            string email = "";  // Initialisation de la variable email
            bool emailUnique = false;

            // Vérification que l'email est unique
            while (!emailUnique)
            {
                Console.Write("Email: ");
                email = Console.ReadLine();

                // Vérifier si l'email existe déjà dans la base de données
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Client WHERE email = @Email UNION SELECT COUNT(*) FROM Cuisinier WHERE email = @Email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("Cet email est déjà utilisé, veuillez en choisir un autre.");
                        }
                        else
                        {
                            emailUnique = true; // Email unique trouvé, on peut continuer
                        }
                    }
                }
            }

            // Variables spécifiques à chaque type
            string telephone = "", rue = "", numeroRue = "", codePostal = "", ville = "", metroLePlusProche = "", specialiteCulinaire = "";

            // Demander des informations spécifiques en fonction du type d'utilisateur
            if (choixType == "1") // Client
            {
                Console.Write("Téléphone: ");
                telephone = Console.ReadLine();
                Console.Write("Mot de passe: ");
                string password = Console.ReadLine();  // Mot de passe en clair
                Console.Write("Ville: ");
                ville = Console.ReadLine();
                Console.Write("Rue: ");
                rue = Console.ReadLine();
                Console.Write("Numéro de rue: ");
                numeroRue = Console.ReadLine();
                Console.Write("Code postal: ");
                codePostal = Console.ReadLine();
                Console.Write("Métro le plus proche: ");
                metroLePlusProche = Console.ReadLine();

                // Insertion dans la table Client
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Client (nom, prenom, email, telephone, mot_de_passe, ville, rue, numeroRue, codePostal, metroLePlusProche) " +
                                   "VALUES (@Nom, @Prenom, @Email, @Telephone, @Password, @Ville, @Rue, @NumeroRue, @CodePostal, @MetroLePlusProche)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Prenom", prenom);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Telephone", telephone);
                        cmd.Parameters.AddWithValue("@Password", password);  // Utilisation du mot de passe en clair
                        cmd.Parameters.AddWithValue("@Ville", ville);
                        cmd.Parameters.AddWithValue("@Rue", rue);
                        cmd.Parameters.AddWithValue("@NumeroRue", numeroRue);
                        cmd.Parameters.AddWithValue("@CodePostal", codePostal);
                        cmd.Parameters.AddWithValue("@MetroLePlusProche", metroLePlusProche);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Compte client créé avec succès!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erreur: " + ex.Message);
                        }
                    }
                }
            }
            else if (choixType == "2") // Cuisinier
            {
                Console.Write("Téléphone: ");
                telephone = Console.ReadLine();
                Console.Write("Mot de passe: ");
                string password = Console.ReadLine();  // Mot de passe en clair
                Console.Write("Ville: ");
                ville = Console.ReadLine();
                Console.Write("Rue: ");
                rue = Console.ReadLine();
                Console.Write("Numéro de rue: ");
                numeroRue = Console.ReadLine();
                Console.Write("Code postal: ");
                codePostal = Console.ReadLine();
                Console.Write("Métro le plus proche: ");
                metroLePlusProche = Console.ReadLine();
                Console.Write("Spécialité culinaire: ");
                specialiteCulinaire = Console.ReadLine();

                // Insertion dans la table Cuisinier
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Cuisinier (nom, prenom, email, telephone, mot_de_passe, ville, rue, numeroRue, codePostal, metroLePlusProche, specialite_culinaire) " +
                                   "VALUES (@Nom, @Prenom, @Email, @Telephone, @Password, @Ville, @Rue, @NumeroRue, @CodePostal, @MetroLePlusProche, @Specialite)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Prenom", prenom);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Telephone", telephone);
                        cmd.Parameters.AddWithValue("@Password", password);  // Utilisation du mot de passe en clair
                        cmd.Parameters.AddWithValue("@Ville", ville);
                        cmd.Parameters.AddWithValue("@Rue", rue);
                        cmd.Parameters.AddWithValue("@NumeroRue", numeroRue);
                        cmd.Parameters.AddWithValue("@CodePostal", codePostal);
                        cmd.Parameters.AddWithValue("@MetroLePlusProche", metroLePlusProche);
                        cmd.Parameters.AddWithValue("@Specialite", specialiteCulinaire);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Compte cuisinier créé avec succès!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erreur: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Option invalide, retour au menu principal.");
            }
        }


    }
}


