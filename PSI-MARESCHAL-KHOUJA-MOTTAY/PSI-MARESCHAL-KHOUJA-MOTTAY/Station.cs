using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using PSI_MARESCHAL_KHOUJA_MOTTAY;


namespace PSI_MARESCHAL_KHOUJA_MOTTAY
{
    public class Station
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<string> Lignes
        {
            get; set;
        } = new List<string>();
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
