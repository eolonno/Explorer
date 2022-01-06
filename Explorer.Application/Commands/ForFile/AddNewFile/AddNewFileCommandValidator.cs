namespace Explorer.Application.Commands.ForFile.AddNewFile
{
    using FluentValidation;

    public class AddNewFileCommandValidator
        : AbstractValidator<AddNewFileCommand>
    {
        public AddNewFileCommandValidator()
        {
            this.RuleFor(newFileInfo => newFileInfo.Path)
                .Matches(Properties.Resources.FilePathRegex);
        }
    }
}