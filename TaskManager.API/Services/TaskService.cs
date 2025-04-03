using TaskManager.API.Data.Repositories;
using TaskManager.API.Models;
using TaskManager.API.Models.InputModels;

namespace TaskManager.API.Services
{
    public class TaskService
    {
        private readonly ITasksRepository _tasksRepository;

        public TaskService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public IEnumerable<TodoTask> GetAllTasks()
        {
            return _tasksRepository.Search();
        }

        public TodoTask GetTaskById(string id)
        {
            return _tasksRepository.Search(id);
        }

        public void CreateTask(TaskInputModel inputModel)
        {
            var task = new TodoTask(inputModel.Name, inputModel.Details);
            _tasksRepository.Add(task);
        }

        public bool UpdateTask(string id, TaskInputModel inputModel)
        {
            var existingTask = _tasksRepository.Search(id);
            if (existingTask == null) return false;

            existingTask.UpdateTask(inputModel.Name, inputModel.Details, inputModel.Concluido);
            _tasksRepository.Update(id, existingTask);
            return true;
        }

        public bool DeleteTask(string id)
        {
            var task = _tasksRepository.Search(id);
            if (task == null) return false;

            _tasksRepository.Remove(id);
            return true;
        }
    }
}
