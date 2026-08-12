namespace CatalogoLivro;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Catalogo Livros ===");

        var colecaoLivros = new List<Livro>();
        var colecaoReservas = new List<Reserva>();
        var colecaoRecursos = new List<Recurso>();

        bool devoContinuar = true;

        while (devoContinuar)
        {
            Console.WriteLine(@"
Por favor, selecione uma opção:
1. Cadastrar recurso
2. Criar reserva
3. Listar recursos
4. Listar reservas
0. Sair");
            string? entradaUsuario = Console.ReadLine();

            if (int.TryParse(entradaUsuario, out int opcaoSelecionada) == false || opcaoSelecionada > 3 || opcaoSelecionada < 0)
            {
                Console.WriteLine("Opção inválida. Selecione novamente");
                continue;
            }

            switch (opcaoSelecionada)
            {
                case 0:

                    devoContinuar = false;
                    break;
                case 1:
                    CadastrarRecurso(colecaoRecursos);

                    break;
                case 2:
                    
                    break;

                case 3:
                    foreach (Recurso recurso in colecaoRecursos)
                    {
                        Console.WriteLine(recurso);
                        Console.WriteLine("---------------");
                    }
                    break;

                default:
                    continue;
            }
        }
    }

    public static void CadastrarRecurso(List<Recurso> listaRecursos)
    {

        int idRecurso = listaRecursos.Count + 1;

        Console.WriteLine("Inira o nome do recurso novo: ");

        string nomeRecurso = Console.ReadLine() ?? "";
        nomeRecurso.Trim();

        Console.WriteLine("Inira o tipo do recurso: ");

        string tipoRecurso = Console.ReadLine() ?? "";
        tipoRecurso.Trim();

        if(nomeRecurso == "" || tipoRecurso == "")
        {
            Console.WriteLine("Dados inválidos."); 
        }

        Recurso recurso = new Recurso(idRecurso, nomeRecurso,  tipoRecurso);

        listaRecursos.Add(recurso);

        Console.WriteLine("Dados cadastrados com sucesso.");
    }
}