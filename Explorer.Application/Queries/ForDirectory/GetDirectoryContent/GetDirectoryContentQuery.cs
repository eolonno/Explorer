namespace Explorer.Application.Queries.ForDirectory.GetDirectoryContent
{
    using MediatR;

    public class GetDirectoryContentQuery : IRequest<GetDirectoryContentQueryVm>
    {
        public string Path { get; set; }
    }
}