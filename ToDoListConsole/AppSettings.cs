namespace ToDoListConsole
{
    public enum DataAccessLayer
    {
        TextFile,
        Memory
    }
    public class AppSettings
    {
        public DataAccessLayer DataAccessLayer { get; set; }
    }
}
