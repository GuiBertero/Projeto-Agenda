using System;
using Agenda.Models;

namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Contatos contatos = new Contatos();

            int opcao = -1;

            while (opcao != 0)
            {
                Console.Clear();

                Console.WriteLine("========== AGENDA ==========");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar contato");
                Console.WriteLine("2 - Pesquisar contato");
                Console.WriteLine("3 - Alterar contato");
                Console.WriteLine("4 - Remover contato");
                Console.WriteLine("5 - Listar contatos");
                Console.WriteLine("============================");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;

                    case 1:
                        adicionarContato(contatos);
                        break;

                    case 2:
                        pesquisarContato(contatos);
                        break;

                    case 3:
                        alterarContato(contatos);
                        break;

                    case 4:
                        removerContato(contatos);
                        break;

                    case 5:
                        listarContatos(contatos);
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        static void adicionarContato(Contatos contatos)
        {
            Console.WriteLine("===== ADICIONAR CONTATO =====");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("E-mail: ");
            string email = Console.ReadLine();

            Console.Write("Dia de nascimento: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Mês de nascimento: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Ano de nascimento: ");
            int ano = int.Parse(Console.ReadLine());

            Data data = new Data(dia, mes, ano);

            Contato contato = new Contato(email, nome, data);

            Console.Write("Tipo do telefone: ");
            string tipo = Console.ReadLine();

            Console.Write("Número do telefone: ");
            string numero = Console.ReadLine();

            Console.Write("É o telefone principal? (s/n): ");
            string principal = Console.ReadLine();

            bool ehPrincipal = principal.ToLower() == "s";

            Telefone telefone = new Telefone(
                tipo,
                numero,
                ehPrincipal
            );

            contato.adicionarTelefone(telefone);

            if (contatos.adicionar(contato))
            {
                Console.WriteLine("Contato adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Já existe um contato com esse e-mail.");
            }
        }

        static void pesquisarContato(Contatos contatos)
        {
            Console.WriteLine("===== PESQUISAR CONTATO =====");

            Console.Write("Digite o e-mail: ");
            string email = Console.ReadLine();

            Contato contato = new Contato();
            contato.setEmail(email);

            Contato encontrado = contatos.pesquisar(contato);

            if (encontrado != null)
            {
                Console.WriteLine();
                Console.WriteLine(encontrado);
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void alterarContato(Contatos contatos)
        {
            Console.WriteLine("===== ALTERAR CONTATO =====");

            Console.Write("Digite o e-mail do contato: ");
            string email = Console.ReadLine();

            Contato contato = new Contato();
            contato.setEmail(email);

            Contato encontrado = contatos.pesquisar(contato);

            if (encontrado == null)
            {
                Console.WriteLine("Contato não encontrado.");
                return;
            }

            Console.Write("Novo nome: ");
            string nome = Console.ReadLine();

            Console.Write("Novo e-mail: ");
            string novoEmail = Console.ReadLine();

            Console.Write("Novo dia de nascimento: ");
            int dia = int.Parse(Console.ReadLine());

            Console.Write("Novo mês de nascimento: ");
            int mes = int.Parse(Console.ReadLine());

            Console.Write("Novo ano de nascimento: ");
            int ano = int.Parse(Console.ReadLine());

            encontrado.setNome(nome);
            encontrado.setEmail(novoEmail);
            encontrado.setDtNasc(new Data(dia, mes, ano));

            Console.WriteLine("Contato alterado com sucesso!");
        }

        static void removerContato(Contatos contatos)
        {
            Console.WriteLine("===== REMOVER CONTATO =====");

            Console.Write("Digite o e-mail do contato: ");
            string email = Console.ReadLine();

            Contato contato = new Contato();
            contato.setEmail(email);

            if (contatos.remover(contato))
            {
                Console.WriteLine("Contato removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Contato não encontrado.");
            }
        }

        static void listarContatos(Contatos contatos)
        {
            Console.WriteLine("===== LISTA DE CONTATOS =====");

            List<Contato> lista = contatos.getAgenda();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine(lista[i]);
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
