namespace Explorer.Application.Commands.ForDirectory.DeleteDirectory
{
    using FluentValidation;

    public class DeleteDirectoryCommandValidator
        : AbstractValidator<DeleteDirectoryCommand>
    {
        public DeleteDirectoryCommandValidator()
        {
            this.RuleFor(directory => directory.DirectoryToDelete)
                .Matches(Properties.Resources.DirectoryRegex);
        }
    }
}