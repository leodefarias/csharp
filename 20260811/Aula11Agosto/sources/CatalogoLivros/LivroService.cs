namespace CatalogoLivros;

public class LivroService : ILivroService
{
    private readonly List<Livro> _listaLivros;
    public LivroService()
    {
        _listaLivros = new List<Livro>();
    }

    public void Adicionar(Livro livro)
    {
        _listaLivros.Add(livro);
    }

    public IEnumerable<Livro> Buscar()
    {
        return _listaLivros;
    }
}
