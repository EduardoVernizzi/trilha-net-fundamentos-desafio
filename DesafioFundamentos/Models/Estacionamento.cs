using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método para validar a placa (formato antigo e Mercosul)
        private bool PlacaValida(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            placa = placa.Trim().ToUpper();

            // Formato antigo: ABC-1234 ou ABC1234
            string padraoAntigo = @"^[A-Z]{3}-?\d{4}$";

            // Formato Mercosul: ABC1D23
            string padraoMercosul = @"^[A-Z]{3}\d[A-Z]\d{2}$";

            return Regex.IsMatch(placa, padraoAntigo) || Regex.IsMatch(placa, padraoMercosul);
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim().ToUpper();

            if (!PlacaValida(placa))
            {
                Console.WriteLine("❌ Placa inválida! Use o formato ABC1234, ABC-1234 ou ABC1D23.");
                return;
            }

            if (veiculos.Contains(placa))
            {
                Console.WriteLine($"⚠ O veículo com placa {placa} já está estacionado.");
                return;
            }

            veiculos.Add(placa);
            Console.WriteLine($"✅ Veículo {placa} adicionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()?.Trim().ToUpper();

            if (!PlacaValida(placa))
            {
                Console.WriteLine("❌ Placa inválida! Use o formato ABC1234, ABC-1234 ou ABC1D23.");
                return;
            }

            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (!int.TryParse(Console.ReadLine(), out int horas) || horas < 0)
                {
                    Console.WriteLine("❌ Quantidade de horas inválida! Operação cancelada.");
                    return;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);
                Console.WriteLine($"✅ O veículo {placa} foi removido. Preço total: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("❌ Esse veículo não está estacionado aqui. Confira a placa e tente novamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("📋 Veículos estacionados:");
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("🚫 Não há veículos estacionados.");
            }
        }
    }
}
