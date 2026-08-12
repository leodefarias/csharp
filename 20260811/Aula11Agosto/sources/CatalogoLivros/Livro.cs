namespace CatalogoLivros;

public class Livro
{
    public required string Nome { get; set; }
    public required string Autor { get; set; }
    public required int NumberOfPages { get; set; }
    public DateTime? DayOfPurchase { get; set; }
}
