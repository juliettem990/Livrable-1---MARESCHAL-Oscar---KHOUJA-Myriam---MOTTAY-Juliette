using Livrable_2_MARESCHAL_Oscar_KHOUJA_Myriam_MOTTAY_Juliette;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livrable_2_MARESCHAL_Oscar_KHOUJA_Myriam_MOTTAY_Juliette
{
    
    internal class Noeud<T>
     {
         public T IdNoeud { get; set; }
         public List<T> Voisins { get; set; }
         public Point Position { get; set; }

         public Noeud(T idNoeud)
         {
             IdNoeud = idNoeud;
             Voisins = new List<T>();
         }
     }
    
   


}
