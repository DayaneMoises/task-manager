using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public interface ITasksRepository
    {
        void Add(TodoTask task);
        //precisa passar o ID da task antes de Update
        void Update( string id, TodoTask taskAtualizada);

        //Search todas as tasks
        IEnumerable<TodoTask> Search();
        //Search por ID
        TodoTask Search(string id);

        void Remove(string id);

    }
}
