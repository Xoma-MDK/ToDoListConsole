using ToDoListConsole.BLL.Models;

namespace ToDoListConsole.DAL
{
    public interface IDataStorage
    {
        public ToDoTask? GetToDoTask(int id);
        public IEnumerable<ToDoTask> GetToDoTasks();
        public ToDoTask? DeleteToDoTask(int id);
        public ToDoTask? CreateToDoTask(ToDoTask task);
        public ToDoTask? UpdateToDoTask(ToDoTask task);
    }
}
