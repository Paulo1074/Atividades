using System;
using System.Collections.Generic;
using System.Linq;

class Aluno
{
    public string RA { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
}

class Program
{
    static List<Aluno> alunos = new List<Aluno>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Cadastrar aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Alterar aluno");
            Console.WriteLine("4 - Remover aluno");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarAluno();
                    break;
                case "2":
                    ListarAlunos();
                    break;
                case "3":
                    AlterarAluno();
                    break;
                case "4":
                    RemoverAluno();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CadastrarAluno()
    {
        Console.Write("RA: ");
        string ra = Console.ReadLine();
        if (alunos.Any(a => a.RA == ra))
        {
            Console.WriteLine("RA já cadastrado.");
            return;
        }
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Idade: ");
        if (!int.TryParse(Console.ReadLine(), out int idade))
        {
            Console.WriteLine("Idade inválida.");
            return;
        }
        alunos.Add(new Aluno { RA = ra, Nome = nome, Idade = idade });
        Console.WriteLine("Aluno cadastrado com sucesso.");
    }

    static void ListarAlunos()
    {
        if (alunos.Count == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado.");
            return;
        }
        foreach (var aluno in alunos)
        {
            Console.WriteLine($"RA: {aluno.RA}, Nome: {aluno.Nome}, Idade: {aluno.Idade}");
        }
    }

    static void AlterarAluno()
    {
        Console.Write("Informe o RA do aluno a ser alterado: ");
        string ra = Console.ReadLine();
        var aluno = alunos.FirstOrDefault(a => a.RA == ra);
        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado.");
            return;
        }
        Console.Write("Novo nome: ");
        aluno.Nome = Console.ReadLine();
        Console.Write("Nova idade: ");
        if (!int.TryParse(Console.ReadLine(), out int idade))
        {
            Console.WriteLine("Idade inválida.");
            return;
        }
        aluno.Idade = idade;
        Console.WriteLine("Dados alterados com sucesso.");
    }

    static void RemoverAluno()
    {
        Console.Write("Informe o RA do aluno a ser removido: ");
        string ra = Console.ReadLine();
        var aluno = alunos.FirstOrDefault(a => a.RA == ra);
        if (aluno == null)
        {
            Console.WriteLine("Aluno não encontrado.");
            return;
        }
        alunos.Remove(aluno);
        Console.WriteLine("Aluno removido com sucesso.");
    }
}
