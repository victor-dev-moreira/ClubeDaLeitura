using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

TelaPrincipal telaPrincipal = new TelaPrincipal();

while (true)
{
    ITelaOpcoes telaSelecionada = telaPrincipal.ObterMenuPrincipal();

    if (telaSelecionada == null)
        break;

    while (true)
    {
        if (telaSelecionada is TelaBase telaBase) // Caixas, Revistas, Amigos
        {

            string opcaoMenuInterno = telaSelecionada.ObterMenu();

            if (opcaoMenuInterno == "S")
                break;

            else if (opcaoMenuInterno == "1")
            {
                telaBase.Cadastrar();
            }
            else if (opcaoMenuInterno == "2")
            {
                telaBase.Editar();
            }
            else if (opcaoMenuInterno == "3")
            {
                telaBase.Excluir();
            }
            else if (opcaoMenuInterno == "4")
            {
                telaBase.Visualizar(true);
            }
        }

        else if (telaSelecionada is TelaEmprestimo telaEmprestimo) // Emprestimos
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
}




