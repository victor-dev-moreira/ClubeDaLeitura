using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : TelaBase
{
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioRevista repositorioRevista;

    public TelaEmprestimo(string nomeEntidade,
    RepositorioEmprestimo repositorioEmprestimo,
    RepositorioAmigo repositorioAmigo,
    RepositorioRevista repositorioRevista) : base(nomeEntidade, repositorioEmprestimo)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }

    public override void Visualizar(bool deveExibirCabecalho)
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

    protected override Emprestimo ObterDadosCadastrais()
    {
        EntidadeBase[] selecionarAmigo = repositorioAmigo.SelecionarTodos();

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

        Console.Write("Qual Id do amigo? ");
        int idSelecionadoAmigo = int.Parse(Console.ReadLine());

        Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idSelecionadoAmigo);

        EntidadeBase[] selecionarRevista = repositorioRevista.SelecionarTodos();
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -10} | {3, -25} | {4, -20} | {5, -15}",
            "Id", "Etiqueta", "Edicão", "Ano de publicacão", "Caixa", "Status"
        );

        EntidadeBase[] registrosRevista = repositorioRevista.SelecionarTodos();

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

        Console.Write("Qual Id da revista? ");
        int idSelecionadoRevista = int.Parse(Console.ReadLine());

        Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idSelecionadoRevista);

        Console.WriteLine("---------------------------------");

        return new Emprestimo(amigoSelecionado, revistaSelecionada);
    }
}
