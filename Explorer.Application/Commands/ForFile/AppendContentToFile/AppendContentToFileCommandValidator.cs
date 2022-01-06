namespace Explorer.Application.Commands.ForFile.AppendContentToFile
{
    using FluentValidation;

    public class AppendContentToFileCommandValidator
        : AbstractValidator<AppendContentToFileCommand>
    {
        public AppendContentToFileCommandValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@"[w+]+|[\w+/\w+]+\w");
            this.RuleFor(fileInfo => fileInfo.ContentToAdd)
                .NotEmpty();
        }
    }
}