using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class TelaRevistas
{
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioCaixa repositorioCaixa;

    public TelaRevistas(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
    }

    public string ObterMenuRevista()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Revistas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar revista");
        Console.WriteLine("2 - Editar revista");
        Console.WriteLine("3 - Excluir revista");
        Console.WriteLine("4 - Visualizar revistas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Revistas");
        Console.WriteLine("---------------------------------");

        Revista novaRevista = ObterDadosCadastrais();

        repositorioRevista.Cadastrar(novaRevista);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novaRevista.Titulo}\" foi cadastrado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();

    }

    public void Editar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Editar Revista");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.Write("Qual ID da revista que deseja editar? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Revista novaRevista = ObterDadosCadastrais();

        repositorioRevista.Editar(idSelecionado, novaRevista);


    }

    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Excluir Revista");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");

        Console.Write("Qual ID da revista que deseja excluir? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        repositorioRevista.Excluir(idSelecionado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Revista {idSelecionado} excluida com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione enter para prosseguir...");
        Console.ReadLine();
    }
    public void Visualizar(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Visualização de Revistas");
            Console.WriteLine("---------------------------------");
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20} | {4, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo", "Caixa"
        );

        EntidadeBase[] registros = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Revista r = (Revista)registros[i];

            if (registros[i] == null)
                continue;

            Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20} | {4, -20}",
            r.Id, r.Titulo, r.NumeroEdicao, r.AnoPublicacao, r.Caixa.Etiqueta
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Pressione enter para prosseguir...");
            Console.ReadLine();
        }
    }

    public Revista ObterDadosCadastrais()
    {
        Console.Write("Qual titulo da Revista? ");
        string titulo = Console.ReadLine();

        Console.Write("Qual numero de edicão? ");
        int numeroEdicao = int.Parse(Console.ReadLine());

        Console.Write("Qual o ano de publicacão? ");
        int anoPublicacao = int.Parse(Console.ReadLine());

        Console.WriteLine("---------------------------------");

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
        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Caixa? caixaSelecionada = (Caixa)repositorioCaixa.SelecionarPorId(idSelecionado);

        return new Revista(titulo, numeroEdicao, anoPublicacao, caixaSelecionada);
    }

}
