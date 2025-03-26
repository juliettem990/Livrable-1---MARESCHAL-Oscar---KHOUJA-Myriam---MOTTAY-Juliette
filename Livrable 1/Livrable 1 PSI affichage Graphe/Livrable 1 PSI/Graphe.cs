using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable_1_PSI
{
    internal class Graphe
    {
        public Dictionary<int, Noeud> Noeuds { get; set; } = new Dictionary<int, Noeud>();
        public List<Tuple<int, int>> Liens { get; set; } = new List<Tuple<int, int>>();

        public void AjouterLien(int antecedant, int suivant)
        {
            try
            {
                Noeud noeud = Noeuds[antecedant]; 
            }
            catch (KeyNotFoundException)
            {
                Noeuds[antecedant] = new Noeud(antecedant); 
            }
            try
            {
                Noeud noeud = Noeuds[suivant]; 
            }
            catch (KeyNotFoundException)
            {
                Noeuds[suivant] = new Noeud(suivant); 
            }
            Noeuds[antecedant].Voisins.Add(suivant);
            Noeuds[suivant].Voisins.Add(antecedant);
            Liens.Add(new Tuple<int, int>(antecedant, suivant));
        }

        public void ChargerDepuisMTX(string cheminFichier)
        {
            StreamReader sr = new StreamReader(cheminFichier);
            string ligne;
            bool lectureAretes = false;

            while ((ligne = sr.ReadLine()) != null)
            {
                if (ligne != "" && ligne[0] == '%') 
                    continue;

                string[] parties = ligne.Split(' '); 

                if (lectureAretes == false) 
                {
                    lectureAretes = true;
                }
                else
                {
                    if (parties.Length == 2) 
                    {
                        int u = Convert.ToInt32(parties[0]); 
                        int v = Convert.ToInt32(parties[1]);
                        AjouterLien(u, v);
                    }
                }
            }
            sr.Close(); 

            int centerX = 400;
            int centerY = 300;
            int rayon = 200;
            int nbNoeuds = Noeuds.Count;
            int i = 0;

            foreach (int key in Noeuds.Keys) 
            {
                double angle = (2 * 3.14 * i) / nbNoeuds; 
                int x = centerX + (int)(rayon * Math.Cos(angle));
                int y = centerY + (int)(rayon * Math.Sin(angle));

                Noeuds[key].Position = new Point(x, y);
                i = i + 1; 
            }

        }

        public void AfficherListeAdjacence()
        {
            List<int> cles = new List<int>();
            foreach (int cle in Noeuds.Keys) cles.Add(cle);

            for (int i = 0; i < cles.Count - 1; i++)
                for (int j = i + 1; j < cles.Count; j++)
                    if (cles[j] < cles[i]) 
                    { 
                        int temp = cles[i]; 
                        cles[i] = cles[j]; 
                        cles[j] = temp; 
                    }

            foreach (int cle in cles)
            {
                List<int> voisins = Noeuds[cle].Voisins;
                for (int i = 0; i < voisins.Count - 1; i++)
                    for (int j = i + 1; j < voisins.Count; j++)
                        if (voisins[j] < voisins[i]) 
                        { 
                            int temp = voisins[i]; 
                            voisins[i] = voisins[j]; 
                            voisins[j] = temp; 
                        }

                string texteVoisins = "";
                for (int i = 0; i < voisins.Count; i++)
                {
                    if (i > 0) texteVoisins += ", ";
                    texteVoisins += voisins[i].ToString();
                }
                Console.WriteLine(cle + " : " + texteVoisins);
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

            foreach (int noeud in Noeuds.Keys)
            {
                if (!visite.Contains(noeud) && CycleDFS(noeud, -1, visite))
                    return true;
            }

            return false;
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

        public int OrdreGraphe()
        {
            return Noeuds.Count;
        }

        public int TailleGraphe()
        {
            int taille = 0;

            foreach (KeyValuePair<int, Noeud> entry in Noeuds)
            {
                taille = taille + entry.Value.Voisins.Count;
            }

            return taille / 2;
        }



    }
}
