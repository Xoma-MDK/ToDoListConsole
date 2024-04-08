using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListConsole.BLL.Models;
using ToDoListConsole.DAL;

namespace ToDoListConsole.BLL
{
    public class ToDoService(IDataStorage storage) : IToDoService
    {
        private readonly IDataStorage _storage = storage;

        public ToDoTask? CreateTodo(ToDoTask toDoTask)
        {
            return _storage.CreateToDoTask(toDoTask);
        }

        public ToDoTask? DeleteTodo(int id)
        {
            return _storage.DeleteToDoTask(id);
        }

        public ToDoTask? GetTodo(int id)
        {
            return _storage.GetToDoTask(id);
        }

        public IEnumerable<ToDoTask> GetTodos()
        {
            return _storage.GetToDoTasks();
        }

        public IEnumerable<ToDoTask> GetTodosByPriority()
        {
            var todos = _storage.GetToDoTasks().ToList();
            return todos.OrderByDescending(x => x.Priority);
        }

        public ToDoTask? MarkAsDone(int id)
        {
            var task = _storage.GetToDoTask(id);
            if (task == null) return null;
            task.IsCompleted = true;
            return _storage.UpdateToDoTask(task);
        }

        public IEnumerable<ToDoTask> SearchByName(string name)
        {
            var task = _storage.GetToDoTasks();
            return task.Where(x => x.Name.Contains(name));
        }
    }
}
