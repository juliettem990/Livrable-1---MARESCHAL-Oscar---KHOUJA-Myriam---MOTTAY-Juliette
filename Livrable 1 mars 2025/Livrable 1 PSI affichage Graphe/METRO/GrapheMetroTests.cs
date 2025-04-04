using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class GrapheMetroTests
{
    [TestMethod]
    public void TestCheminExiste()
    {
        // Arrange
        var graphe = new GrapheMetro();
        graphe.ChargerDonnees();

        // Act
        List<Station> chemin = graphe.Dijkstra(1, 5); // Exemple d’ID à adapter

        // Assert
        Assert.IsNotNull(chemin, "Le chemin ne doit pas être null");
        Assert.IsTrue(chemin.Count > 1, "Le chemin doit contenir plusieurs stations");
        Assert.AreEqual(1, chemin[0].Id, "Le chemin doit commencer par la station de départ");
        Assert.AreEqual(5, chemin[chemin.Count - 1].Id, "Le chemin doit se terminer par la station d’arrivée");
    }

    [TestMethod]
    public void TestCheminInexistant()
    {
        // Arrange
        var graphe = new GrapheMetro();
        graphe.ChargerDonnees();

        // Act
        List<Station> chemin = graphe.Dijkstra(9999, 8888); // ID invalides

        // Assert
        Assert.IsNull(chemin, "Le chemin doit être null si les stations n'existent pas");
    }
}
