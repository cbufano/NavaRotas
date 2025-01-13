using RotaViagem.Models;
using RotaViagem.Persistence;
using RotaViagem.Services;

class Program
{
  static void Main(string[] args)
  {
    var filePath = "routes.txt";
    var persistence = new FilePersistence(filePath);
    var graph = new Graph();
    var routeService = new RouteService(graph);

    // Carregar rotas salvas
    var routes = persistence.LoadRoutes();
    foreach (var route in routes)
    {
      routeService.AddRoute(route.Origin, route.Destination, route.Cost);
    }

    // Loop principal do menu
    while (true)
    {
      Console.WriteLine("========= Menu Principal =========");
      Console.WriteLine("1. Adicionar uma nova rota");
      Console.WriteLine("2. Encontrar a rota mais barata");
      Console.WriteLine("3. Sair");
      Console.WriteLine("==================================");
      Console.Write("Escolha uma opção: ");
      var choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          HandleAddRoute(routeService, persistence);
          break;

        case "2":
          HandleFindCheapestRoute(routeService);
          break;

        case "3":
          Console.WriteLine("\nObrigado por usar o sistema de rotas. Até mais!");
          return;

        default:
          Console.WriteLine("\nOpção inválida! Por favor, escolha uma das opções do menu.\n");
          break;
      }
    }
  }

  /// <summary>
  /// Lida com a funcionalidade de adicionar uma nova rota.
  /// </summary>
  static void HandleAddRoute(RouteService routeService, FilePersistence persistence)
  {
    Console.WriteLine("\n=== Adicionar uma Nova Rota ===");

    // Solicita origem e destino com a opção de cancelar.
    var origin = GetValidatedInput("Informe a origem (ou digite 'sair' para cancelar): ");
    if (origin == null) return;

    var destination = GetValidatedInput("Informe o destino (ou digite 'sair' para cancelar): ");
    if (destination == null) return;

    // Solicita e valida o custo
    var cost = GetValidatedCost();
    if (cost == null) return;

    // Adiciona a rota e salva na persistência
    routeService.AddRoute(origin.ToUpper(), destination.ToUpper(), cost.Value);
    persistence.SaveRoute(new Route(origin, destination, cost.Value));

    Console.WriteLine($"Rota adicionada: {origin} -> {destination} com custo ${cost}\n");
  }

  /// <summary>
  /// Lida com a funcionalidade de encontrar a rota mais barata.
  /// </summary>
  static void HandleFindCheapestRoute(RouteService routeService)
  {
    Console.WriteLine("\n=== Encontrar a Rota Mais Barata ===");

    // Solicita origem e destino com a opção de cancelar.
    var origin = GetValidatedInput("Informe a origem (ou digite 'sair' para cancelar): ");
    if (origin == null) return;

    var destination = GetValidatedInput("Informe o destino (ou digite 'sair' para cancelar): ");
    if (destination == null) return;

    // Busca e exibe a melhor rota
    var (path, cost) = routeService.GetCheapestRoute(origin.ToUpper(), destination.ToUpper());

    if (path.Count > 0)
    {
      Console.WriteLine($"\nMelhor Rota: {string.Join(" - ", path)} com custo de ${cost}\n");
    }
    else
    {
      Console.WriteLine("\nNenhuma rota encontrada entre os pontos fornecidos.\n");
    }
  }

  /// <summary>
  /// Solicita uma entrada do usuário com validação e opção de cancelar.
  /// </summary>
  static string? GetValidatedInput(string prompt)
  {
    while (true)
    {
      Console.Write(prompt);
      var input = Console.ReadLine();

      if (input?.ToLower() == "sair")
      {
        Console.WriteLine("Operação cancelada.\n");
        return null;
      }

      if (!string.IsNullOrWhiteSpace(input))
        return input;

      Console.WriteLine("Entrada inválida. Por favor, tente novamente.");
    }
  }

  /// <summary>
  /// Solicita um custo válido ao usuário com a opção de cancelar.
  /// </summary>
  static int? GetValidatedCost()
  {
    while (true)
    {
      Console.Write("Informe o custo (ou digite 'sair' para cancelar): ");
      var input = Console.ReadLine();

      if (input?.ToLower() == "sair")
      {
        Console.WriteLine("Operação cancelada.\n");
        return null;
      }

      if (int.TryParse(input, out var cost) && cost > 0)
        return cost;

      Console.WriteLine("Entrada inválida. O custo deve ser um número inteiro positivo.");
    }
  }
}

