using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Entidade;

namespace Operacoes
{
    public class OperacoesMenu
    {
        private IRepositorio _IRepositorio;
        public OperacoesMenu(IRepositorio repositorio)
        {
            _IRepositorio = repositorio;
        }

        public void SalvarPessoa()
        {
            Console.Clear();
            Console.WriteLine("Escreva o nome da Pessoa");
            string nome = Console.ReadLine();

            Console.WriteLine($"Escreva o ID do(a) {nome}");
            string ID = Console.ReadLine();

            Console.WriteLine($"{nome} ja é Cliente do consultorio?");
            Console.WriteLine("1-Sim");
            Console.WriteLine("2-Não");
            bool clienteAtivo = false;
            string ativo;
            do
            {
                ativo = Console.ReadLine();
                switch (ativo)
                {
                    case "1":
                        clienteAtivo = true;
                        break;
                    case "2":
                        clienteAtivo = false;
                        break;
                    default:
                        Console.WriteLine("Resposta Inválida, escreva novamente:");
                        break;
                }
            } while (ativo != "1" && ativo != "2");

            Console.WriteLine($"Escreva a data de Nascimento do(a) {nome}");
            string data = Console.ReadLine();
            string[] split = data.Split("/");
            DateTime dataNascimento = new DateTime(Int32.Parse(split[2]), Int32.Parse(split[1]), Int32.Parse(split[0]));

            Console.WriteLine($"Escreva o peso do(a) {nome}");
            double peso = double.Parse(Console.ReadLine());

            Console.WriteLine($"Escreva a altura do(a) {nome}");
            double altura = double.Parse(Console.ReadLine());

            Pessoa pessoa = new Pessoa(ID, nome, peso, altura, clienteAtivo, dataNascimento);
            pessoa.CalcularIdade(dataNascimento);

            _IRepositorio.Salvar(pessoa);
            Console.Clear();
            Console.WriteLine("Cliente Adicionado com Sucesso!");
            Console.WriteLine();
        }

        public void MostrarLista()
        {
            Console.Clear();
            foreach (string pessoa in _IRepositorio.Listar())
            {
                Console.WriteLine(pessoa);

            }
            Console.WriteLine();

        }
        public void PrimeirasEntidades()
        {
            string[] cincoEntidades = new string[5];
            int indiceEntidades = 0;
            foreach (string pessoa in _IRepositorio.Listar())
            {
                if (indiceEntidades < 5)
                {
                    cincoEntidades[indiceEntidades] = pessoa;
                    indiceEntidades++;
                }
            }
            foreach (string pessoa in cincoEntidades)
            {
                Console.WriteLine(pessoa);
            }

        }

        public void PesquisarCLiente()
        {
            Console.Clear();
            Console.WriteLine("Escreva o ID do Cliente que você deseja pesquisar:");
            string pesquisa = Console.ReadLine();
            List<string> pegarClientes = new List<string>();
            foreach (string linha in _IRepositorio.Listar())
            {
                if (linha.Contains(pesquisa))
                {
                    pegarClientes.Add(linha);
                }
            }
            int quantidadeDeClientes = 0;
            List<string> listaTemporaria = new List<string>();
            foreach (string cliente in pegarClientes)
            {
                string[] separar = cliente.Split(',');
                Console.WriteLine(quantidadeDeClientes + " - " + separar[0] + separar[1]);
                quantidadeDeClientes++;
                listaTemporaria.Add(cliente);
            }
            Console.WriteLine("Escolha qual Cliente você deseja ver os dados:");
            string escolha = Console.ReadLine();
            string[] separarVirgula = listaTemporaria[int.Parse(escolha)].Split(',');

            Console.WriteLine();
            Console.WriteLine("Aqui estão os dados do Cliente:");
            Console.WriteLine();
            foreach (string elemento in separarVirgula)
            {
                Console.WriteLine(elemento);
            }
            Console.WriteLine();
        }
        public void AlterarDadosCliente()
        {
            Console.Clear();
            Console.WriteLine("Escreva o ID do Cliente que você deseja pesquisar:");
            string id = Console.ReadLine();
            List<string> pegarClientes = new List<string>();
            foreach (string linha in _IRepositorio.Listar())
            {
                if (linha.Contains(id))
                {
                    pegarClientes.Add(linha);
                }
            }
            int quantidadeDeClientes = 0;
            List<string> listaTemporaria = new List<string>();
            foreach (string cliente in pegarClientes)
            {
                string[] separar = cliente.Split(',');
                Console.WriteLine(quantidadeDeClientes + " - " + separar[0] + separar[1]);
                quantidadeDeClientes++;
                listaTemporaria.Add(cliente);
            }
            Console.WriteLine("Escolha qual Cliente você deseja alterar os dados:");
            int escolha = int.Parse(Console.ReadLine());
            _IRepositorio.Atualizar(listaTemporaria[escolha]);

            Console.WriteLine("Dados do Cliente alterados com Sucesso!");
            Console.WriteLine();
        }
        public void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("Escreva o ID do Cliente que você deseja excluir:");
            string id = Console.ReadLine();
            List<string> pegarClientes = new List<string>();
            foreach (string linha in _IRepositorio.Listar())
            {
                if (linha.Contains(id))
                {
                    pegarClientes.Add(linha);
                }
            }
            int quantidadeDeClientes = 0;
            List<string> listaTemporaria = new List<string>();
            foreach (string cliente in pegarClientes)
            {
                string[] separar = cliente.Split(',');
                Console.WriteLine(quantidadeDeClientes + " - " + separar[0] + separar[1]);
                quantidadeDeClientes++;
                listaTemporaria.Add(cliente);
            }
            Console.WriteLine("Escolha qual Cliente você deseja excluir:");
            int escolha = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Você deseja excluir esse cliente?");
            Console.WriteLine();
            string[] separarDados = listaTemporaria[escolha].Split(',');
            foreach (string dado in separarDados)
            {
                Console.WriteLine(dado);
            }
            Console.WriteLine();
            Console.WriteLine("1-Sim");
            Console.WriteLine("2-Não");
            string excluir;
            do
            {
                excluir = Console.ReadLine();
                switch (excluir)
                {
                    case "1":
                        _IRepositorio.Excluir(listaTemporaria[escolha]);
                        Console.WriteLine("Dados do cliente excluidos com sucesso!");
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("Você escolheu não Excluir os Dados do cliente");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Resposta Inválida, escreva novamente:");
                        Console.WriteLine();
                        break;
                }
            } while (excluir != "1" && excluir != "2");
        }
    }
}

