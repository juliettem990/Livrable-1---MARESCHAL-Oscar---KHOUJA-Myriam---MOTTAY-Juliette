using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class GrapheMetroTests
{
    [TestMethod]
    public void Test_Dijkstra_TrouveCheminSimple()
    {
        // Arrange
        GrapheMetro graphe = new GrapheMetro();

        // Stations fictives
        Station a = new Station { Id = 1, Nom = "A", Latitude = 0, Longitude = 0 };
        Station b = new Station { Id = 2, Nom = "B", Latitude = 0, Longitude = 1 };
        Station c = new Station { Id = 3, Nom = "C", Latitude = 0, Longitude = 2 };

        a.Lignes.Add("1");
        b.Lignes.Add("1");
        c.Lignes.Add("1");

        graphe.Stations.Add(a);
        graphe.Stations.Add(b);
        graphe.Stations.Add(c);

        graphe.Connexions.Add((a, b));
        graphe.Connexions.Add((b, c));

        // Act
        List<Station> chemin = graphe.Dijkstra(1, 3);

        // Assert
        Assert.IsNotNull(chemin);
        Assert.AreEqual(3, chemin.Count);
        Assert.AreEqual("A", chemin[0].Nom);
        Assert.AreEqual("B", chemin[1].Nom);
        Assert.AreEqual("C", chemin[2].Nom);
    }
}
