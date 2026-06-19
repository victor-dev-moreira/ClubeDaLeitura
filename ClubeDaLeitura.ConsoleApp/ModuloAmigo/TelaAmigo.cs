using ClubeDaLeitura.ConsoleApp.Compartilhado;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase
{
    private readonly RepositorioAmigo repositorioAmigo;
    public TelaAmigo(
        string nomeEntidade,
        RepositorioAmigo repositorioAmigo) : base(nomeEntidade, repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do amigo: ");
        string? nomeAmigo = Console.ReadLine();

        Console.Write("Digite o nome do responsavel: ");
        string? nomeResponsavel = Console.ReadLine();

        Console.Write("Informe o numero de telefone: ");
        string? telefone = Console.ReadLine();

        Amigo novoAmigo = new Amigo(nomeAmigo, nomeResponsavel, telefone);

        return novoAmigo;
    }
    public override void Visualizar(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Amigos");
            Console.WriteLine("---------------------------------");
        }

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

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
        }
    }
}



