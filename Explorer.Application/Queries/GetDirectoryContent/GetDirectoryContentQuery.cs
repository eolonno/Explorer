namespace Explorer.Application.Queries.GetDirectoryContent
{
    using MediatR;

    public class GetDirectoryContentQuery : IRequest<GetDirectoryContentQueryVm>
    {
        public string Path;
    }
}