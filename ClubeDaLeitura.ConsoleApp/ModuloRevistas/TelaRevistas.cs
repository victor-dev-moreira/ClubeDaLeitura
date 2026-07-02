using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class TelaRevistas : TelaBase, ITelaOpcoes
{
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    public TelaRevistas(
        string nomeEntidade,
        RepositorioCaixa repositorioCaixa,
        RepositorioRevista repositorioRevista,
        RepositorioEmprestimo repositorioEmprestimo) : base(nomeEntidade, repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioEmprestimo = repositorioEmprestimo;
    }

    public override void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Exclusão de Revista");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Qual Id do registro que deseja excluir? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Revista revista = (Revista)repositorioRevista.SelecionarPorId(idSelecionado);

        bool revistaTeste = repositorioEmprestimo.RevistaEmprestimo(revista);

        if (revistaTeste == true)
        {
            Console.WriteLine("Não foi possivel criar a revista pois ela esta emprestada!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
            return;
        }

        repositorioRevista.Excluir(idSelecionado);
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro de ID \"{idSelecionado}\" foi excluído com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    public override void Visualizar(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Revistas");
            Console.WriteLine("---------------------------------");
        }

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
            r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status.ToString()
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
        }
    }
    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Qual titulo da Revista? ");
        string titulo = Console.ReadLine();

        if (titulo.Length < 2 || titulo.Length > 100)
        {
            Console.WriteLine("O titulo passou de 100 caracteres ou é menor que dois caracteres, não foi possivel criar a revista!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
            return null;
        }

        Console.Write("Qual numero de edicão? ");
        int numeroEdicao = int.Parse(Console.ReadLine());

        if (numeroEdicao <= 0)
        {
            Console.WriteLine("Não é possivel criar com uma edicão menor que zero!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
            return null;
        }

        bool tituloEdicaoRepetido = repositorioRevista.TituloEdicaoRepetido(titulo, numeroEdicao);

        if (tituloEdicaoRepetido == true)
        {
            Console.WriteLine("Não foi possivel criar a revista pois a edicão ou titulo ja existe!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
            return null;
        }

        Console.Write("Qual o ano de publicacão? ");
        int anoPublicacao = int.Parse(Console.ReadLine());

        if (anoPublicacao < 1000 || anoPublicacao > 2026)
        {
            Console.WriteLine("Não é possivel criar com ano de publicacão for menor que 1000 ou maior que 2026!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
            return null;
        }

        Console.WriteLine("---------------------------------");

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20} | {4, -15}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        EntidadeBase[] registros = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = (Caixa)registros[i];

            if (c == null)
                continue;

            Console.WriteLine(
             "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
             c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
            );
        }
        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Caixa? caixaSelecionada = (Caixa)repositorioCaixa.SelecionarPorId(idSelecionado);

        return new Revista(titulo, numeroEdicao, anoPublicacao, caixaSelecionada);
    }

}
