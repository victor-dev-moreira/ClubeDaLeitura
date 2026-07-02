using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : ITelaOpcoes
{
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioRevista repositorioRevista;
    public TelaEmprestimo(string nomeEntidade,
    RepositorioEmprestimo repositorioEmprestimo,
    RepositorioAmigo repositorioAmigo,
    RepositorioRevista repositorioRevista)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }


    public string ObterMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de Empréstimos");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"1 - Abrir Empréstimo");
        Console.WriteLine($"2 - Concluir Empréstimo");
        Console.WriteLine($"3 - Visualizar Empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuInterno = Console.ReadLine()?.ToUpper();

        return opcaoMenuInterno;
    }

    public void Visualizar(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Emprestimos");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -10} | {3, -25} | {4, -20} | {5, -15}",
            "Id", "Amigo", "Revista", "Data Abertura", "Data Devolucão", "Status"
        );

        EntidadeBase[] registros = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Emprestimo e = (Emprestimo)registros[i];

            if (registros[i] == null)
                continue;

            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -10} | {3, -25} | {4, -20} | {5, -15}",
            e.Id, e.Amigo.NomeAmigo, e.Revista.Titulo, e.DataAbertura, e.DataDevolucaoPrevista, e.Status
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
        }
    }

    public void Abrir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Abertura de Emprestimo");
        Console.WriteLine("---------------------------------");

        VisualizarRevista();

        Console.Write("Qual Id da revista? ");
        int idSelecionadoRevista = int.Parse(Console.ReadLine());
        Console.WriteLine("---------------------------------");

        VisualizarAmigo();

        Console.Write("Qual Id do amigo? ");
        int idSelecionadoAmigo = int.Parse(Console.ReadLine());
        Console.WriteLine("---------------------------------");

        Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idSelecionadoAmigo);
        Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idSelecionadoRevista);

        Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);

        repositorioEmprestimo.Cadastrar(novoEmprestimo);

    }

    public void Concluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Conclusão de Emprestimo");
        Console.WriteLine("---------------------------------");

        Visualizar(false);
        Console.WriteLine("---------------------------------");

        Console.Write("Qual ID do emprestimo que deseja concluir? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Emprestimo emprestimo = (Emprestimo)repositorioEmprestimo.SelecionarPorId(idSelecionado);

        emprestimo.Status = StatusEmprestimos.Concluido;

        repositorioEmprestimo.Editar(idSelecionado, emprestimo);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O empréstimo \"{emprestimo.Id}\" foi concluído!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();

    }

    private void VisualizarAmigo()
    {
        Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
                "Id", "Nome Amigo", "Nome Responsavel", "Telefone"
            );
        EntidadeBase[] registros = repositorioAmigo.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Amigo a = (Amigo)registros[i];

            if (a == null)
                continue;

            Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -20} | {3, -20}",
            a.Id, a.NomeAmigo, a.NomeResponsavel, a.Telefone
            );
        }
    }

    private void VisualizarRevista()
    {
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -10} | {3, -25} | {4, -20} | {5, -15}",
            "Id", "Etiqueta", "Edicão", "Ano de publicacão", "Caixa", "Status"
        );

        EntidadeBase[] registros = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Revista r = (Revista)registros[i];

            if (registros[i] == null)
                continue;

            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -10} | {3, -25} | {4, -20} | {5, -15}",
            r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status
            );
        }
    }

}
