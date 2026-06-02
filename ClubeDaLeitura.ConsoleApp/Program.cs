using System.ComponentModel.Design;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

TelaPrincipal telaPrincipal = new TelaPrincipal();
TelaCaixas telaCaixas = new TelaCaixas();


while (true)
{
    string opcaoMenuPrincipal = telaPrincipal.ObterMenuPrincipal();

    if (opcaoMenuPrincipal == "S")
        break;



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

    if (opcaoMenuPrincipal == "1") // Caixas
    {

    }
    else if (opcaoMenuPrincipal == "2") // Revistas
    {

    }
    else if (opcaoMenuPrincipal == "3") // Amigos
    {

    }
    else if (opcaoMenuPrincipal == "4") // Emprestimos
    {

    }
}

