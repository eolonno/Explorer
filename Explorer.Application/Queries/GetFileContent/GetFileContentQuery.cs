namespace Explorer.Application.Queries.GetFileContent
{
    using MediatR;

    public class GetFileContentQuery : IRequest<GetFileContentQueryVm>
    {
        public string Path;
        public string FileName;
    }
}