namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class TelaCaixas()
{
    private RepositorioCaixa repositorioCaixa;
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


    }

    public void Excluir()
    {

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

        /// parei aqui
        /// 
    }

    private Caixa ObterDadosCadastrais()
    {
        Console.Write("Digite o nome da etiqueta da caixa: ");
        string? etiqueta = Console.ReadLine();

        Console.WriteLine("Digite o nome da cor da caixa: ");
        string? cor = Console.ReadLine();

        Console.WriteLine("Informe o tempo de empréstimo das revistas da caixa: ");
        int diasDoEmprestimo = int.Parse(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDoEmprestimo);

        return novaCaixa;
    }

}
