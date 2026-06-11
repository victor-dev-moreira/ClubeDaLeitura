using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

RepositorioBase repositorioBase = new RepositorioBase();

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioRevista repositorioRevista = new RepositorioRevista();

TelaCaixas telaCaixas = new TelaCaixas(repositorioCaixa, repositorioRevista);
TelaRevistas telaRevista = new TelaRevistas(repositorioRevista, repositorioCaixa);

Caixa caixaTeste = new Caixa("Acão", "Vermelho", 5);
Revista revistaTeste = new Revista("Action Comics", 1, 1976, caixaTeste);

repositorioCaixa.Cadastrar(caixaTeste);
repositorioRevista.Cadastrar(revistaTeste);

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
            string opcaoMenuInterno = telaCaixas.ObterMenuCaixas();

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
        string opcaoMenuInterno = telaRevista.ObterMenuRevista();
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

    }
    else if (opcaoMenuPrincipal == "4") // Emprestimos
    {

    }
}

