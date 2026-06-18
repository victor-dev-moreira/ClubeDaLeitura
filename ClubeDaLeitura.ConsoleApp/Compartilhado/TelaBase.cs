namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class TelaBase
{
    private string nomeEntidade = string.Empty;
    private RepositorioBase repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }
    public string ObterMenu()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de {nomeEntidade}s");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
        Console.WriteLine($"2 - Editar {nomeEntidade}");
        Console.WriteLine($"3 - Excluir {nomeEntidade}");
        Console.WriteLine($"4 - Visualizar {nomeEntidade}s");
        Console.WriteLine($"S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenu = Console.ReadLine()?.ToUpper();
        return opcaoMenu;
    }
    public void Cadastrar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Gestão de {nomeEntidade}");
        Console.WriteLine("---------------------------------");

        EntidadeBase entidadeNova = ObterDadosCadastrais();

        repositorio.Cadastrar(entidadeNova);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro {entidadeNova.Id} foi criada com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Pressione enter para prosseguir");
        Console.ReadLine();
    }
    public void Editar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Edicão de {nomeEntidade}");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Qual Id do registro que deseja editar? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        EntidadeBase entidadeAtualizada = ObterDadosCadastrais();

        repositorio.Editar(idSelecionado, entidadeAtualizada);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{entidadeAtualizada.Id}\" foi editado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }
    public void Excluir()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Exclusão de {nomeEntidade}");
        Console.WriteLine("---------------------------------");

        Visualizar(false);

        Console.WriteLine("---------------------------------");
        Console.Write("Qual Id do registro que deseja excluir? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        repositorio.Excluir(idSelecionado);
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro de ID \"{idSelecionado}\" foi excluído com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    public abstract void Visualizar(bool deveExibirCabecalho);
    protected abstract EntidadeBase ObterDadosCadastrais();
}
