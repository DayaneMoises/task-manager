namespace TaskManager.API.Models
{
    public class Tarefa
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Detalhes { get; private set; }
        public bool Concluido { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataConcluido { get; private set; }

        public Tarefa(string nome, string detalhes)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Detalhes = detalhes;
            Concluido = false;
            DataCadastro = DateTime.Now;
            DataConcluido = null;
        }

        //metodo set pra atualizar os dados da tarefa
        public void AtualizarTarefa(string nome, string detalhes, bool? concluido = false)
        {
            Nome = nome;
            Detalhes = detalhes;
            //Concluido = concluido.HasValue ? concluido.Value : false;
            Concluido = concluido ?? false;
            DataConcluido = Concluido ? DateTime.Now : null; //só atualiza se tiver valor (true)
        }
    }
}
