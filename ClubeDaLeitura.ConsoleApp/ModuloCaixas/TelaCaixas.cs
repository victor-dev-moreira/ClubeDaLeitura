namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas;

public class TelaCaixas()
{
    public string ObterMenuCaixas()
    {
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Caixas");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastro de Caixas");
        Console.WriteLine("2 - Editar Caixas");
        Console.WriteLine("3 - Excluir Caixas");
        Console.WriteLine("4 - Visualizar Caixas");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");

        string? opcaoMenuCaixas = Console.ReadLine()?.ToUpper();
        return opcaoMenuCaixas;
    }


}
