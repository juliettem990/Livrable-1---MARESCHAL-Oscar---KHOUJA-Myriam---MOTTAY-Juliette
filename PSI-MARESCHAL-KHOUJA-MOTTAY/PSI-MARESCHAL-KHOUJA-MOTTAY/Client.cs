using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public class Client
    {
        public int id_client { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string rue { get; set; }
        public string numeroRue { get; set; }
        public int codePostal { get; set; }
        public string ville { get; set; }
        public string metroLePlusProche { get; set; }
        public string telephone { get; set; }
        public string mot_de_passe { get; set; }
    }
}
