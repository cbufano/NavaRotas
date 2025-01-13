using RotaViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaViagem.Persistence
{
  /// <summary>
  /// Gerencia a persistência de rotas em um arquivo de texto.
  /// Permite carregar e salvar rotas entre execuções da aplicação.
  /// </summary>
  public class FilePersistence
  {
    /// <summary>
    /// Caminho do arquivo onde as rotas serão armazenadas.
    /// </summary>
    private readonly string _filePath;

    /// <summary>
    /// Inicializa uma nova instância da classe FilePersistence com o caminho do arquivo fornecido.
    /// </summary>
    /// <param name="filePath">O caminho do arquivo de texto onde as rotas serão armazenadas.</param>
    public FilePersistence(string filePath)
    {
      // Define o caminho do arquivo para persistência.
      _filePath = filePath;
    }

    /// <summary>
    /// Carrega as rotas armazenadas no arquivo especificado.
    /// </summary>
    /// <returns>Uma lista de objetos Route contendo as rotas carregadas.</returns>
    public List<Route> LoadRoutes()
    {
      var routes = new List<Route>();

      // Verifica se o arquivo existe antes de tentar ler.
      if (File.Exists(_filePath))
      {
        // Lê todas as linhas do arquivo.
        var lines = File.ReadAllLines(_filePath);

        // Processa cada linha para criar objetos Route.
        foreach (var line in lines)
        {
          // Divide a linha em partes (Origem, Destino, Custo).
          var parts = line.Split(',');

          // Cria uma nova rota e adiciona à lista.
          routes.Add(new Route(parts[0], parts[1], int.Parse(parts[2])));
        }
      }

      return routes;
    }

    /// <summary>
    /// Salva uma nova rota no arquivo, adicionando-a no final.
    /// </summary>
    /// <param name="route">O objeto Route a ser salvo.</param>
    public void SaveRoute(Route route)
    {
      // Adiciona a nova rota ao arquivo como uma linha formatada.
      File.AppendAllLines(_filePath, new[] { $"{route.Origin},{route.Destination},{route.Cost}" });
    }
  }
}
