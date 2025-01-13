# NavaRotas
Teste de conhecimento em C#

# Documentação do Projeto

## Como Executar a Aplicação

### Pré-requisitos
- Instale o [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior).
- Um editor de código, como [Visual Studio Code](https://code.visualstudio.com/).

### Passos para Executar
1. Clone o repositório ou copie os arquivos para o diretório desejado.
2. No terminal, navegue até a pasta raiz do projeto:
   ```bash
   cd caminho/para/sua/solucao
   ```
3. Compile o projeto:
   ```bash
   dotnet build
   ```
4. Execute o projeto principal:
   ```bash
   dotnet run --project RotaViagem
   ```
5. Para rodar os testes:
   ```bash
   dotnet test
   ```

---

## Estrutura dos Arquivos/Pacotes

```
Solução/
├── NomeDaSolucao.sln         # Arquivo de solução do .NET
├── RotaViagem/               # Projeto principal
│   ├── RotaViagem.csproj     # Arquivo do projeto principal
│   ├── Program.cs            # Ponto de entrada da aplicação
│   ├── Models/               # Modelos de domínio
│   │   ├── Route.cs          # Classe representando uma rota
│   │   ├── Graph.cs          # Classe representando o grafo de rotas
│   ├── Services/             # Serviços
│   │   ├── RouteService.cs   # Lógica para manipular rotas
│   ├── Persistence/          # Persistência de dados
│   │   ├── FilePersistence.cs # Leitura e escrita em arquivos
│   ├── routes.txt            # Arquivo de entrada com rotas iniciais
├── RotaViagem.Tests/         # Projeto de testes
│   ├── RotaViagem.Tests.csproj # Arquivo do projeto de testes
│   ├── GraphTests.cs         # Testes unitários para a classe Graph
```

---

## Decisões de Design

### 1. **Separação de Responsabilidades**
   - **Models:** Contém as classes que representam o domínio do problema, como `Route` (uma rota individual) e `Graph` (o conjunto de rotas).
   - **Services:** Contém a lógica de negócios, encapsulada no `RouteService`, para registrar e consultar rotas.
   - **Persistence:** Gerencia a leitura e gravação de rotas em um arquivo texto para garantir persistência entre execuções.

### 2. **Algoritmo Personalizado para Busca de Rotas**
   - Foi utilizado um algoritmo baseado em busca em profundidade (DFS), garantindo que o custo total seja calculado sem utilizar bibliotecas ou algoritmos externos, como Dijkstra.
   - Permite flexibilidade para adicionar novas funcionalidades, como penalidades por conexões.

### 3. **Testes Unitários**
   - Testes foram criados para validar as funcionalidades principais da aplicação, como adicionar rotas e encontrar o caminho mais barato.
   - Usamos `xUnit` para garantir cobertura e clareza nos resultados.

### 4. **Interface Simples e Intuitiva**
   - A interação com o usuário é feita pelo terminal, oferecendo um menu para adicionar rotas ou consultar a mais barata.

### 5. **Persistência em Arquivo Texto**
   - As rotas são armazenadas em `routes.txt`, facilitando o carregamento de dados entre execuções sem depender de um banco de dados.

### 6. **Modularidade e Manutenção**
   - A aplicação foi estruturada para permitir a expansão futura, como a adição de novos métodos de busca ou diferentes fontes de persistência.

---

### Considerações Finais
Essa solução foi projetada para ser funcional, escalável e seguir boas práticas de desenvolvimento. A separação em camadas, uso de testes unitários e uma interface simples garantem que o código seja fácil de entender e manter. Se precisar de ajustes ou melhorias, a modularidade facilita a evolução do sistema.

