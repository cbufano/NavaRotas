
using RotaViagem.Models;
using RotaViagem.Persistence;
using RotaViagem.Services;


using System;
using System.Collections.Generic;

class Program
{
  static void Main(string[] args)
  {
    var filePath = "routes.txt";
    var persistence = new FilePersistence(filePath);
    var graph = new Graph();
    var routeService = new RouteService(graph);

    // Carregar rotas iniciais
    Console.WriteLine("Carregando rotas salvas...");
    var routes = persistence.LoadRoutes();
    foreach (var route in routes)
    {
      routeService.AddRoute(route.Origin, route.Destination, route.Cost);
    }
    Console.WriteLine($"Rotas carregadas: {routes.Count}\n");

    while (true)
    {
      // Exibir menu principal
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
          AddRoute(routeService, persistence);
          break;

        case "2":
          FindCheapestRoute(routeService);
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
  /// Permite ao usuário adicionar uma nova rota.
  /// </summary>
  static void AddRoute(RouteService routeService, FilePersistence persistence)
  {
    Console.WriteLine("\n=== Adicionar uma Nova Rota ===");
    Console.Write("Informe a origem: ");
    var origin = Console.ReadLine();

    Console.Write("Informe o destino: ");
    var destination = Console.ReadLine();

    int cost;
    while (true)
    {
      Console.Write("Informe o custo (número inteiro): ");
      var costInput = Console.ReadLine();
      if (int.TryParse(costInput, out cost) && cost > 0)
        break;

      Console.WriteLine("Entrada inválida. O custo deve ser um número inteiro positivo.");
    }

    routeService.AddRoute(origin, destination, cost);
    persistence.SaveRoute(new Route(origin, destination, cost));

    Console.WriteLine($"Rota adicionada: {origin} -> {destination} com custo ${cost}\n");
  }

  /// <summary>
  /// Permite ao usuário encontrar a rota mais barata entre dois pontos.
  /// </summary>
  static void FindCheapestRoute(RouteService routeService)
  {
    Console.WriteLine("\n=== Encontrar a Rota Mais Barata ===");
    Console.Write("Informe a origem: ");
    var origin = Console.ReadLine();

    Console.Write("Informe o destino: ");
    var destination = Console.ReadLine();

    var (path, cost) = routeService.GetCheapestRoute(origin, destination);

    if (path.Count > 0)
    {
      Console.WriteLine($"\nMelhor Rota: {string.Join(" - ", path)} com custo de ${cost}\n");
    }
    else
    {
      Console.WriteLine("\nNenhuma rota encontrada entre os pontos fornecidos.\n");
    }
  }
}

