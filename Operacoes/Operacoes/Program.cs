using Repositorio;
using Entidade;

using Operacoes;
public class Program
{
    public static void Main()
    {
        CincoEntidades entidades = new CincoEntidades();

        if (!File.Exists(@"Repositorio.txt"))
        {
            var meuArquivo = File.Create(@"Repositorio.txt");
            meuArquivo.Close();

            File.WriteAllLines(@"Repositorio.txt", entidades.ArrayEntidade());
        }


        IRepositorio repositorio;
        OperacoesMenu menu;
        RepositorioArquivo arquivo = new RepositorioArquivo();
        OperacoesMenu listaArquivo = new OperacoesMenu(arquivo);

        listaArquivo.PrimeirasEntidades();

        Console.WriteLine();
        Console.WriteLine("Escolha se vc quer salvar em arquivo ou lista:");
        Console.WriteLine("1- Arquivo");
        Console.WriteLine("2- Lista");
        string escolha = Console.ReadLine();

        Console.Clear();
        switch (escolha)
        {
            case "1":
                Console.WriteLine("Voce escolheu salvar em Arquivo");
                repositorio = new RepositorioArquivo();
                break;
            case "2":
                Console.WriteLine("Voce escolheu salvar em lista");
                repositorio = new RepositorioLista();
                break;
            default:
                Console.WriteLine("Opçaõ inválida, salvando em lista como padrão");
                repositorio = new RepositorioLista();
                break;
        }
        Console.WriteLine();
        menu = new OperacoesMenu(repositorio);
        string sair = "0";

        do
        {
            Console.WriteLine("Oque você deseja no Consultorio?");
            Console.WriteLine("0-Mostrar Lista");
            Console.WriteLine("1-Adicionar Cliente");
            Console.WriteLine("2-Alterar dados de um Cliente");
            Console.WriteLine("3-Excluir Cliente");
            Console.WriteLine("4-Pesquisar Cliente");
            Console.WriteLine("5-Sair do programa");

            string opcao = Console.ReadLine();

            do
            {
                switch (opcao)
                {
                    case "0":
                        menu.MostrarLista();
                        break;
                    case "1":
                        menu.SalvarPessoa(); break;
                    case "2":
                        menu.AlterarDadosCliente(); break;
                    case "3":
                        menu.ExcluirCliente(); break;
                    case "4":
                        menu.PesquisarCLiente(); break;
                    case "5":
                        Console.WriteLine("Obrigado por usar o programa!");
                        sair = opcao;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, Escreva novamente");
                        break;
                }
            } while (opcao != "0" && opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5");
        } while (sair != "5");

    }
}