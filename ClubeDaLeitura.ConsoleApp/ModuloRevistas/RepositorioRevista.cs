using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class RepositorioRevista : RepositorioBase
{

    public bool TituloEdicaoRepetido(string titulo, int edicao)
    {
        EntidadeBase[] registros = SelecionarTodos();
        bool tituloRepetido = false;

        for (int i = 0; i < registros.Length; i++)
        {
            Revista r = (Revista)registros[i];

            if (r == null)
                continue;

            if (r.Titulo == titulo && r.NumeroEdicao == edicao)
            {
                tituloRepetido = true;
                break;
            }
        }
        return tituloRepetido;
    }
    public bool CaixaComRevistas(Caixa caixaSelecionada)
    {
        EntidadeBase[] registros = SelecionarTodos();
        bool caixaRevistaBool = false;

        for (int i = 0; i < registros.Length; i++)
        {
            Revista r = (Revista)registros[i];

            if (r == null)
                continue;

            if (r.Caixa == caixaSelecionada)
            {
                caixaRevistaBool = true;
                break;
            }
        }
        return caixaRevistaBool;
    }
}
