namespace TaskManager.API.Models
{
    public class TodoTask
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Details { get; private set; }
        public bool Concluido { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataConcluido { get; private set; }

        public TodoTask(string name, string details)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Details = details;
            Concluido = false;
            DataCadastro = DateTime.Now;
            DataConcluido = null;
        }

        //metodo set pra Update os dados da task
        public void UpdateTask(string name, string details, bool? concluido = false)
        {
            Name = name;
            Details = details;
            //Concluido = concluido.HasValue ? concluido.Value : false;
            Concluido = concluido ?? false;
            DataConcluido = Concluido ? DateTime.Now : null; //só atualiza se tiver valor (true)
        }
    }
}
