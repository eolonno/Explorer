namespace Explorer.Application.Commands.ForFile.DeleteFile
{
    using FluentValidation;

    public class DeleteFileCommandValidator
        : AbstractValidator<DeleteFileCommand>
    {
        public DeleteFileCommandValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@"[w+]+|[\w+/\w+]+\w");
            this.RuleFor(fileInfo => fileInfo.FileName)
                .Matches(@"\w*\.\w+");
        }
    }
}