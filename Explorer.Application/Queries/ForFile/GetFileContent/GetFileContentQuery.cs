namespace Explorer.Application.Queries.ForFile.GetFileContent
{
    using MediatR;

    public class GetFileContentQuery : IRequest<GetFileContentQueryVm>
    {
        public string Path { get; set; }
    }
}