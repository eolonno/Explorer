namespace Explorer.Application.Commands.ForFile.ChangeFileContent
{
    using FluentValidation;

    public class ChangeFileContentCommandValidator
        : AbstractValidator<ChangeFileContentCommand>
    {
        public ChangeFileContentCommandValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@"[w+]+|[\w+/\w+]+\w");
            this.RuleFor(fileInfo => fileInfo.FileName)
                .Matches(@"\w*\.\w+");
        }
    }
}