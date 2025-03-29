using TaskManager.API.Models;

namespace TaskManager.API.Data.Repositories
{
    public interface ITarefasRepository
    {
        void Adicionar(Tarefa tarefa);
        //precisa passar o ID da tarefa antes de atualizar
        void Atualizar( string id, Tarefa tarefaAtualizada);

        //buscar todas as tarefas
        IEnumerable<Tarefa> Buscar();
        //buscar por ID
        Tarefa Buscar(string id);

        void Remover(string id);

    }
}
