namespace TodoApp.Application.Commands
{
    public class CreateTodoTaskCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
