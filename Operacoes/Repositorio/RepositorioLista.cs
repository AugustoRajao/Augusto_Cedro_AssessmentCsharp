using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidade;
namespace Repositorio
{
    public class RepositorioLista : IRepositorio
    {
        readonly List<string> clientes;
        public RepositorioLista()
        {
            clientes = new List<string>();
        }

        public void Atualizar(string cliente)
        {
            string[] lista = Listar();
            foreach (string elemento in lista)
            {
                if (cliente == elemento)
                {
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
                    Excluir(elemento);
                    Salvar(pessoa);
                }
            }
        }

        public void Excluir(string cliente)
        {
            string[] lista = Listar();
            foreach (string elemento in lista)
            {
                if (cliente == elemento)
                {
                    clientes.Remove(elemento);
                }
            }
        }

        public string[] Listar()
        {
            string[] lista = new string[clientes.Count];
            for (int i = 0; i < clientes.Count; i++)
            {
                lista[i] = clientes[i];
            }
            return lista;
        }

        public void Salvar(Pessoa pessoa)
        {
            clientes.Add(pessoa.ToString());
        }
    }

}
