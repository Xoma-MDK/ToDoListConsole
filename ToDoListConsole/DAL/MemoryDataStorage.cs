using ToDoListConsole.BLL.Models;

namespace ToDoListConsole.DAL
{
    public class MemoryDataStorage : IDataStorage
    {
        private int _counterIds = 0;
        private readonly List<ToDoTask> _toDoTasks = [];

        public ToDoTask? CreateToDoTask(ToDoTask task)
        {
            task.Id = _counterIds++;
            _toDoTasks.Add(task);
            return _toDoTasks.FirstOrDefault(x => x.Id == task.Id);
        }

        public ToDoTask? DeleteToDoTask(int id)
        {
            var task = GetToDoTask(id);
            if (task == null) return null;
            if (_toDoTasks.Remove(task)) { 
                return task;
            }
            else return null;
        }

        public ToDoTask? GetToDoTask(int id)
        {
            return _toDoTasks.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ToDoTask> GetToDoTasks()
        {
            return [.. _toDoTasks];
        }

        public ToDoTask? UpdateToDoTask(ToDoTask task)
        {
            var oldtask = _toDoTasks.FirstOrDefault(x => x.Id == task.Id);
            if (oldtask == null) return null;
            oldtask.Name = task.Name;
            oldtask.Text = task.Text;
            oldtask.IsCompleted = task.IsCompleted;
            return (ToDoTask)oldtask;
        }
    }
}
