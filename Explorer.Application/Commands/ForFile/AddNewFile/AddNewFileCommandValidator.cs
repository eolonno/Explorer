namespace Explorer.Application.Commands.ForFile.AddNewFile
{
    using FluentValidation;

    public class AddNewFileCommandValidator
        : AbstractValidator<AddNewFileCommand>
    {
        public AddNewFileCommandValidator()
        {
            this.RuleFor(newFileInfo => newFileInfo.Path)
                .Matches(@"[w+]+|[\w+/\w+]+\w");
            this.RuleFor(newFileInfo => newFileInfo.FileName)
                .Matches(@"\w*\.\w+");
        }
    }
}