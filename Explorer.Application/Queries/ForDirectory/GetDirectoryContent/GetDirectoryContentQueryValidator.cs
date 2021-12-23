namespace Explorer.Application.Queries.ForDirectory.GetDirectoryContent
{
    using FluentValidation;

    public class GetDirectoryContentQueryValidator
        : AbstractValidator<GetDirectoryContentQuery>
    {
        public GetDirectoryContentQueryValidator()
        {
            this.RuleFor(directoryInfo => directoryInfo.Path)
                .Matches(@":\\\w+|\W+\w+|W+");
        }
    }
}