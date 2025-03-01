using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Livrable_1_PSI
{
    internal static class Programme
    {
        static void Main()
        {
            Graphe monGraphe = new Graphe();
            string cheminMTX = "soc-karate.mtx";
            monGraphe.ChargerDepuisMTX(cheminMTX);

            Console.WriteLine("Matrice d'adjacence :");
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

            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }

    internal class Noeud
    {
        public int Id { get; set; }
        public List<int> Voisins { get; set; } = new List<int>();

        public Noeud(int id)
        {
            Id = id;
        }
    }

    internal class Graphe
    {
        public Dictionary<int, Noeud> Noeuds { get; set; } = new Dictionary<int, Noeud>();

        public void AjouterLien(int precedent, int suivant)
        {
            if (!Noeuds.ContainsKey(precedent))
                Noeuds[precedent] = new Noeud(precedent);
            if (!Noeuds.ContainsKey(suivant))
                Noeuds[suivant] = new Noeud(suivant);
            Noeuds[precedent].Voisins.Add(suivant);
            Noeuds[suivant].Voisins.Add(precedent);
        }

        public void AfficherListeAdjacence()
        {
            foreach (var noeud in Noeuds.OrderBy(n => n.Key))
            {
                noeud.Value.Voisins.Sort();
                Console.WriteLine($"{noeud.Key} : {string.Join(", ", noeud.Value.Voisins)}");
            }
        }

        public void AfficherMatriceAdjacence()
        {
            int n = Noeuds.Keys.Max();
            int[,] matrice = new int[n + 1, n + 1];

            foreach (var noeud in Noeuds)
                foreach (var voisin in noeud.Value.Voisins)
                    matrice[noeud.Key, voisin] = 1;

            Console.Write("   ");
            for (int i = 1; i <= n; i++)
                Console.Write($"{i,3}");
            Console.WriteLine();

            Console.Write("   ");
            for (int i = 1; i <= n; i++)
                Console.Write("---");
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{i,2} | ");
                for (int j = 1; j <= n; j++)
                    Console.Write($"{matrice[i, j],3}");
                Console.WriteLine();
            }
        }

        public void ParcoursLargeurBFS(int sommetDepart)
        {
            HashSet<int> visite = new HashSet<int>();
            Queue<int> file = new Queue<int>();
            file.Enqueue(sommetDepart);
            visite.Add(sommetDepart);
            while (file.Count > 0)
            {
                int noeud = file.Dequeue();
                Console.Write(noeud + " ");
                foreach (int voisin in Noeuds[noeud].Voisins)
                {
                    if (visite.Add(voisin))
                        file.Enqueue(voisin);
                }
            }
            Console.WriteLine();
        }

        public void ParcoursProfondeurDFS(int sommetDepart)
        {
            HashSet<int> visite = new HashSet<int>();
            Stack<int> pile = new Stack<int>();
            pile.Push(sommetDepart);
            while (pile.Count > 0)
            {
                int noeud = pile.Pop();
                if (visite.Add(noeud))
                {
                    Console.Write(noeud + " ");
                    foreach (int voisin in Noeuds[noeud].Voisins)
                        pile.Push(voisin);
                }
            }
            Console.WriteLine();
        }

        public bool EstConnecte()
        {
            if (Noeuds.Count == 0) return false;
            HashSet<int> visite = new HashSet<int>();
            DFSHelper(Noeuds.Keys.First(), visite);
            return visite.Count == Noeuds.Count;
        }

        private void DFSHelper(int noeud, HashSet<int> visite)
        {
            if (visite.Add(noeud))
                foreach (int voisin in Noeuds[noeud].Voisins)
                    DFSHelper(voisin, visite);
        }

        public bool ContientCycle()
        {
            HashSet<int> visite = new HashSet<int>();
            return Noeuds.Keys.Any(noeud => !visite.Contains(noeud) && CycleDFS(noeud, -1, visite));
        }

        private bool CycleDFS(int noeud, int parent, HashSet<int> visite)
        {
            visite.Add(noeud);
            foreach (int voisin in Noeuds[noeud].Voisins)
            {
                if (!visite.Contains(voisin))
                {
                    if (CycleDFS(voisin, noeud, visite)) return true;
                }
                else if (voisin != parent)
                {
                    return true;
                }
            }
            return false;
        }

        public int OrdreGraphe() => Noeuds.Count;

        public int TailleGraphe() => Noeuds.Sum(n => n.Value.Voisins.Count) / 2;

        public void ChargerDepuisMTX(string cheminFichier)
        {
            foreach (var ligne in File.ReadLines(cheminFichier).Where(l => !l.StartsWith("%")))
            {
                var parties = ligne.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parties.Length == 2)
                    AjouterLien(int.Parse(parties[0]), int.Parse(parties[1]));
            }
        }
    }
}


