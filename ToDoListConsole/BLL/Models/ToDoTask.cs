namespace ToDoListConsole.BLL.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }

    }
}
