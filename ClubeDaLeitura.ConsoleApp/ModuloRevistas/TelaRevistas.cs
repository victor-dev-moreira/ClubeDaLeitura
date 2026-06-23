using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class TelaRevistas : TelaBase
{
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioCaixa repositorioCaixa;
    public TelaRevistas(
        string nomeEntidade,
        RepositorioCaixa repositorioCaixa,
        RepositorioRevista repositorioRevista) : base(nomeEntidade, repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
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
            r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta, r.Status
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

        Console.Write("Qual numero de edicão? ");
        int numeroEdicao = int.Parse(Console.ReadLine());

        Console.Write("Qual o ano de publicacão? ");
        int anoPublicacao = int.Parse(Console.ReadLine());

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
