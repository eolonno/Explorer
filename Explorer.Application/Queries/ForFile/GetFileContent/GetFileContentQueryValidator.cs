namespace Explorer.Application.Queries.ForFile.GetFileContent
{
    using FluentValidation;

    public class GetFileContentQueryValidator
        : AbstractValidator<GetFileContentQuery>
    {
        public GetFileContentQueryValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@"[w+]+|[\w+/\w+]+\w");
            this.RuleFor(fileInfo => fileInfo.FileName)
                .Matches(@"\w*\.\w+");
        }
    }
}