using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Atividades
{
    public class Produto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"Descrição: {Descricao}, Valor: {Valor.ToString("C", CultureInfo.CurrentCulture)}";
        }
    }

    class Program
    {
        static List<Produto> produtos = new();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu de Produtos:");
                Console.WriteLine("1 - Cadastrar produto");
                Console.WriteLine("2 - Remover produto");
                Console.WriteLine("3 - Pesquisar produto");
                Console.WriteLine("4 - Mostrar produto com menor valor");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarProduto();
                        break;
                    case "2":
                        RemoverProduto();
                        break;
                    case "3":
                        PesquisarProduto();
                        break;
                    case "4":
                        MostrarProdutoMenorValor();
                        break;
                    case "5":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void CadastrarProduto()
        {
            Console.Write("Informe a descrição do produto: ");
            var descricao = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("Descrição não pode ser vazia.");
                return;
            }

            Console.Write("Informe o valor do produto: ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.CurrentCulture, out var valor) || valor < 0)
            {
                Console.WriteLine("Valor inválido.");
                return;
            }

            produtos.Add(new Produto { Descricao = descricao, Valor = valor });
            Console.WriteLine("Produto cadastrado com sucesso.");
        }

        static void RemoverProduto()
        {
            Console.Write("Informe a descrição do produto a remover: ");
            var descricao = Console.ReadLine();
            var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }
            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso.");
        }

        static void PesquisarProduto()
        {
            Console.Write("Informe a descrição do produto a pesquisar: ");
            var descricao = Console.ReadLine();
            var produto = produtos.FirstOrDefault(p => p.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }
            Console.WriteLine("Produto encontrado:");
            Console.WriteLine(produto);
        }

        static void MostrarProdutoMenorValor()
        {
            if (!produtos.Any())
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }
            var menor = produtos.MinBy(p => p.Valor);
            Console.WriteLine("Produto com menor valor:");
            Console.WriteLine(menor);
        }
    }
}
