using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class TelaCaixas
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioRevista repositorioRevista;

    public TelaCaixas(RepositorioCaixa repositorioCaixa, RepositorioRevista repositorioRevista)
    {
        this.repositorioCaixa = repositorioCaixa;
        this.repositorioRevista = repositorioRevista;
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

    public void Cadastrar()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Caixas");
        Console.WriteLine("---------------------------------");

        Caixa caixaNova = ObterDadosCadastrais();

        repositorioCaixa.Cadastrar(caixaNova);

        EntidadeBase[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = (Caixa)caixas[i];

            if (c == null)
                continue;
            if (c.Etiqueta.ToLower() == caixaNova.Etiqueta.ToLower())
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Já existe uma caixa com a etiqueta \"{caixaNova.Etiqueta}\"!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();

                return;
            }
        }
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
        Console.Write("Qual Id do registro que deseja editar? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        Caixa caixaAtualizada = ObterDadosCadastrais();

        EntidadeBase[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa c = (Caixa)caixas[i];

            if (c == null)
                continue;

            if (c.Id != idSelecionado && c.Etiqueta.ToLower() == caixaAtualizada.Etiqueta.ToLower())
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Já existe uma caixa com a etiqueta \" {caixaAtualizada.Etiqueta}\"!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();

            }
        }

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
        Console.Write("Qual Id do registro que deseja excluir? ");
        int idSelecionado = int.Parse(Console.ReadLine());

        EntidadeBase[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            if (r.Caixa.Id == idSelecionado)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Não é possível excluir uma caixa com revistas vinculadas!");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Pressioner ENTER para continuar");
                Console.ReadLine();
            }
        }

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
