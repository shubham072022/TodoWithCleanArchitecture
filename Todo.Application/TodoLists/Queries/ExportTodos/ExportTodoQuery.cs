using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.TodoLists.Queries.ExportTodos
{
    public record ExportTodoQuery : IRequest<ExportTodoVm>
    {
        public int ListId { get; init; }
    }

    public class ExportTodoQueryHandler : IRequestHandler<ExportTodoQuery, ExportTodoVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportTodoQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportTodoVm> Handle(ExportTodoQuery request, CancellationToken cancellationToken)
        {
            var records = await _context.TodoItems
                .Where(t => t.ListId == request.ListId)
                .ProjectTo<TodoItemRecord>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new ExportTodoVm("TodoItems.csv", "text/csv", _fileBuilder.BuildTodoItemsFile(records));

            return vm;
        }
    }
}
