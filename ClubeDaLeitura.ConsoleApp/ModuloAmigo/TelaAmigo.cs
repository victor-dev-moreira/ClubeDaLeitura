using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase
{
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    public TelaAmigo(
        string nomeEntidade,
        RepositorioAmigo repositorioAmigo,
        RepositorioEmprestimo repositorioEmprestimo) : base(nomeEntidade, repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioEmprestimo = repositorioEmprestimo;
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Digite o nome do amigo: ");
        string? nomeAmigo = Console.ReadLine();

        Console.Write("Digite o nome do responsavel: ");
        string? nomeResponsavel = Console.ReadLine();

        Console.Write("Informe o numero de telefone: ");
        string? telefone = Console.ReadLine();

        bool nomeTelefoneRepetido = repositorioAmigo.NomeTelefoneRepetido(nomeAmigo, telefone);

        if (nomeTelefoneRepetido == true)
        {
            Console.WriteLine("Não foi possivel criar o amigo pois o nome ou telefone ja existe!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
            return null;
        }

        Amigo novoAmigo = new Amigo(nomeAmigo, nomeResponsavel, telefone);
        return novoAmigo;
    }

    public override void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Exclusão de Amigo");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Qual Id do registro que deseja excluir? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Amigo amigo = (Amigo)repositorioAmigo.SelecionarPorId(idSelecionado);

        bool amigoBool = repositorioEmprestimo.AmigoEmprestimo(amigo);

        if (amigoBool == true)
        {
            Console.WriteLine("Não foi possivel excluir amigo pois ele tem emprestimo registrado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
            return;
        }

        repositorioAmigo.Excluir(idSelecionado);
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



