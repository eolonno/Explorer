namespace Explorer.Application.Commands.ForFile.AppendContentToFile
{
    using FluentValidation;

    public class AppendContentToFileCommandValidator
        : AbstractValidator<AppendContentToFileCommand>
    {
        public AppendContentToFileCommandValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@":\\\w+|\W+\w+|W+");
            this.RuleFor(fileInfo => fileInfo.FileName)
                .Matches(@"\.\w+\z");
            this.RuleFor(fileInfo => fileInfo.ContentToAdd)
                .NotEmpty();
        }
    }
}