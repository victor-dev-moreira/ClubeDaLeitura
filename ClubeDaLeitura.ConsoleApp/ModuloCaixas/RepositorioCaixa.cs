using ClubeDaLeitura.ConsoleApp.Compartilhado;
namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class RepositorioCaixa : RepositorioBase
{
    public bool EtiquetasDuplicadas(string etiqueta)
    {
        EntidadeBase[] registros = SelecionarTodos();
        bool etiquetaBool = false;

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = (Caixa)registros[i];

            if (c == null)
                continue;

            if (c.Etiqueta == etiqueta)
            {
                etiquetaBool = true;
                break;
            }
        }
        return etiquetaBool;
    }
}
