namespace CatalogoLivros;

public interface ILivroService
{
    IEnumerable<Livro> Buscar();

    void Adicionar(Livro livro);
}
