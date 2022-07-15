using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.TodoItems.Queries.GetTodoItemsWithPagination
{
    public class GetTodoItemsWithPaginationValidator : AbstractValidator<GetTodoItemsWithPaginationQuery>
    {
        public GetTodoItemsWithPaginationValidator()
        {
            RuleFor(x => x.ListId)
                .NotEmpty().WithMessage("List id is required.");

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage("Page number atleast greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Page size atleast greater than or equal to 1.");
        }
    }
}
