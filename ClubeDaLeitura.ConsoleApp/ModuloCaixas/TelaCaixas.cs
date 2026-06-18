using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class TelaCaixas : TelaBase
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioRevista repositorioRevista;
    public TelaCaixas(string nomeEntidade,
    RepositorioCaixa repositorioCaixa,
    RepositorioRevista repositorioRevista) : base(nomeEntidade, repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioRevista = repositorioRevista;
    }
    public override void Visualizar(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Caixas");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
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

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da etiqueta da caixa: ");
        string? etiqueta = Console.ReadLine();

        Console.Write("Digite o nome da cor da caixa: ");
        string? cor = Console.ReadLine();

        Console.Write("Informe o tempo de empréstimo das revistas da caixa: ");
        int diasDoEmprestimo = int.Parse(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDoEmprestimo);

        return novaCaixa;
    }

}
