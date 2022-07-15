namespace Todo.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string Message)
            :base(Message)
        {
        }

        public NotFoundException(string Message, Exception innerException)
            :base(Message, innerException)
        {
        }

        public NotFoundException(string name, object key)
            :base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
