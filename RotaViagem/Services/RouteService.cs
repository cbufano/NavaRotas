using RotaViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaViagem.Services
{
  /// <summary>
  /// Serviço responsável por gerenciar a lógica de negócios relacionada às rotas.
  /// Atua como uma camada intermediária entre a interface do usuário e o grafo de rotas.
  /// </summary>
  public class RouteService
  {
    /// <summary>
    /// Instância do grafo que armazena as rotas e permite realizar operações como adicionar e buscar rotas.
    /// </summary>
    private readonly Graph _graph;

    /// <summary>
    /// Inicializa uma nova instância do serviço de rotas com o grafo fornecido.
    /// </summary>
    /// <param name="graph">Instância do grafo onde as rotas serão gerenciadas.</param>
    public RouteService(Graph graph)
    {
      // Atribui o grafo fornecido à propriedade privada para uso nos métodos do serviço.
      _graph = graph;
    }

    /// <summary>
    /// Adiciona uma nova rota ao grafo.
    /// </summary>
    /// <param name="origin">Ponto de origem da rota.</param>
    /// <param name="destination">Ponto de destino da rota.</param>
    /// <param name="cost">Custo associado à rota.</param>
    public void AddRoute(string origin, string destination, int cost)
    {
      // Encapsula a lógica de adicionar uma rota, delegando ao grafo.
      _graph.AddRoute(origin, destination, cost);
    }

    /// <summary>
    /// Obtém o caminho mais barato entre dois pontos no grafo.
    /// </summary>
    /// <param name="origin">Ponto inicial da busca.</param>
    /// <param name="destination">Ponto final da busca.</param>
    /// <returns>
    /// Uma tupla contendo:
    /// - Uma lista de strings representando o caminho mais barato.
    /// - O custo total do caminho.
    /// </returns>
    public (List<string> path, int cost) GetCheapestRoute(string origin, string destination)
    {
      // Encapsula a lógica de busca pelo caminho mais barato, delegando ao grafo.
      return _graph.FindCheapestRoute(origin, destination);
    }
  }

}
