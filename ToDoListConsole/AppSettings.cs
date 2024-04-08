namespace ToDoListConsole
{
    public enum DataAccessLayer
    {
        JsonFile,
        Memory
    }
    public class AppSettings
    {
        public DataAccessLayer DataAccessLayer { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}
