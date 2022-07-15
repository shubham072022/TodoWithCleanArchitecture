using MediatR;
using Todo.Application.Common.Interfaces;
using Todo.Application.Common.Security;

namespace Todo.Application.TodoLists.Commands.PurgeTodoList
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public record PurgeTodoListCommand : IRequest;

    public class PurgeTodoListCommandHandler : IRequestHandler<PurgeTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeTodoListCommand request, CancellationToken cancellationToken)
        {
            _context.TodoLists.RemoveRange(_context.TodoLists);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
