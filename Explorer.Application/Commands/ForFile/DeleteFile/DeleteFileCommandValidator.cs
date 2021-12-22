namespace Explorer.Application.Commands.ForFile.DeleteFile
{
    using FluentValidation;

    public class DeleteFileCommandValidator
        : AbstractValidator<DeleteFileCommand>
    {
        public DeleteFileCommandValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@":\\\w+|\W+\w+|W+");
            this.RuleFor(fileInfo => fileInfo.FileName)
                .Matches(@"\.\w+\z");
        }
    }
}