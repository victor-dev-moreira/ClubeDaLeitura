using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class RepositorioCaixa : RepositorioBase
{
    private Caixa[] registros = new Caixa[100];

    public bool Editar(int idSelecionado, Caixa caixaAtualizada)
    {
        Caixa? caixaSelecionada = null;

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                caixaSelecionada = c;
                break;
            }
        }

        if (caixaSelecionada == null)
            return false;

        caixaSelecionada.Atualizar(caixaAtualizada);

        return true;
    }

    public void Excluir(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                registros[i] = null;
                break;
            }
        }
    }

    public Caixa? SelecionarPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            Caixa c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
                return c;
        }

        return null;
    }
}
