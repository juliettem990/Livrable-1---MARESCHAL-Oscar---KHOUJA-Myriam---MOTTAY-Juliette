using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable_1_PSI
{
    internal class Noeud
    {
        public int IdNoeud { get; set; }
        public List<int> Voisins { get; set; }
        public Point Position { get; set; }

        public Noeud(int idNoeud)
        {
            IdNoeud = idNoeud;
            Voisins = new List<int>();
        }
    }

   
}
