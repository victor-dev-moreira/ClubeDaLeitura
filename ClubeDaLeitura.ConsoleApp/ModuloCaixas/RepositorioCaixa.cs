namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class RepositorioCaixa
{
    private Caixa[] registros = new Caixa[100];

    public void Cadastro(Caixa novaCaixa)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaCaixa;
                break;
            }
        }
    }

    public Caixa[] SelecionarTodos()
    {
        return registros;
    }
}
