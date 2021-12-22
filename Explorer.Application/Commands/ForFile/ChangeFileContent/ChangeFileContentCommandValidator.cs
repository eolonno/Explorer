namespace Explorer.Application.Commands.ForFile.ChangeFileContent
{
    using FluentValidation;

    public class ChangeFileContentCommandValidator
        : AbstractValidator<ChangeFileContentCommand>
    {
        public ChangeFileContentCommandValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@":\\\w+|\W+\w+|W+");
            this.RuleFor(fileInfo => fileInfo.FileName)
                .Matches(@"\.\w+\z");
        }
    }
}