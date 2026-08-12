namespace CatalogoLivro
{
    public class Recurso
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public Recurso(int id, string nome, string tipo)
        {
            Id = id;
            Nome = nome;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return @$"Id: {Id}
Nome: {Nome}
Tipo: {Tipo}";
        }
    }
}