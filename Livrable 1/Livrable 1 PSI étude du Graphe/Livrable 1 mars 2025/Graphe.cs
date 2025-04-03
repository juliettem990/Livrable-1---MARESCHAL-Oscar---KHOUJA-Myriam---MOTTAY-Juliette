using Livrable_2_MARESCHAL_Oscar_KHOUJA_Myriam_MOTTAY_Juliette;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace Livrable_2_MARESCHAL_Oscar_KHOUJA_Myriam_MOTTAY_Juliette
{
    
    internal class Graphe<T>
    {
        public Dictionary<T, Noeud<T>> Noeuds = new Dictionary<T, Noeud<T>>();
        public List<Tuple<T, T>> Liens = new List<Tuple<T, T>>();
        

        public void AjouterLien(T antecedant, T suivant)
        {
            try
            {
                Noeud<T> noeud = Noeuds[antecedant];
            }
            catch (KeyNotFoundException)
            {
                Noeuds[antecedant] = new Noeud<T>(antecedant);
            }

            try
            {
                Noeud<T> noeud = Noeuds[suivant];
            }
            catch (KeyNotFoundException)
            {
                Noeuds[suivant] = new Noeud<T>(suivant);
            }

            Noeuds[antecedant].Voisins.Add(suivant);
            Noeuds[suivant].Voisins.Add(antecedant);
            Liens.Add(new Tuple<T, T>(antecedant, suivant));
        }

        public void ChargerDepuisCSV(string cheminFichier, Func<string, T> convert)
        {
            if (File.Exists(cheminFichier))
            {
                // Lire toutes les lignes du fichier
                string[] lines = File.ReadAllLines(cheminFichier);

                // Parcours de chaque ligne du fichier CSV
                foreach (string line in lines)
                {
                    // Diviser la ligne en colonnes en utilisant la virgule comme séparateur
                    string[] columns = line.Split(',');

                    // Afficher les valeurs de chaque colonne
                    foreach (string column in columns)
                    {
                        Console.Write(column + "\t"); // Affichage avec un espace entre les colonnes
                    }

                    // Passage à la ligne suivante
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Le fichier spécifié n'existe pas.");
            }
            /*StreamReader sr = new StreamReader(cheminFichier);
            string ligne;
            bool lectureAretes = false;

            while ((ligne = sr.ReadLine()) != null)
            {
                if (ligne.Length > 0 && ligne[0] == '%')
                {
                    continue;
                }

                string[] parties = ligne.Split(' ');

                if (lectureAretes == false)
                {
                    lectureAretes = true;
                }
                else
                {
                    if (parties.Length == 2)
                    {
                        T u = convert(parties[0]);
                        T v = convert(parties[1]);
                        AjouterLien(u, v);
                    }
                }
            }
            sr.Close(); */
        }
        public void AfficherMatriceAdjacence()
        {
            int n = Convert.ToInt32(Noeuds.Keys.Max());
            int[,] matrice = new int[n + 1, n + 1];

            foreach (var noeud in Noeuds)
                foreach (var voisin in noeud.Value.Voisins)
                {
                    int a = Convert.ToInt32(noeud.Key);
                    int b = Convert.ToInt32(voisin);
                    matrice[a, b] = 1;
                }

            Console.Write("   ");
            for (int i = 1; i <= n; i++)
            {
                if (i < 10)
                    Console.Write("  " + i);
                else if (i < 100)
                    Console.Write(" " + i);
                else
                    Console.Write(i);
            }
            Console.WriteLine();

            Console.Write("   ");
            for (int i = 1; i <= n; i++)
                Console.Write("---");
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " | ");

                for (int j = 1; j <= n; j++)
                {
                    if (matrice[i, j] < 10)
                        Console.Write("  " + matrice[i, j]);
                    else if (matrice[i, j] < 100)
                        Console.Write(" " + matrice[i, j]);
                    else
                        Console.Write(matrice[i, j]);
                }

                Console.WriteLine();
            }

        }
        public void AfficherListeAdjacence()
        {
            List<T> cles = new List<T>();
            foreach (T cle in Noeuds.Keys)
            {
                cles.Add(cle);
            }

            for (int i = 0; i < cles.Count - 1; i++)
            {
                for (int j = i + 1; j < cles.Count; j++)
                {
                    if (Comparer<T>.Default.Compare(cles[j], cles[i]) < 0)
                    {
                        T temp = cles[i];
                        cles[i] = cles[j];
                        cles[j] = temp;
                    }
                }
            }

            foreach (T cle in cles)
            {
                List<T> voisins = Noeuds[cle].Voisins;

                for (int i = 0; i < voisins.Count - 1; i++)
                {
                    for (int j = i + 1; j < voisins.Count; j++)
                    {
                        if (Comparer<T>.Default.Compare(voisins[j], voisins[i]) < 0)
                        {
                            T temp = voisins[i];
                            voisins[i] = voisins[j];
                            voisins[j] = temp;
                        }
                    }
                }

                string texteVoisins = "";
                for (int i = 0; i < voisins.Count; i++)
                {
                    if (i > 0)
                    {
                        texteVoisins += ", ";
                    }
                    texteVoisins += voisins[i].ToString();
                }
                Console.WriteLine(cle + " : " + texteVoisins);
            }
        }

        public void ParcoursLargeurBFS(T sommetDepart)
        {
            HashSet<T> visite = new HashSet<T>();
            Queue<T> file = new Queue<T>();
            file.Enqueue(sommetDepart);
            visite.Add(sommetDepart);

            while (file.Count > 0)
            {
                T noeud = file.Dequeue();
                Console.Write(noeud + " ");

                foreach (T voisin in Noeuds[noeud].Voisins)
                {
                    if (!visite.Contains(voisin))
                    {
                        visite.Add(voisin);
                        file.Enqueue(voisin);
                    }
                }
            }
            Console.WriteLine();
        }

        public void ParcoursProfondeurDFS(T sommetDepart)
        {
            HashSet<T> visite = new HashSet<T>();
            Stack<T> pile = new Stack<T>();
            pile.Push(sommetDepart);

            while (pile.Count > 0)
            {
                T noeud = pile.Pop();
                if (!visite.Contains(noeud))
                {
                    visite.Add(noeud);
                    Console.Write(noeud + " ");

                    foreach (T voisin in Noeuds[noeud].Voisins)
                    {
                        pile.Push(voisin);
                    }
                }
            }
            Console.WriteLine();
        }

        public bool EstConnecte()
        {
            if (Noeuds.Count == 0)
            {
                return false;
            }

            HashSet<T> visite = new HashSet<T>();
            DFSHelper(Noeuds.Keys.GetEnumerator().Current, visite);

            return visite.Count == Noeuds.Count;
        }

        private void DFSHelper(T noeud, HashSet<T> visite)
        {
            if (!visite.Contains(noeud) && Noeuds.ContainsKey(noeud))
            {
                visite.Add(noeud);
                foreach (T voisin in Noeuds[noeud].Voisins)
                {
                    DFSHelper(voisin, visite);
                }
            }
            else
            {
                Console.WriteLine("Erreur : Noeud introuvable -> " + noeud);
            }
        }

        public bool ContientCycle()
        {
            HashSet<T> visite = new HashSet<T>();

            foreach (T noeud in Noeuds.Keys)
            {
                if (!visite.Contains(noeud) && CycleDFS(noeud, default(T), visite))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CycleDFS(T noeud, T parent, HashSet<T> visite)
        {
            visite.Add(noeud);

            foreach (T voisin in Noeuds[noeud].Voisins)
            {
                if (!visite.Contains(voisin))
                {
                    if (CycleDFS(voisin, noeud, visite))
                    {
                        return true;
                    }
                }
                else if (!EqualityComparer<T>.Default.Equals(voisin, parent))
                {
                    return true;
                }
            }
            return false;
        }

        public int OrdreGraphe()
        {
            return Noeuds.Count;
        }

        public int TailleGraphe()
        {
            int taille = 0;

            foreach (KeyValuePair<T, Noeud<T>> entry in Noeuds)
            {
                taille = taille + entry.Value.Voisins.Count;
            }

            return taille / 2;
        }
    }
    

}
