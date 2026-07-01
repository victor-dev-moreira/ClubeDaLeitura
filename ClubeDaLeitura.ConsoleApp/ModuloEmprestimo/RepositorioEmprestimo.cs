using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class RepositorioEmprestimo : RepositorioBase
{
    public void RegistrarDevolucao(Emprestimo emprestimoDevolucao)
    {
        emprestimoDevolucao.Status = StatusEmprestimos.Concluido;
        emprestimoDevolucao.Revista.Devolver();
    }
    public void RegistrarEmprestimo(Emprestimo emprestimo)
    {
        emprestimo.Status = StatusEmprestimos.Aberto;
        emprestimo.Revista.Emprestar();

        Cadastrar(emprestimo);
    }
    public Emprestimo[] SelecioarPorAmigo(Amigo amigo)
    {
        Emprestimo[] emprestimos = new Emprestimo[100];
        int indiceEmprestimo = 0;

        EntidadeBase[] registro = SelecionarTodos();

        for (int i = 0; i < registro.Length; i++)
        {
            Emprestimo e = (Emprestimo)registro[i];

            if (e == null)
                continue;

            if (e.Amigo == amigo)
            {
                emprestimos[indiceEmprestimo] = (Emprestimo)registro[i];
                indiceEmprestimo++;

            }
        }
        return emprestimos;
    }
    public Emprestimo[] SelecioarPorStatus(StatusEmprestimos SelecionarStatus)
    {
        Emprestimo[] emprestimo = new Emprestimo[100];
        int indiceEmprestimo = 0;

        EntidadeBase[] registro = SelecionarTodos();

        for (int i = 0; i < registro.Length; i++)
        {
            Emprestimo e = (Emprestimo)registro[i];

            if (e == null)
                continue;

            if (e.Status == SelecionarStatus)
            {
                emprestimo[indiceEmprestimo] = (Emprestimo)registro[i];
                indiceEmprestimo++;

            }
        }
        return emprestimo;
    }
    public bool RevistaEmprestimo(Revista revistaSelecionada)
    {
        EntidadeBase[] registros = SelecionarTodos();
        bool revistaBool = false;

        for (int i = 0; i < registros.Length; i++)
        {
            Emprestimo e = (Emprestimo)registros[i];

            if (e == null)
                continue;

            if (e.Revista == revistaSelecionada)
            {
                revistaBool = true;
                break;
            }
        }
        return revistaBool;
    }

    public bool AmigoEmprestimo(Amigo amigo)
    {
        EntidadeBase[] registros = SelecionarTodos();
        bool amigoBool = false;

        for (int i = 0; i < registros.Length; i++)
        {
            Emprestimo e = (Emprestimo)registros[i];

            if (e == null)
                continue;

            if (e.Amigo == amigo)
            {
                amigoBool = true;
                break;
            }
        }
        return amigoBool;
    }

}
