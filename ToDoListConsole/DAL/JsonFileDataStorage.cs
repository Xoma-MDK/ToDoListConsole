using Newtonsoft.Json;
using ToDoListConsole.BLL.Models;

namespace ToDoListConsole.DAL
{
    public class JsonFileDataStorage : IDataStorage
    {
        private int _counterIds = 0;
        private readonly List<ToDoTask> _toDoTasks = [];
        private readonly string _filePath;

        public JsonFileDataStorage(string filePath)
        {
            _filePath = filePath;
            LoadDataFromJson();
        }

        public ToDoTask? CreateToDoTask(ToDoTask task)
        {
            task.Id = _counterIds++;
            _toDoTasks.Add(task);
            SaveDataToJson();
            return _toDoTasks.FirstOrDefault(x => x.Id == task.Id);
        }

        public ToDoTask? DeleteToDoTask(int id)
        {
            var task = GetToDoTask(id);
            if (task == null) return null;
            if (_toDoTasks.Remove(task))
            {
                SaveDataToJson();
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
            SaveDataToJson();
            return oldtask;
        }

        private void LoadDataFromJson()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                var todos = JsonConvert.DeserializeObject<List<ToDoTask>>(json);
                if (todos != null)
                {
                    _toDoTasks.AddRange(todos);
                    _counterIds = _toDoTasks.Count > 0 ? _toDoTasks.Max(t => t.Id) + 1 : 0;
                }
            }
        }

        private void SaveDataToJson()
        {
            var json = JsonConvert.SerializeObject(_toDoTasks, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
