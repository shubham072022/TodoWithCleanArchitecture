using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.TodoLists.Commands.CreateTodoList
{
    internal class CreateTodoListComandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoListComandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("This must not exceed 200 characters.")
                .MustAsync(BeuniqueTitle).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeuniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
