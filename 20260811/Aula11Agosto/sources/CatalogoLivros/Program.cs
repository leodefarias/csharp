using System.Globalization;

namespace CatalogoLivros;

public class Program
{
    private static ILivroService? _livroService;
    public static void Main(string[] args)
    {
        _livroService = new LivroService();
        Console.WriteLine($"=========== Bem vindo ao Catalogo de Livros! ===========");
        Console.WriteLine("=================================");
        bool shouldContinue = true;

        while (shouldContinue)
        {
            int opcao = MostrarMenu();

            switch (opcao)
            {
                case 1:
                    AdicionarLivro();
                    break;
                case 2:
                    ListarLivros();
                    break;
                case 3:
                    shouldContinue = false;
                    break;
            }
        }

        Console.WriteLine("=================================");
        Console.WriteLine("Catalogo finalizado.");
        Console.WriteLine("=================================");
    }

    private static void ListarLivros()
    {
        foreach (var livro in _livroService!.Buscar())
        {
            string foiComprado = livro.DayOfPurchase is null ? "Não." : "Sim";
            Console.Write(@$"#################################
Nome: {livro.Nome}
Autor: {livro.Autor}
Numero de páginas: {livro.NumberOfPages}
Foi comprado: {foiComprado}
Quando comprei: {livro.DayOfPurchase}
#################################");
        }
    }

    private static void AdicionarLivro()
    {
        string autor = LerTextoConsole("Insira o nome do autor.");
        string nome = LerTextoConsole("Insira o nome do livro.");
        int numberOfPages = LerNumeroConsole("Insira o numero de páginas.");
        DateTime? dayOfPurchase = LerDataConsole("Insira a data de compra. Caso não tenha comprado, pressione enter.");

        var livro = new Livro()
        {
            Autor = autor,
            Nome = nome,
            NumberOfPages = numberOfPages,
            DayOfPurchase = dayOfPurchase,
        };

        _livroService!.Adicionar(livro);
    }

    private static int MostrarMenu()
    {
        int opcao = LerNumeroConsole(@"Por favor, selecione uma opção:
1. Adicionar um novo livro.
2. Listar catalogo
3. Sair");

        if (opcao < 1 && opcao > 3)
        {
            Console.WriteLine("Opção inválida. Escolha um número inteiro de 1 a 3 e pressione enter.");
            return MostrarMenu();
        }

        return opcao;
    }

    private static int LerNumeroConsole(string mensagem)
    {
        int retorno = 0;
        do
        {
            Console.WriteLine(mensagem);
        } while (int.TryParse(Console.ReadLine(), out retorno));

        return retorno;
    }

    private static string LerTextoConsole(string mensagem)
    {
        string texto = string.Empty;
        while (string.IsNullOrWhiteSpace(texto))
        {
            Console.WriteLine(mensagem);
            texto = Console.ReadLine() ?? string.Empty;
        }

        return texto;
    }

    private static DateTime? LerDataConsole(string mensagem)
    {
        Console.WriteLine(mensagem);
        string formato = "dd/MM/yyyy";

        do
        {
            string? dateString = Console.ReadLine();

            if (dateString is null)
            {
                return null;
            }

            bool success = DateTime.TryParseExact(
                dateString,
                formato,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate
            );

            if (success)
            {
                return parsedDate;
            }
            else
            {
                Console.WriteLine($"Data inválida. Por favor, use o formato: {formato}");
            }
        } while (true);
    }
}
