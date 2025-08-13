using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial;
decimal precoPorHora;

Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!\n");

// Entrada validada para preço inicial
Console.Write("Digite o preço inicial: ");
while (!decimal.TryParse(Console.ReadLine(), out precoInicial) || precoInicial < 0)
{
    Console.Write("Valor inválido! Digite novamente o preço inicial: ");
}

// Entrada validada para preço por hora
Console.Write("Agora digite o preço por hora: ");
while (!decimal.TryParse(Console.ReadLine(), out precoPorHora) || precoPorHora < 0)
{
    Console.Write("Valor inválido! Digite novamente o preço por hora: ");
}

// Instancia a classe Estacionamento
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

bool exibirMenu = true;

// Loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE ESTACIONAMENTO ===");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.Write("Escolha uma opção: ");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("❌ Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

Console.WriteLine("Programa encerrado. Até logo!");
