namespace Explorer.Application.Queries.ForFile.GetFileContent
{
    using FluentValidation;

    public class GetFileContentQueryValidator
        : AbstractValidator<GetFileContentQuery>
    {
        public GetFileContentQueryValidator()
        {
            this.RuleFor(fileInfo => fileInfo.Path)
                .Matches(@":\\\w+|\W+\w+|W+");
            this.RuleFor(fileInfo => fileInfo.FileName)
                .Matches(@"\.\w+\z");
        }
    }
}