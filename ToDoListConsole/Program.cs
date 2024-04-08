using Newtonsoft.Json;
using ToDoListConsole.BLL;
using ToDoListConsole.DAL;
using ToDoListConsole.PL;

namespace ToDoListConsole
{
    internal class Program
    {
        private static AppSettings? _settings;
        static void Main()
        {
            try
            {
                _settings = ReadConfig("./config.json");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка чтения файла конфигурации: {0}", ex.Message);
                return;
            }
            if (_settings == null) return;

            IToDoService? todoService;
            switch (_settings.DataAccessLayer)
            {
                case DataAccessLayer.JsonFile:
                    todoService = new ToDoService(new JsonFileDataStorage(_settings.FilePath));
                    break;
                case DataAccessLayer.Memory:
                    todoService = new ToDoService(new MemoryDataStorage());
                    break;
                default:
                    Console.WriteLine("Некорректная конфигурация: неверно указана реализация DAL.");
                    return;
            }


            IPLService pLService = new PLService(todoService);
            pLService.DisplayMenu();
        }

        static AppSettings? ReadConfig(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл конфигурации не найден.");
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<AppSettings>(json);
        }
    }
}
