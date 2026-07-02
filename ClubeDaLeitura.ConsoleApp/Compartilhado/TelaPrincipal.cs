using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private readonly RepositorioCaixa repositorioCaixa;
    private readonly RepositorioAmigo repositorioAmigo;
    private readonly RepositorioRevista repositorioRevista;
    private readonly RepositorioEmprestimo repositorioEmprestimo;
    public TelaPrincipal()
    {
        repositorioCaixa = new RepositorioCaixa();
        repositorioRevista = new RepositorioRevista();
        repositorioAmigo = new RepositorioAmigo();
        repositorioEmprestimo = new RepositorioEmprestimo();


        // TelaCaixas telaCaixas = new TelaCaixas("Caixa", repositorioCaixa, repositorioRevista);
        // TelaRevistas telaRevista = new TelaRevistas("Revista", repositorioCaixa, repositorioRevista, repositorioEmprestimo);
        // TelaAmigo telaAmigo = new TelaAmigo("Amigo", repositorioAmigo, repositorioEmprestimo);
        // TelaEmprestimo telaEmprestimo = new TelaEmprestimo("Emprestimo", repositorioEmprestimo, repositorioAmigo, repositorioRevista);

        Caixa caixaTeste = new Caixa("Acão", "Vermelho", 5);
        Revista revistaTeste = new Revista("Action Comics", 1, 1976, caixaTeste);
        Amigo amigoTeste = new Amigo("Victor", "Sidnei", "47996629736");
        Emprestimo emprestimoTeste = new Emprestimo(amigoTeste, revistaTeste);

        repositorioCaixa.Cadastrar(caixaTeste);
        repositorioRevista.Cadastrar(revistaTeste);
        repositorioAmigo.Cadastrar(amigoTeste);
        repositorioEmprestimo.Cadastrar(emprestimoTeste);
    }

    public ITelaOpcoes ObterMenuPrincipal()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Clube da Leitura");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar caixas de revistas");
        Console.WriteLine("2 - Gerenciar revistas");
        Console.WriteLine("3 - Gerenciar amigos");
        Console.WriteLine("4 - Gerenciar empréstimos");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCaixas("Caixa", repositorioCaixa, repositorioRevista);

        if (opcaoMenuPrincipal == "2")
            return new TelaRevistas("Revista", repositorioCaixa, repositorioRevista, repositorioEmprestimo);

        if (opcaoMenuPrincipal == "3")
            return new TelaAmigo("Amigo", repositorioAmigo, repositorioEmprestimo);

        if (opcaoMenuPrincipal == "4")
            return new TelaEmprestimo("Emprestimo", repositorioEmprestimo, repositorioAmigo, repositorioRevista);


        return null;
    }
}
