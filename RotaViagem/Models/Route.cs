using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaViagem.Models
{
  /// <summary>
  /// Representa uma rota entre dois pontos com um custo associado.
  /// </summary>
  public class Route
  {
    /// <summary>
    /// Origem da rota (ex.: código ou nome de uma cidade, aeroporto, etc.).
    /// </summary>
    public string Origin { get; set; }

    /// <summary>
    /// Destino da rota (ex.: código ou nome de uma cidade, aeroporto, etc.).
    /// </summary>
    public string Destination { get; set; }

    /// <summary>
    /// Custo da rota (ex.: valor monetário, distância, ou qualquer métrica relevante).
    /// </summary>
    public int Cost { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe Route com os valores fornecidos.
    /// </summary>
    /// <param name="origin">O ponto de origem da rota.</param>
    /// <param name="destination">O ponto de destino da rota.</param>
    /// <param name="cost">O custo associado à rota.</param>
    public Route(string origin, string destination, int cost)
    {
      // Define a origem da rota.
      Origin = origin;

      // Define o destino da rota.
      Destination = destination;

      // Define o custo da rota.
      Cost = cost;
    }
  }
}
