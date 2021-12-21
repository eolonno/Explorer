namespace Explorer.Application.Queries.GetDirectoryContent
{
    using FluentValidation;

    public class GetDirectoryContentQueryValidator : AbstractValidator<GetDirectoryContentQuery>
    {
        public GetDirectoryContentQueryValidator()
        {
            this.RuleFor(directoryInfo => directoryInfo.Path).NotEmpty();
        }
    }
}