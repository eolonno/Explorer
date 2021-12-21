﻿namespace Explorer.Application.Queries.GetFileContent
{
    using FluentValidation;

    public class GetFileContentQueryValidator : AbstractValidator<GetFileContentQuery>
    {
        public GetFileContentQueryValidator()
        {
            this.RuleFor(fileInfo => fileInfo.FileName).NotEmpty();
            this.RuleFor(fileInfo => fileInfo.Path).NotEmpty();
        }
    }
}