using MediatR;
using Todo.Application.Common.Exceptions;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Enums;

namespace Todo.Application.TodoItems.Commands.UpdateTodoItemDetail
{
    public record UpdateTodoItemDetailCommand : IRequest
    {
        public int Id { get; init; }

        public int ListId { get; init; }

        public PriorityLevel Priority { get; init; }

        public string? Note { get; init; }
    }

    public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateTodoItemDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new NotFoundException();

            entity.Note = request.Note;
            entity.Priority = request.Priority;
            entity.ListId = request.ListId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
