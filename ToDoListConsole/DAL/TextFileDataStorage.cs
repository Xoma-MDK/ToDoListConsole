using ToDoListConsole.BLL.Models;

namespace ToDoListConsole.DAL
{
    public class TextFileDataStorage : IDataStorage
    {

        public ToDoTask? GetToDoTask(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoTask> GetToDoTasks()
        {
            throw new NotImplementedException();
        }

        public ToDoTask? DeleteToDoTask(int id)
        {
            throw new NotImplementedException();
        }

        public ToDoTask? CreateToDoTask(ToDoTask task)
        {
            throw new NotImplementedException();
        }

        public ToDoTask? UpdateToDoTask(ToDoTask task)
        {
            throw new NotImplementedException();
        }
    }
}
