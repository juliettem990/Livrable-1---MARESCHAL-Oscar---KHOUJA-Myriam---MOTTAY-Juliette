using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable_1_mars_2025
{
    internal class Noeud<T>
    {
        public T IdNoeud { get; set; }
        public List<T> Voisins { get; set; }
        //public int PoidNoeudSuivant {  get; set; }
        public Point Position { get; set; }

        public Noeud(T idNoeud)
        {
            IdNoeud = idNoeud;
            Voisins = new List<T>();
            //PoidNoeudSuivant = ;
        }
    }

}
