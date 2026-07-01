using ClubeDaLeitura.ConsoleApp.Compartilhado;
namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class RepositorioAmigo : RepositorioBase
{
    public bool NomeTelefoneRepetido(string nome, string telefone)
    {
        EntidadeBase[] registros = SelecionarTodos();
        bool nomeTelefoneRepetido = false;

        for (int i = 0; i < registros.Length; i++)
        {
            Amigo a = (Amigo)registros[i];

            if (a == null)
                continue;

            if (a.NomeAmigo == nome && a.Telefone == telefone)
            {
                nomeTelefoneRepetido = true;
                break;
            }
        }
        return nomeTelefoneRepetido;
    }
}
