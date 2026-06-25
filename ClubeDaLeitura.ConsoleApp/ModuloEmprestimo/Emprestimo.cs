using System;
using System.Security.Cryptography.X509Certificates;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using ClubeDaLeitura.ConsoleApp.Utilidades;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public enum StatusEmprestimos
{
    Aberto,
    Concluido,
    Atrasado
}
public class Emprestimo : EntidadeBase
{
    public Emprestimo(Amigo amigo, Revista revista)
    {
        Id = GeradorIds.ObterIdEmprestimo();
        DataAbertura = DateTime.Now;
        Amigo = amigo;
        Revista = revista;
    }
    public Amigo Amigo { get; private set; }
    public Revista Revista { get; private set; }
    public StatusEmprestimos Status { get; set; }
    public DateTime DataAbertura;
    public DateTime DataDevolucaoPrevista
    {
        get
        {
            int diasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;

            DateTime DataDevolucaoPrevista = DataAbertura.AddDays(diasDeEmprestimo);

            return DataDevolucaoPrevista;
        }
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Emprestimo emprestimoAtualizado = (Emprestimo)entidadeAtualizada;

        Status = emprestimoAtualizado.Status;
    }
}
