namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class TelaCaixas()
{
    private readonly RepositorioCaixa repositorioCaixa;

    public TelaCaixas(RepositorioCaixa repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }

    public string ObterMenuCaixas()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Caixas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastro de Caixas");
        Console.WriteLine("2 - Editar Caixas");
        Console.WriteLine("3 - Excluir Caixas");
        Console.WriteLine("4 - Visualizar Caixas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuCaixas = Console.ReadLine()?.ToUpper();
        return opcaoMenuCaixas;
    }

    public void Cadastro()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Caixas");
        Console.WriteLine("---------------------------------");

        Caixa caixaNova = ObterDadosCadastrais();

        repositorioCaixa.Cadastro(caixaNova);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro {caixaNova.Etiqueta} foi criada com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione enter para prosseguir");
        Console.ReadLine();
    }

    public void Editar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Edicão de Caixas");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Qual Id da Caixa que deseja editar? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Caixa caixaAtualizada = ObterDadosCadastrais();

        repositorioCaixa.Editar(idSelecionado, caixaAtualizada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{caixaAtualizada.Etiqueta}\" foi editado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Exclusão de Caixa");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Qual Id da Caixa que deseja editar? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        repositorioCaixa.Excluir(idSelecionado);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro de ID \"{idSelecionado}\" foi excluído com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    public void Visualizar(bool deveExibirCabecalho)
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
        Caixa[] registros = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

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

    private Caixa ObterDadosCadastrais()
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
