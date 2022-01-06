namespace Explorer.Application.Commands.ForFile.DeleteFile
{
    using FluentValidation;

    public class DeleteFileCommandValidator
        : AbstractValidator<DeleteFileCommand>
    {
        public DeleteFileCommandValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(Properties.Resources.FilePathRegex);
        }
    }
}