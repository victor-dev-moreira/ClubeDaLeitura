using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo : EntidadeBase
{
    public string NomeAmigo { get; private set; }
    public string NomeResponsavel { get; private set; }
    public string Telefone { get; private set; }
    public Amigo(string nomeAmigo, string nomeResponsavel, string telefone)
    {
        Id = GeradorIds.ObterIdAmigo();
        this.NomeAmigo = nomeAmigo;
        this.NomeResponsavel = nomeResponsavel;
        this.Telefone = telefone;
    }
    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoAtualizado = (Amigo)entidadeAtualizada;

        NomeAmigo = amigoAtualizado.NomeAmigo;
        NomeResponsavel = amigoAtualizado.NomeResponsavel;
        Telefone = amigoAtualizado.Telefone;

    }
}
