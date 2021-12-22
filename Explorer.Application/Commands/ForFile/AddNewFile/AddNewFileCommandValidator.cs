namespace Explorer.Application.Commands.ForFile.AddNewFile
{
    using FluentValidation;

    public class AddNewFileCommandValidator
        : AbstractValidator<AddNewFileCommand>
    {
        public AddNewFileCommandValidator()
        {
            this.RuleFor(newFileInfo => newFileInfo.Path)
                .Matches(@":\\\w+|\W+\w+|W+");
            this.RuleFor(newFileInfo => newFileInfo.FileName)
                .Matches(@"\.\w+\z");
        }
    }
}