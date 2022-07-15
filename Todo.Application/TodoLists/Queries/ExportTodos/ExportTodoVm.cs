namespace Todo.Application.TodoLists.Queries.ExportTodos
{
    public class ExportTodoVm
    {
        public ExportTodoVm(string fileName, string contentType, byte[] content)
        {
            FileName = fileName;
            ContentType = contentType;
            Content = content;
        }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}
