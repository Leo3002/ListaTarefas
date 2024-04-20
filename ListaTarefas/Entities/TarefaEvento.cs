using System.Data;

namespace ListaTarefas.Entities
{
    public class TarefaEvento
    {
        public TarefaEvento()
        {
            Deletado = false;
        }
        public Guid id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string StatusTarefa { get; set; }
        public bool Deletado { get; set; }


        public void Update(string titulo, string descricao, string status)
        {
            Titulo = titulo;
            Descricao = descricao;
            StatusTarefa = status;
        }

        public void Delete()
        {
            Deletado = true;
        }
    }
}
