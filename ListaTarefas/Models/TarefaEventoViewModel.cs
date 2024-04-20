namespace ListaTarefas.Models
{
    public class TarefaEventoViewModel
    {
        public Guid id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string StatusTarefa { get; set; }
    }
}
