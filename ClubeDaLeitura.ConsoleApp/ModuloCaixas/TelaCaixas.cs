using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class TelaCaixas : TelaBase
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioRevista repositorioRevista;
    public TelaCaixas(
    string nomeEntidade,
    RepositorioCaixa repositorioCaixa,
    RepositorioRevista repositorioRevista) : base(nomeEntidade, repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioRevista = repositorioRevista;
    }

    public override void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Exclusão de Caixa");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Qual Id do registro que deseja excluir? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Caixa caixa = (Caixa)repositorioCaixa.SelecionarPorId(idSelecionado);

        bool testeCaixa = repositorioRevista.CaixaComRevistas(caixa);

        if (testeCaixa == true)
        {
            Console.WriteLine("A caixa que você selecionou tem uma revista dentro, não é possivel excluir!");
            return;
        }
        repositorioCaixa.Excluir(idSelecionado);

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

        bool etiquetaRepetida = repositorioCaixa.EtiquetasDuplicadas(etiqueta);

        if (etiquetaRepetida == true)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Já existe uma caixa com este nome de etiqueta!");
            Console.WriteLine("Digite ENTER para voltar...");
            Console.ReadLine();
            return null;
        }

        Console.Write("Digite o nome da cor da caixa: ");
        string? cor = Console.ReadLine();

        Console.Write("Informe o tempo de empréstimo das revistas da caixa: ");
        int diasDoEmprestimo = int.Parse(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDoEmprestimo);

        return novaCaixa;
    }


}
