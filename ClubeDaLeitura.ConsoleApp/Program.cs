using System.ComponentModel.Design;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
TelaCaixas telaCaixas = new TelaCaixas(repositorioCaixa);

RepositorioRevista repositorioRevista = new RepositorioRevista();
TelaRevistas telaRevista = new TelaRevistas(repositorioRevista, repositorioCaixa);

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
                telaCaixas.Cadastro();
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
            telaRevista.Cadastro();
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

