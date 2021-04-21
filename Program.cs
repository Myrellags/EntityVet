using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityVet
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = "S";
            while (opcao == "S")
            {
                Console.WriteLine("Seja bem vindo ao PetVet!");
                Console.WriteLine("Informe os dados do dono do Pet:");
                Console.WriteLine("Nome do dono:");
                string nome = Console.ReadLine();
                Console.WriteLine("Telefone:");
                string telefone = Console.ReadLine();
                Console.WriteLine("Endereco:");
                string endereco = Console.ReadLine();
                Console.WriteLine("NIF:");
                string nif = Console.ReadLine();
                Console.WriteLine("Email:");
                string email = Console.ReadLine();

                Pessoa c1 = new Pessoa() { Nome = nome, Telefone = telefone, Endereco = endereco, NIF = nif, Email = email };
                MinhaBD bd = new MinhaBD();
                bd.Pessoas.Add(c1);
                bd.SaveChanges();

                Console.WriteLine("Agora Vamos cadastrar o Pet:");
                Console.WriteLine("Nome do Pet:");
                string nomePet = Console.ReadLine();
                Console.WriteLine("Qual o tipo do seu pet? Exemplo: Gato, Cachorro...");
                string tipoPet = Console.ReadLine();

                Animal a1 = new Animal() { NomePet = nomePet, TipoPet = tipoPet };
                bd.Animais.Add(a1);
                bd.SaveChanges();

                Console.WriteLine("Registros salvos com sucesso! Deseja incluir novos? S ou N");
                string resposta = Console.ReadLine();
                opcao = resposta;
            }
        }
    }
    class MinhaBD : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Animal> Animais { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BDEntityVet;Trusted_Connection=True;");

        }
    }
}
