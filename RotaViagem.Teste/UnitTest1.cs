using RotaViagem.Models;

namespace RotaViagem.Teste
{
  public class UnitTest1
  {
    [Fact]
    public void AddRoute_ShouldAddRouteToGraph()
    {
      // Arrange
      var graph = new Graph();

      // Act
      graph.AddRoute("A", "B", 10);

      // Assert
      var (path, cost) = graph.FindCheapestRoute("A", "B");
      Assert.Equal(new List<string> { "A", "B" }, path);
      Assert.Equal(10, cost);
    }

    [Fact]
    public void FindCheapestRoute_ShouldReturnCheapestPath()
    {
      // Arrange
      var graph = new Graph();
      graph.AddRoute("A", "B", 10);
      graph.AddRoute("B", "C", 5);
      graph.AddRoute("A", "C", 20);

      // Act
      var (path, cost) = graph.FindCheapestRoute("A", "C");

      // Assert
      Assert.Equal(new List<string> { "A", "B", "C" }, path);
      Assert.Equal(15, cost);
    }
    [Fact]
    public void FindCheapestRoute_ShouldReturnEmptyIfNoPathExists()
    {
      // Arrange
      var graph = new Graph();
      graph.AddRoute("A", "B", 10);

      // Act
      var (path, cost) = graph.FindCheapestRoute("B", "C");

      // Assert
      Assert.Empty(path);
      Assert.Equal(int.MaxValue, cost);
    }



  }
}