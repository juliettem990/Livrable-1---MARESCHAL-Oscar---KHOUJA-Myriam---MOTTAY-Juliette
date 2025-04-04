using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class Station
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public List<string> Lignes {
        get; set; } = new List<string>();
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}