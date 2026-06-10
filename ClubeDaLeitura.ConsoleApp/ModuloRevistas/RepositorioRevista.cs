namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas;

public class RepositorioRevista
{
    private readonly Revista[] registros = new Revista[100];

    public void Cadastrar(Revista novaRevista)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaRevista;
                break;
            }
        }
    }
    public Revista[] SelecionarTodos()
    {
        return registros;
    }

    public bool Editar(int idSelecionado, Revista novaRevista)
    {
        Revista? revistaSelecionada = null;

        for (int i = 0; i < registros.Length; i++)
        {
            Revista r = registros[i];

            if (registros[i] == null)
                continue;

            if (r.Id == idSelecionado)
            {
                revistaSelecionada = r;
                break;
            }
        }
        if (revistaSelecionada == null)
            return false;

        revistaSelecionada.Atualizar(novaRevista);

        return true;
    }
}
