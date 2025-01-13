using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaViagem.Models
{

  /// <summary>
  /// Representa um grafo de rotas com funcionalidades para adicionar rotas e encontrar o caminho mais barato entre dois pontos.
  /// </summary>
  public class Graph
  {
    // Dicionário que mapeia um ponto de origem para uma lista de rotas disponíveis a partir dele.
    private readonly Dictionary<string, List<Route>> _routes;
    
    /// <summary>
    /// Inicializa uma nova instância da classe Graph.
    /// </summary>
    public Graph()
    {
      _routes = new Dictionary<string, List<Route>>();
    }

    /// <summary>
    /// Adiciona uma rota ao grafo.
    /// </summary>
    /// <param name="origin">Ponto de origem da rota.</param>
    /// <param name="destination">Ponto de destino da rota.</param>
    /// <param name="cost">Custo da rota.</param>
    public void AddRoute(string origin, string destination, int cost)
    {
      if (!_routes.ContainsKey(origin))
        _routes[origin] = new List<Route>();

      _routes[origin].Add(new Route(origin, destination, cost));
    }

    /// <summary>
    /// Encontra o caminho mais barato entre dois pontos no grafo.
    /// </summary>
    /// <param name="start">Ponto inicial da busca.</param>
    /// <param name="end">Ponto final da busca.</param>
    /// <returns>
    /// Uma tupla contendo a lista de pontos que compõem o caminho mais barato
    /// e o custo total desse caminho.
    /// </returns>
    public (List<string> path, int cost) FindCheapestRoute(string start, string end)
    {
      // Conjunto para rastrear os pontos já visitados durante a busca.
      var visited = new HashSet<string>();

      // Lista para rastrear o caminho atual durante a busca.
      var path = new List<string>();

      // Lista que armazenará o melhor caminho encontrado.
      var result = new List<string>();

      // Inicializa o custo mínimo como um valor muito alto.
      int minCost = int.MaxValue;

      // Função local para realizar a busca em profundidade (DFS).
      void DFS(string current, int currentCost)
      {
        // Caso base: se o ponto atual for o destino.
        if (current == end)
        {
          // Atualiza o custo mínimo e o melhor caminho se o custo atual for menor.
          if (currentCost < minCost)
          {
            minCost = currentCost;
            result = new List<string>(path);
          }
          return;
        }
        // Marca o ponto atual como visitado.
        visited.Add(current);

        // Verifica se há rotas disponíveis a partir do ponto atual.
        if (_routes.ContainsKey(current))
        {
          foreach (var route in _routes[current])
          {
            // Só visita os pontos que ainda não foram visitados.
            if (!visited.Contains(route.Destination))
            {
              // Adiciona o destino ao caminho atual.
              path.Add(route.Destination);

              // Chama a função recursivamente para explorar o próximo ponto.
              DFS(route.Destination, currentCost + route.Cost);

              // Remove o destino da lista após retornar da chamada recursiva (backtracking).
              path.RemoveAt(path.Count - 1);
            }
          }
        }
        // Desmarca o ponto atual como visitado para permitir outros caminhos.
        visited.Remove(current);
      }
      // Inicializa a busca adicionando o ponto inicial ao caminho.
      path.Add(start);
      // Inicia a busca em profundidade a partir do ponto inicial.
      DFS(start, 0);

      // Retorna o melhor caminho encontrado e seu custo.
      return (result, minCost);
    }
  }
}
