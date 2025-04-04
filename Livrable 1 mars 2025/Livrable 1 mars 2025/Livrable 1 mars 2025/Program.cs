using Livrable_2_MARESCHAL_Oscar_KHOUJA_Myriam_MOTTAY_Juliette;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using SkiaSharp;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net.Sockets;


namespace Livrable_2_MARESCHAL_Oscar_KHOUJA_Myriam_MOTTAY_Juliette
{
    internal static class Programme
    {
        static string connectionString = "Server=localhost;Port=3306;Database=LivInParis;User ID=root;Password='111222';";

        static void Main()
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("*             LiveInParis            *");
            Console.WriteLine("**************************************");
            Console.WriteLine("\nBienvenue sur LiveInParis, votre application de commande de plats faits maison !"); 
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
            static void Login()
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Mot de passe: ");
                string password = Console.ReadLine();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string queryClient = "SELECT id_client, prenom FROM Client WHERE email = @Email AND mot_de_passe = @Password LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(queryClient, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id_client = reader.GetInt32(0);
                                string prenom = reader.GetString(1);
                                Console.WriteLine("\nBonjour " + prenom + " !");
                                reader.Close();
                                MenuClient(id_client); 
                                return;
                            }
                        }
                    }
                    string queryCuisinier = "SELECT id_cuisinier, prenom FROM Cuisinier WHERE email = @Email AND mot_de_passe = @Password LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(queryCuisinier, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id_cuisinier = reader.GetInt32(0);
                                string prenom = reader.GetString(1);
                                Console.WriteLine("\nBonjour Cuisinier " + prenom + " !");
                                reader.Close();
                                MenuCuisinier(id_cuisinier);
                                return;
                            }
                        }
                    }
                    Console.WriteLine("Email ou mot de passe incorrect.");
                }
            }
            static void MenuClient(int id_client)
            {
                while (true)
                {
                    Console.WriteLine("\nMenu Client :");
                    Console.WriteLine("1. Commander un plat");
                    Console.WriteLine("2. Voir mes commandes");
                    Console.WriteLine("3. Valider la réception d'une commande");
                    Console.WriteLine("4. Noter un cuisinier");
                    Console.WriteLine("5. Recommandations (Meilleurs cuisiniers)");
                    Console.WriteLine("6. Se déconnecter");
                    Console.Write("Choisissez une option : ");
                    string choix = Console.ReadLine();

                    switch (choix)
                    {
                        case "1":
                            CommanderPlat(id_client);
                            break;
                        case "2":
                            VoirCommandesClient(id_client);
                            break;
                        case "3":
                            ValiderReceptionCommande(id_client);
                            break;
                        case "4":                    
                            try
                            {
                                Console.Write("Entrez l'ID de la commande que vous souhaitez noter : ");
                                int id_commande = Convert.ToInt32(Console.ReadLine());
                                NoterCuisinier(id_commande);
                            }
                            catch
                            {
                                Console.WriteLine("Erreur : Veuillez entrer un ID valide.");
                            }
                            break;
                        case "5":
                            AfficherRecommandations();
                            break;
                        case "6":
                            Console.WriteLine("Déconnexion...");
                            return;
                        default:
                            Console.WriteLine("Option invalide, essayez encore");
                            break;
                    }
                }
            }
            static void MenuCuisinier(int id_cuisinier)
            {
                
                while (true)
                {
                    Console.WriteLine("\nMenu Cuisinier :");
                    Console.WriteLine("1. Ajouter un plat");
                    Console.WriteLine("2. Mettre à jour un plat");
                    Console.WriteLine("3. Valider et envoyer une commande");
                    Console.WriteLine("4. Consulter ma note moyenne");
                    Console.WriteLine("5. Voir le classement des cuisiniers");
                    Console.WriteLine("6. Se déconnecter");
                    Console.Write("Choisissez une option : ");
                    string choix = Console.ReadLine();

                    switch (choix)
                    {
                        case "1":
                            AjouterPlat(id_cuisinier);
                            break;
                        case "2":
                            MettreAJourPlat(id_cuisinier);
                            break;
                        case "3":
                            ValiderEnvoyerCommande(id_cuisinier);
                            break;
                        case "4":
                            ConsulterNoteMoyenne(id_cuisinier);
                            break;
                        case "5":
                            AfficherClassementCuisiniers(id_cuisinier);
                            break;
                        case "6":
                            Console.WriteLine("Déconnexion...");
                            return;
                        default:
                            Console.WriteLine("Option invalide, essayez encore.");
                            break;
                    }
                }
            }
            static void CommanderPlat(int id_client)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_plat, nom, prix, nombre_portion FROM Plat";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("\nPlats disponibles :");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32(0) + " - " + reader.GetString(1) + " : " + reader.GetDecimal(2) + "eur (" + reader.GetInt32(3) + " portions restantes)");
                        }
                    }
                    Console.Write("Entrez l'ID du plat que vous voulez commander : ");
                    int id_plat = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nombre de portions : ");
                    int nbPortions = Convert.ToInt32(Console.ReadLine());
                    string checkStock = "SELECT nombre_portion FROM Plat WHERE id_plat = @Plat";
                    using (MySqlCommand cmd = new MySqlCommand(checkStock, conn))
                    {
                        cmd.Parameters.AddWithValue("@Plat", id_plat);
                        int stockRestant = Convert.ToInt32(cmd.ExecuteScalar());
                        if (stockRestant < nbPortions)
                        {
                            Console.WriteLine("Désolé, il ne reste que " + stockRestant + " portions disponibles.");
                            return;
                        }
                    }
                    string getAdresse = "SELECT metroLePlusProche FROM Client WHERE id_client = @Client";
                    string adresseLivraison = "";
                    using (MySqlCommand cmd = new MySqlCommand(getAdresse, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", id_client);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            adresseLivraison = result.ToString();
                        }
                        else
                        {
                            Console.WriteLine("Erreur : Impossible de récupérer l'adresse de livraison.");
                            return;
                        }
                    }
                    string getCuisinier = "SELECT id_cuisinier FROM Plat WHERE id_plat = @Plat";
                    int id_cuisinier;
                    using (MySqlCommand cmd = new MySqlCommand(getCuisinier, conn))
                    {
                        cmd.Parameters.AddWithValue("@Plat", id_plat);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            id_cuisinier = Convert.ToInt32(result);
                        }
                        else
                        {
                            Console.WriteLine("Erreur : Impossible de récupérer l'ID du cuisinier.");
                            return;
                        }
                    }
                    string insertCommande = "INSERT INTO Commande (id_client, id_cuisinier, id_plat, date_heure_commande, nombre_portion, statut_commande, adresse_livraison) " +
                                            "VALUES (@Client, @Cuisinier, @Plat, NOW(), @Portions, 'En attente', @Adresse)";
                    using (MySqlCommand cmd = new MySqlCommand(insertCommande, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", id_client);
                        cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        cmd.Parameters.AddWithValue("@Plat", id_plat);
                        cmd.Parameters.AddWithValue("@Portions", nbPortions);
                        cmd.Parameters.AddWithValue("@Adresse", adresseLivraison);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Commande passée avec succès !");
                    }
                    string updateStock = "UPDATE Plat SET nombre_portion = nombre_portion - @Portions WHERE id_plat = @Plat";
                    using (MySqlCommand cmd = new MySqlCommand(updateStock, conn))
                    {
                        cmd.Parameters.AddWithValue("@Plat", id_plat);
                        cmd.Parameters.AddWithValue("@Portions", nbPortions);
                        cmd.ExecuteNonQuery();
                    }
                }
            }         
            static void NoterCuisinier(int id_commande)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_cuisinier, id_client FROM Commande WHERE id_commande = @Commande";
                    int id_cuisinier, id_client;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Commande", id_commande);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id_cuisinier = reader.GetInt32("id_cuisinier");
                                id_client = reader.GetInt32("id_client");
                            }
                            else
                            {
                                Console.WriteLine("\nErreur : Commande introuvable");
                                return;
                            }
                        }
                    }
                    string checkQuery = "SELECT COUNT(*) FROM Notation WHERE id_commande = @Commande";
                    using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Commande", id_commande);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine("\nVous avez déjà noté cette commande");
                            return;
                        }
                    }
                    Console.Write("Entrez votre note pour le cuisinier (1 à 5) : ");
                    string input = Console.ReadLine();
                    int note;
                    try
                    {
                        note = Convert.ToInt32(input); 
                        if (note >= 1 && note <= 5)
                        {
                            string insertQuery = "INSERT INTO Notation (id_commande, id_client, id_cuisinier, note_attribuee) " +
                                                 "VALUES (@Commande, @Client, @Cuisinier, @Note)";
                            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Commande", id_commande);
                                cmd.Parameters.AddWithValue("@Client", id_client);
                                cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                                cmd.Parameters.AddWithValue("@Note", note);
                                cmd.ExecuteNonQuery();
                            }
                            string updateQuery = @"
                UPDATE Cuisinier 
                SET note_moyenne = (SELECT AVG(note_attribuee) FROM Notation WHERE id_cuisinier = @Cuisinier) 
                WHERE id_cuisinier = @Cuisinier";
                            using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                                cmd.ExecuteNonQuery();
                            }
                            Console.WriteLine("\nMerci ! Votre note a été enregistrée avec succès");
                        }
                        else
                        {
                            Console.WriteLine("Erreur : La note doit être entre 1 et 5");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Erreur : Veuillez entrer un nombre valide");
                    }
                }
            }
            static void AjouterPlat(int id_cuisinier)
            {
                Console.Write("Nom du plat : ");
                string nom = Console.ReadLine();
                Console.Write("Nombre de portions disponibles : ");
                int nbPersonnes = int.Parse(Console.ReadLine());
                Console.Write("Type de plat (Entrée, Plat principal, Dessert) : ");
                string typePlat = Console.ReadLine();
                Console.Write("Nationalité du plat : ");
                string nationalite = Console.ReadLine();
                Console.Write("Prix (eur) : ");
                decimal prix = decimal.Parse(Console.ReadLine());
                Console.Write("Ingrédients (séparés par une virgule) : ");
                string ingredients = Console.ReadLine();
                Console.Write("Date de fabrication : ");
                DateTime DateFabrication = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Date de péremption : ");
                DateTime DatePeremption = Convert.ToDateTime(Console.ReadLine());

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Plat (id_cuisinier, nom, nombre_portion, type_plat, nationalite_plat, prix, ingredients, date_fabrication, date_peremption) " +
                                   "VALUES (@Cuisinier, @Nom, @NbPersonnes, @Type, @Nationalite, @Prix, @Ingredients, @DateFabrication, @DatePeremption)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@NbPersonnes", nbPersonnes);
                        cmd.Parameters.AddWithValue("@Type", typePlat);
                        cmd.Parameters.AddWithValue("@Nationalite", nationalite);
                        cmd.Parameters.AddWithValue("@Prix", prix);
                        cmd.Parameters.AddWithValue("@Ingredients", ingredients);
                        cmd.Parameters.AddWithValue("@DateFabrication", DateFabrication);
                        cmd.Parameters.AddWithValue("@DatePeremption", DatePeremption);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Plat ajouté avec succès !");
                    }
                }
            }
            static void MettreAJourPlat(int id_cuisinier)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM Plat WHERE id_cuisinier = @Cuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(countQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                        {
                            Console.WriteLine("\nVous n'avez aucun plat enregistré. Ajoutez-en pour attirer plus de clients !");
                            return;
                        }
                    }
                    string query = "SELECT id_plat, nom, prix, nombre_portion FROM Plat WHERE id_cuisinier = @Cuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nVos plats :");
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetInt32(0) + " - " + reader.GetString(1) + " : " + reader.GetDecimal(2) + "eur (" + reader.GetInt32(3) + " portions)");
                            }
                        }
                    }
                    Console.Write("\nEntrez l'ID du plat à modifier : ");
                    int id_plat;

                    try
                    {
                        id_plat = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("ID invalide. Opération annulée.");
                        return;
                    }
                    decimal oldPrix = 0;
                    int oldQuantite = 0;
                    string fetchQuery = "SELECT prix, nombre_portion FROM Plat WHERE id_plat = @Plat AND id_cuisinier = @Cuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(fetchQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Plat", id_plat);
                        cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldPrix = reader.GetDecimal(0);
                                oldQuantite = reader.GetInt32(1);
                            }
                            else
                            {
                                Console.WriteLine("Plat introuvable. Opération annulée.");
                                return;
                            }
                        }
                    }
                    Console.Write("Nouveau prix (eur) (Actuel: " + oldPrix + "): ");
                    string inputPrix = Console.ReadLine();
                    decimal newPrix = string.IsNullOrWhiteSpace(inputPrix) ? oldPrix : decimal.Parse(inputPrix);    //
                    Console.Write("Nouvelle quantité de portions (Actuelle: " + oldQuantite + "): ");
                    string inputQuantite = Console.ReadLine();
                    int newQuantite = string.IsNullOrWhiteSpace(inputQuantite) ? oldQuantite : int.Parse(inputQuantite);    //
                    string updateQuery = "UPDATE Plat SET prix = @Prix, nombre_portion = @Quantite WHERE id_plat = @Plat";
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Prix", newPrix);
                        cmd.Parameters.AddWithValue("@Quantite", newQuantite);
                        cmd.Parameters.AddWithValue("@Plat", id_plat);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Plat mis à jour avec succès !");
                    }
                }
            }
            static void ConsulterNoteMoyenne(int id_cuisinier)
            {

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM Notation WHERE id_cuisinier = @Cuisinier";
                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        int count = Convert.ToInt32(countCmd.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("\nVous n'avez pas encore reçu de notes");
                            Console.WriteLine("Continuez à cuisiner de délicieux plats pour impressionner vos clients !");
                            return;
                        }
                    }
                    string query = "SELECT AVG(note_attribuee) FROM Notation WHERE id_cuisinier = @Cuisinier";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                            Console.WriteLine("Votre note moyenne est : " + Math.Round(Convert.ToDouble(result), 2) + "/5");
                        else
                            Console.WriteLine("Aucune note reçue pour l'instant.");
                    }
                }
            }
            static void ValiderEnvoyerCommande(int id_cuisinier)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM Commande WHERE id_cuisinier = @Cuisinier AND statut_commande = 'En attente'";
                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        int count = Convert.ToInt32(countCmd.ExecuteScalar());
                        if (count == 0)
                        {
                            Console.WriteLine("\nAucune commande en attente pour le moment.");
                            Console.WriteLine("Ajoutez de nouveaux plats pour attirer plus de clients !");
                            return;
                        }
                    }
                    string query = "SELECT id_commande, id_client, nombre_portion, adresse_livraison FROM Commande WHERE id_cuisinier = @Cuisinier AND statut_commande = 'En attente'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nCommandes en attente :");
                            while (reader.Read())
                            {
                                Console.WriteLine("Commande " + reader.GetInt32(0) + " - Client " + reader.GetInt32(1) + " - Portions: " + reader.GetInt32(2) + " - Adresse: " + reader.GetString(3));
                            }
                        }
                    }
                    Console.Write("\nEntrez l'ID de la commande à valider : ");
                    try
                    {
                        int id_commande = Convert.ToInt32(Console.ReadLine());
                        string updateQuery = "UPDATE Commande SET statut_commande = 'En cours' WHERE id_commande = @Commande AND id_cuisinier = @Cuisinier";
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Commande", id_commande);
                            cmd.Parameters.AddWithValue("@Cuisinier", id_cuisinier);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Commande validée et en cours de livraison !");
                            }
                            else
                            {
                                Console.WriteLine("Erreur : Commande non trouvée.");
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Erreur : ID invalide.");
                    }
                    
                }
            }
            static void VoirCommandesClient(int id_client)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM Commande WHERE id_client = @Client";
                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@Client", id_client);
                        int count = Convert.ToInt32(countCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            Console.WriteLine("\nVous n'avez encore passé aucune commande.");
                            Console.WriteLine("Essayez un nouveau plat dès maintenant !");
                            return;
                        }
                    }
                    string query = "SELECT id_commande, statut_commande FROM Commande WHERE id_client = @Client";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", id_client);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nVos commandes validées:");
                            while (reader.Read())
                            {
                                Console.WriteLine("Commande " + reader.GetInt32(0) + " - Statut : " + reader.GetString(1));
                            }
                        }
                    }
                }
            }
            static void ValiderReceptionCommande(int id_client)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string countQuery = "SELECT COUNT(*) FROM Commande WHERE id_client = @Client AND statut_commande = 'En cours'";
                    using (MySqlCommand cmd = new MySqlCommand(countQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", id_client);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                        {
                            Console.WriteLine("\nVous n'avez aucune commande en cours de réception.");
                            Console.WriteLine("Consultez les plats disponibles pour passer une nouvelle commande !");
                            return;
                        }
                    }
                    string query = "SELECT id_commande FROM Commande WHERE id_client = @Client AND statut_commande = 'En cours'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Client", id_client);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nCommandes en cours :");
                            while (reader.Read())
                            {
                                Console.WriteLine("Commande " + reader.GetInt32(0));
                            }
                        }
                    }
                    Console.Write("\nEntrez l'ID de la commande reçue : ");
                    try
                    {
                        int id_commande = Convert.ToInt32(Console.ReadLine());
                        string updateQuery = "UPDATE Commande SET statut_commande = 'Livré' WHERE id_commande = @Commande AND id_client = @Client";
                        using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Commande", id_commande);
                            cmd.Parameters.AddWithValue("@Client", id_client);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine("Commande livrée ! Vous pouvez maintenant noter le cuisinier.");
                                NoterCuisinier(id_commande);
                            }
                            else
                            {
                                Console.WriteLine("Erreur : Commande non trouvée.");
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Erreur : ID invalide.");
                        return;
                    }                
                }
            }
            static void AfficherRecommandations()
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT nom, note_moyenne 
            FROM Cuisinier 
            WHERE note_moyenne IS NOT NULL
            ORDER BY note_moyenne DESC, id_cuisinier ASC
            LIMIT 3";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nRECOMMANDATIONS");
                            while (reader.Read())
                            {
                                Console.WriteLine(reader.GetString(0) + " - " + Math.Round(Convert.ToDouble(reader.GetDecimal(1)), 2) + "/5");
                            }
                        }
                    }
                }
            }
            static void AfficherClassementCuisiniers(int id_cuisinier)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT id_cuisinier, nom, note_moyenne,
                   RANK() OVER (ORDER BY note_moyenne DESC) AS classement
            FROM Cuisinier 
            WHERE note_moyenne IS NOT NULL";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("\nCLASSEMENT DES CUISINIERS");
                            int rangCuisinier = 0;
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nom = reader.GetString(1);
                                double note = reader.GetDouble(2);
                                int rank = reader.GetInt32(3);

                                Console.WriteLine(rank + ". " + nom + " - " + Math.Round(note, 2) + "/5");

                                if (id == id_cuisinier)
                                {
                                    rangCuisinier = rank;
                                }
                            }
                            Console.WriteLine("\nBilan personnel :");
                            if (rangCuisinier == 1)
                            {
                                Console.WriteLine("Bravo ! Vous êtes le meilleur cuisinier ! Continuez comme ça !");
                            }
                            else if (rangCuisinier <= 3)
                            {
                                Console.WriteLine("Vous êtes dans le top 3 ! Gardez le cap !");
                            }
                            else if (rangCuisinier <= 10)
                            {
                                Console.WriteLine("Vous êtes bien classé, continuez à vous améliorer !");
                            }
                            else
                            {
                                Console.WriteLine("Vous êtes en bas du classement... Changez peut-être de cuisine !");
                            }
                        }
                    }
                }
            }           
            static void Register()
            {
                Console.WriteLine("Êtes-vous un : ");
                Console.WriteLine("1. Client");
                Console.WriteLine("2. Cuisinier");
                string choixType = Console.ReadLine();
                string nom = "", prenom = "", email = "", telephone = "", rue = "", numeroRue = "", codePostal = "", ville = "", metroLePlusProche = "", specialiteCulinaire = "", password = "";
                if (choixType == "1")
                {
                    Console.WriteLine("Êtes-vous un client particulier ou une entreprise ?");
                    Console.WriteLine("1. Particulier");
                    Console.WriteLine("2. Entreprise");
                    string choixClient = Console.ReadLine();
                    if (choixClient == "1") 
                    {
                        Console.Write("Nom: ");
                        nom = Console.ReadLine();
                        Console.Write("Prénom: ");
                        prenom = Console.ReadLine();
                    }
                    else if (choixClient == "2") 
                    {
                        Console.Write("Nom du référent: ");
                        nom = Console.ReadLine();
                        Console.Write("Nom de l'entreprise: ");
                        prenom = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Option invalide, inscription annulée.");
                        return;
                    }
                }
                else if (choixType == "2") 
                {
                    Console.Write("Nom: ");
                    nom = Console.ReadLine();
                    Console.Write("Prénom: ");
                    prenom = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Option invalide, retour au menu principal.");
                    return;
                }
                bool emailUnique = false;
                while (emailUnique == false)
                {
                    Console.Write("Email: ");
                    email = Console.ReadLine();

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
                                emailUnique = true;
                            }
                        }
                    }
                }
                Console.Write("Téléphone: ");
                telephone = Console.ReadLine();
                Console.Write("Mot de passe: ");
                password = Console.ReadLine();
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
                if (choixType == "1") 
                {
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
                            cmd.Parameters.AddWithValue("@Password", password);
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
                else if (choixType == "2") 
                {
                    Console.Write("Spécialité culinaire: ");
                    specialiteCulinaire = Console.ReadLine();
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
                            cmd.Parameters.AddWithValue("@Password", password);
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
            }
        }
    }
}


