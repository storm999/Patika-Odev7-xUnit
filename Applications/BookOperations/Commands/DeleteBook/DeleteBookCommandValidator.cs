using FluentValidation;

namespace BookStorePtk.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
