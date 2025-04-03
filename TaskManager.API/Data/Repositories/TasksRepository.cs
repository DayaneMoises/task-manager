using MongoDB.Driver;
using TaskManager.API.Data.Configurations;
using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        //acessar as colecao do mongo
        private readonly IMongoCollection<TodoTask> _tasks;

        //injecao de dependencias
        public TasksRepository(IDatabaseConfig databaseConfig)
        {
            //criar client
            var client = new MongoClient(databaseConfig.ConnectionString);
            //acessar database
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            //inicializa
            _tasks = database.GetCollection<TodoTask>("tasks");

        }

        //retorna a task que add
        public void Add(TodoTask task)
        {
            _tasks.InsertOne(task);
        }

        public void Update(string id, TodoTask taskAtualizada)
        {
            //replace muda o objeto inteiro
            _tasks.ReplaceOne(t => t.Id == id, taskAtualizada); //primeiro parametro é o filtro, segundo é passar a task atualizada
        }

        public IEnumerable<TodoTask> Search()
        {
            return _tasks.Find(t => true).ToList();
        }

        public TodoTask Search(string id)
        {
            return _tasks.Find(t => t.Id == id).FirstOrDefault();

        }
        public void Remove(string id)
        {
            _tasks.DeleteOne(t => t.Id == id);
        }
    }
}
