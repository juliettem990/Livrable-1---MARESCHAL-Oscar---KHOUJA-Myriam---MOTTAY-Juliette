using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public class Commande
    {
        public int id_commande { get; set; }
        public int id_client { get; set; }
        public int id_cuisinier { get; set; }
        public int id_plat { get; set; }
        public DateTime date_heure_commande { get; set; }
        public int nombre_portion { get; set; }
        public string statut_commande { get; set; }
        public string adresse_livraison { get; set; }
    }

}
