namespace Explorer.Application.Queries.ForFile.GetFileContent
{
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetFileContentQueryHandler
        : IRequestHandler<GetFileContentQuery, GetFileContentQueryVm>
    {
        public async Task<GetFileContentQueryVm> Handle(
            GetFileContentQuery request, CancellationToken cancellationToken)
        {
            var fileContent = await File.ReadAllTextAsync(
                    request.Path.Concat(request.FileName).ToString(),
                    cancellationToken);

            return new GetFileContentQueryVm { FileContent = fileContent };
        }
    }
}