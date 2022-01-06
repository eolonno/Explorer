namespace Explorer.Application.Commands.ForDirectory.AddNewDirectory
{
    using FluentValidation;

    public class AddNewDirectoryCommandValidator
        : AbstractValidator<AddNewDirectoryCommand>
    {
        public AddNewDirectoryCommandValidator()
        {
            this.RuleFor(directory => directory.DirectoryToAddTo)
                .Matches(Properties.Resources.DirectoryRegex);
        }
    }
}