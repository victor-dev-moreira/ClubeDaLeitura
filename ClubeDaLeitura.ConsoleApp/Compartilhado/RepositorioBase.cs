namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class RepositorioBase
{
    private EntidadeBase[] registros = new EntidadeBase[100];

    public void Cadastrar(EntidadeBase novaRegistro)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaRegistro;
                break;
            }
        }
    }

    public bool Editar(int idSelecionado, EntidadeBase entidadeAtualizada)
    {
        EntidadeBase entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.Atualizar(entidadeAtualizada);

        return true;
    }

    public void Excluir(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase o = registros[i];

            if (o == null)
                continue;

            if (o.Id == idSelecionado)
            {
                registros[i] = null;
                break;
            }
        }
    }
    public EntidadeBase[] SelecionarTodos()
    {
        return registros;
    }

    public EntidadeBase SelecionarPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase o = registros[i];

            if (o == null)
                continue;

            if (o.Id == idSelecionado)
                return o;
        }

        return null;
    }
}
