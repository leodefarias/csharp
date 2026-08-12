namespace CatalogoLivro
{
    public class Reserva
    {
        public int Id { get; set; }
        public Recurso Recurso { get; set; }
        public string Responsavel { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim {  get; set; }
        public Reserva(int id, Recurso recurso, string responsavel, DateTime inicio, DateTime fim)
        {
            Id = id;
            Recurso = recurso;
            Responsavel = responsavel;
            Inicio = inicio;
            Fim = fim;
        }
    }


}