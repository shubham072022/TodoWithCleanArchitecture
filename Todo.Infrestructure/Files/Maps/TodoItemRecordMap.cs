using CsvHelper.Configuration;
using Todo.Application.TodoLists.Queries.ExportTodos;

namespace Todo.Infrestructure.Files.Maps
{
    public class TodoItemRecordMap : ClassMap<TodoItemRecord>
    {
        public TodoItemRecordMap()
        {
            AutoMap(System.Globalization.CultureInfo.InvariantCulture);

            Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
        }
    }
}
