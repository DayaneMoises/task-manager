using MongoDB.Driver;
using TaskManager.API.Data.Configurations;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public class TarefasRepository : ITarefasRepository
    {
        //acessar as colecao do mongo
        private readonly IMongoCollection<Tarefa> _tarefas;

        //injecao de dependencias
        public TarefasRepository(IDatabaseConfig databaseConfig)
        {
            //criar client
            var client = new MongoClient(databaseConfig.ConnectionString);
            //acessar database
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            //inicializa
            _tarefas = database.GetCollection<Tarefa>("tarefas");

        }

        //retorna a tarefa que add
        public void Adicionar(Tarefa tarefa)
        {
            _tarefas.InsertOne(tarefa);
        }

        public void Atualizar(string id, Tarefa tarefaAtualizada)
        {
            //replace muda o objeto inteiro
            _tarefas.ReplaceOne(t => t.Id == id, tarefaAtualizada); //primeiro parametro é o filtro, segundo é passar a tarefa atualizada
        }

        public IEnumerable<Tarefa> Buscar()
        {
            return _tarefas.Find(t => true).ToList();
        }

        public Tarefa Buscar(string id)
        {
            return _tarefas.Find(t => t.Id == id).FirstOrDefault();

        }
        public void Remover(string id)
        {
            _tarefas.DeleteOne(t => t.Id == id);
        }
    }
}
