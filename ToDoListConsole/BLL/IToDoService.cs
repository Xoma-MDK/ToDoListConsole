using ToDoListConsole.BLL.Models;

namespace ToDoListConsole.BLL
{
    public interface IToDoService
    {
        ToDoTask? CreateTodo(ToDoTask toDoTask);
        ToDoTask? DeleteTodo(int id);
        IEnumerable<ToDoTask> GetTodos();
        IEnumerable<ToDoTask> GetTodosByPriority();
        ToDoTask? GetTodo(int id);
        ToDoTask? MarkAsDone(int id);
        IEnumerable<ToDoTask> SearchByName(string Name);
    }
}
