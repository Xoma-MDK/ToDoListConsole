using ToDoListConsole.BLL;
using ToDoListConsole.BLL.Models;

namespace ToDoListConsole.PL
{
    public class PLService(IToDoService service) : IPLService
    {
        private readonly IToDoService _service = service;
        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Создать задачу");
                Console.WriteLine("2. Удалить задачу");
                Console.WriteLine("3. Просмотреть список задач");
                Console.WriteLine("4. Пометить задачу как выполненную");
                Console.WriteLine("5. Поиск по названию");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateTask();
                        break;

                    case "2":
                        DeleteTask();
                        break;

                    case "3":
                        var todos = _service.GetTodosByPriority();
                        DisplayTasks(todos);
                        break;

                    case "4":
                        MarkAsReady();
                        break;

                    case "5":
                        SearchTaskByName();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                        break;
                }
            }
        }
        private void SearchTaskByName() {
            Console.Write("Введите часть названия для поиска: ");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (name == null || name == string.Empty)
                {
                    Console.Write("Введите часть названия для поиска: ");
                }
                else
                {
                    break;
                }
            }
            var tasks = _service.SearchByName(name);
            if (!tasks.Any()) {
                Console.WriteLine("Задачи с указанным названием не найдены.");
                return;
            }
            Console.WriteLine("Найденные задачи:");
            DisplayTasks(tasks);
        }
        private void CreateTask()
        {
            Console.Write("Введите название задачи: ");
            string? name;
            while (true)
            {
                name = Console.ReadLine();
                if (name == null || name == string.Empty)
                {
                    Console.Write("Введите название задачи: ");
                }
                else
                {
                    break;
                }
            }
            Console.Write("Введите приоритет задачи: ");
            int priority;
            while (true)
            {
                var priorityString = Console.ReadLine();
                if (!int.TryParse(priorityString, out priority))
                {
                    Console.Write("Введите приоритет задачи: ");
                }
                else
                {
                    break;
                }
            }
            Console.Write("Введите текст задачи: ");
            string? text;
            while (true)
            {
                text = Console.ReadLine();
                if (text == null || text == string.Empty)
                {
                    Console.Write("Введите текст задачи: ");
                }
                else
                {
                    break;
                }
            }
            var task = _service.CreateTodo(new ToDoTask() { Name = name, Priority = priority, Text = text, IsCompleted = false });
            if (task != null) Console.WriteLine("Задача успешно создана.");
            else Console.WriteLine("Возникла ошибка при создании задачи.");
        }
        private void MarkAsReady()
        {
            Console.Write("Введите ID задачи для пометки как выполненной: ");
            int id;
            while (true)
            {
                var idString = Console.ReadLine();
                if (!int.TryParse(idString, out id))
                {
                    Console.Write("Введите ID задачи для пометки как выполненной: ");
                }
                else
                {
                    break;
                }
            }
            if (_service.MarkAsDone(id) != null)
            {
                Console.WriteLine("Задача успешно помечена как выполненная.");
            }
            else
            {
                Console.WriteLine("Задача с указанным ID не найдена.");
            }
        }
        private void DeleteTask()
        {
            Console.Write("Введите ID задачи для удаления: ");
            int id;
            while (true)
            {
                var idString = Console.ReadLine();
                if (!int.TryParse(idString, out id))
                {
                    Console.Write("Введите ID задачи для удаления: ");
                }
                else
                {
                    break;
                }
            }
            if (_service.DeleteTodo(id) != null)
            {
                Console.WriteLine("Задача успешно удалена");
            }
            else
            {
                Console.WriteLine("Задача с указанным ID не найдена.");
            }
        }
        private static void DisplayTasks(IEnumerable<ToDoTask> tasks)
        {
            foreach (var todo in tasks)
            {
                Console.WriteLine($"ID: {todo.Id}, Название: {todo.Name}, Приоритет: {todo.Priority}, Текст: {todo.Text}, Выполнено: {(todo.IsCompleted ? "Да" : "нет")}");
            }
        }
    }
}
