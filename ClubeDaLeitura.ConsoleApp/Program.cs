using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();
RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();


TelaCaixas telaCaixas = new TelaCaixas("Caixa", repositorioCaixa, repositorioRevista);
TelaRevistas telaRevista = new TelaRevistas("Revista", repositorioCaixa, repositorioRevista, repositorioEmprestimo);
TelaAmigo telaAmigo = new TelaAmigo("Amigo", repositorioAmigo, repositorioEmprestimo);
TelaEmprestimo telaEmprestimo = new TelaEmprestimo("Emprestimo", repositorioEmprestimo, repositorioAmigo, repositorioRevista);

Caixa caixaTeste = new Caixa("Acão", "Vermelho", 5);
Revista revistaTeste = new Revista("Action Comics", 1, 1976, caixaTeste);
Amigo amigoTeste = new Amigo("Victor", "Sidnei", "47996629736");
Emprestimo emprestimoTeste = new Emprestimo(amigoTeste, revistaTeste);

repositorioCaixa.Cadastrar(caixaTeste);
repositorioRevista.Cadastrar(revistaTeste);
repositorioAmigo.Cadastrar(amigoTeste);
repositorioEmprestimo.Cadastrar(emprestimoTeste);

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    string opcaoMenuPrincipal = telaPrincipal.ObterMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
        break;

    if (opcaoMenuPrincipal == "1") // Caixas
    {
        while (true)
        {
            string opcaoMenuInterno = telaCaixas.ObterMenu();

            if (opcaoMenuInterno == "S")
                break;

            else if (opcaoMenuInterno == "1")
            {
                telaCaixas.Cadastrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaCaixas.Editar();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaCaixas.Excluir();
            }
            else if (opcaoMenuInterno == "4")
            {
                telaCaixas.Visualizar(true);
            }
        }
    }
    else if (opcaoMenuPrincipal == "2") // Revistas
    {
        string opcaoMenuInterno = telaRevista.ObterMenu();
        if (opcaoMenuInterno == "S")
            break;

        else if (opcaoMenuInterno == "1")
        {
            telaRevista.Cadastrar();
        }
        else if (opcaoMenuInterno == "2")
        {
            telaRevista.Editar();
        }
        else if (opcaoMenuInterno == "3")
        {
            telaRevista.Excluir();
        }
        else if (opcaoMenuInterno == "4")
        {
            telaRevista.Visualizar(true);
        }
    }
    else if (opcaoMenuPrincipal == "3") // Amigos
    {
        string opcaoMenuInterno = telaAmigo.ObterMenu();
        if (opcaoMenuInterno == "S")
            break;

        else if (opcaoMenuInterno == "1")
        {
            telaAmigo.Cadastrar();
        }
        else if (opcaoMenuInterno == "2")
        {
            telaAmigo.Editar();
        }
        else if (opcaoMenuInterno == "3")
        {
            telaAmigo.Excluir();
        }
        else if (opcaoMenuInterno == "4")
        {
            telaAmigo.Visualizar(true);
        }
    }
    else if (opcaoMenuPrincipal == "4") // Emprestimos
    {
        string opcaoMenuInterno = telaEmprestimo.ObterMenu();
        if (opcaoMenuInterno == "S")
            break;

        else if (opcaoMenuInterno == "1")
        {
            telaEmprestimo.Abrir();
        }
        else if (opcaoMenuInterno == "2")
        {
            telaEmprestimo.Concluir();
        }
        else if (opcaoMenuInterno == "3")
        {
            telaEmprestimo.Visualizar(true);
        }
    }
}

