using System;
using System.Net;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {

        static List<Funcionario> lista = new List<Funcionario>();

        static void Main(string[] args)
        {
            CriarLista();
            int opcao = 0;
            do
            {
                Console.WriteLine("Digite umas das Opcoes Abaixo:");
                Console.WriteLine("1 - Obter por Nome");
                Console.WriteLine("2 - Excluir Id menores que 4 e ordenar por Salário");
                Console.WriteLine("3 - Obter Estatisticas");
                Console.WriteLine("4 - Adicionar novo Funcionário");
                Console.WriteLine("5 - Validar nome");
                Console.WriteLine("6 - Busca por Tipo de Contrato");
                Console.WriteLine("7 - Exibir lista Completa");
                Console.WriteLine("8 - Sair do Sistema\n");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o Nome na Qual quer procurar: ");
                        string nomeDigitado = Console.ReadLine();
                        ObterPorNome(nomeDigitado);
                        break;
                    case 2:
                        ObterFuncionariosRecentes();
                        break;
                    case 3:
                        ObterEstatisticas();
                        break;
                    case 4:
                        ValidarSalarioAdmissao();
                        break;
                    case 5:
                        ValidarNome();
                        break;
                    case 6:
                        ObterPorTipo();
                        break;
                    case 7:
                        ExibirLista();
                        break;  
                    default:
                        Console.WriteLine("\nSaindo do Sistema !!!!!!!!!!! Muito obrigado\n");
                        break;
                }
            }
            while (opcao >= 1 && opcao <= 7);
        }
        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "======================================\n";
                dados += string.Format("Id: {0}\n", lista[i].Id);
                dados += string.Format("Nome: {0}\n", lista[i].Nome);
                dados += string.Format("CPF: {0}\n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy}\n", lista[i].DataAdmissao);
                dados += string.Format("Salario: {0:c2}\n", lista[i].Salario);
                dados += string.Format("Tipo: {0}\n", lista[i].TipoFuncionario);
                dados += "=====================================\n";
            }
            Console.WriteLine(dados);
        }
        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);
            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);
            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);
            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 500.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);
            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);
            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }
        public static void ObterPorNome(string nomeDigitado)
        {
            Funcionario fBusca = lista.Find(x => x.Nome.ToLower().Contains(nomeDigitado));
            if (fBusca != null)
            {
                string dados = "";
                dados += "======================================\n";
                dados += string.Format("Id: {0}\n", fBusca.Id);
                dados += string.Format("Nome: {0}\n", fBusca.Nome);
                dados += string.Format("CPF: {0}\n", fBusca.Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy}\n", fBusca.DataAdmissao);
                dados += string.Format("Salario: {0:c2}\n", fBusca.Salario);
                dados += string.Format("Tipo: {0}\n", fBusca.TipoFuncionario);
                dados += "=====================================\n";
                Console.WriteLine(dados);
            }
            else
                Console.WriteLine("Funcionário Não Encontrado");
        }
        public static void ObterFuncionariosRecentes()
        {
            lista.RemoveAll(x => x.Id < 4);
            lista = lista.OrderBy(x => x.Salario).ToList();
            ExibirLista();
        }
        public static void ObterEstatisticas()
        {
            int qtd = lista.Count();
            decimal somatoria = lista.Sum(x => x.Salario);
            string mensagem = string.Format("Existem {0} Funcionários na Empresa e a Somatória total dos Salários é: {1:c2} Reais \n", qtd, somatoria);
            Console.WriteLine(mensagem);
        }
        public static void ValidarSalarioAdmissao()
        {
            Console.WriteLine("quantidade de funcionário que quer adicionar: \n");
            int escolha = int.Parse(Console.ReadLine());

            for (int i = 0; i < escolha; i++)
            {
                Funcionario func = new Funcionario();
                Console.WriteLine("Digite o ID do funcionário: ");
                func.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o nome do funcionário: ");
                func.Nome = Console.ReadLine();
                Console.WriteLine("Digite o CPF do funcionário: ");
                func.Cpf = Console.ReadLine();
                Console.WriteLine("Digite a Data de Admissão do funcionário: ");
                func.DataAdmissao = DateTime.Parse(Console.ReadLine());
                if (func.DataAdmissao < DateTime.Now)
                {
                    Console.WriteLine("Não Foi possivel adicionar o Funcionário pois Data de Admissçao não pode ser menor que a data Atual\n");
                    continue;
                }
                Console.WriteLine("Digite o Salário do funcionário: ");
                func.Salario = decimal.Parse(Console.ReadLine());
                if (func.Salario <= 0)
                {
                    Console.WriteLine("Não Foi possivel adicionar o Funcionário pois o Salário nao pode ser 0\n");
                    continue;
                }
                Console.WriteLine("Qual é o Tipo de Contrato do Funcionário: 1 - CLT ou 2 - Aprendiz");
                int opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                    func.TipoFuncionario = TipoFuncionarioEnum.CLT;
                else if (opcao == 2)
                    func.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
                else
                {
                    Console.WriteLine("Opção invalida");
                    continue;
                }
                lista.Add(func);
                Console.WriteLine("Funcionário(a) adicionado(a) !!!!!\n\n");
                ExibirLista();

            }

        }

        public static void ValidarNome()
        {
            Funcionario func = new Funcionario();
            Console.WriteLine("Digite o ID do funcionário: ");
            func.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do funcionário: ");
            func.Nome = Console.ReadLine();
            if (func.Nome.Length < 2)
            {
                Console.WriteLine("Nome inválido! O nome deve ter pelo menos 2 caracteres.");
                return;
            }
            Console.WriteLine("Digite o CPF do funcionário: ");
            func.Cpf = Console.ReadLine();
            Console.WriteLine("Digite a Data de Admissão do funcionário: ");
            func.DataAdmissao = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Salário do funcionário: ");
            func.Salario = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Qual é o Tipo de Contrato do Funcionário: 1 - CLT ou 2 - Aprendiz");
            int opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
                func.TipoFuncionario = TipoFuncionarioEnum.CLT;
            else if (opcao == 2)
                func.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            else
                Console.WriteLine("Opção invalida\n");
            lista.Add(func);
            Console.WriteLine("Funcionário(a) adicionado(a) !!!!!\n\n");
            ExibirLista();
        }

        public static void ObterPorTipo()
        {
            Console.WriteLine("Digite a opcao na qual quer pesquisar");
            Console.WriteLine("1 - Para CLT");
            Console.WriteLine("2 - Para Aprendiz");
            int opcao = int.Parse(Console.ReadLine());
            List<Funcionario> resultado;
            if (opcao == 1)
                resultado = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.CLT);
            else if (opcao == 2)
                resultado = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            else
            {
                Console.WriteLine("Opção inválida!");
                return;
            }
            if (resultado.Count > 0)
            {
                string dados = "";
                for (int i = 0; i < resultado.Count; i++)
                {
                    dados += "======================================\n";
                    dados += string.Format("Id: {0}\n", resultado[i].Id);
                    dados += string.Format("Nome: {0}\n", resultado[i].Nome);
                    dados += string.Format("CPF: {0}\n", resultado[i].Cpf);
                    dados += string.Format("Admissão: {0:dd/MM/yyyy}\n", resultado[i].DataAdmissao);
                    dados += string.Format("Salario: {0:c2}\n", resultado[i].Salario);
                    dados += string.Format("Tipo: {0}\n", resultado[i].TipoFuncionario);
                    dados += "=====================================\n";
            }
            Console.WriteLine(dados);
            }
            else
                {
                    Console.WriteLine("Nenhum funcionário encontrado para esse tipo.");
                }
        }

    }
}