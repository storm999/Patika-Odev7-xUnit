using FluentValidation;

namespace BookStorePtk.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(g => g.GenreId).NotNull().GreaterThan(0);
            RuleFor(g => g.Model.Name).NotNull().MinimumLength(3);
        }
    }
}
