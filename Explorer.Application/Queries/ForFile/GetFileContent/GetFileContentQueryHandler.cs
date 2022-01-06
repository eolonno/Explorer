namespace Explorer.Application.Queries.ForFile.GetFileContent
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class GetFileContentQueryHandler
        : IRequestHandler<GetFileContentQuery, GetFileContentQueryVm>
    {
        public async Task<GetFileContentQueryVm> Handle(
            GetFileContentQuery request, CancellationToken cancellationToken)
        {
            var path =
                PathUtils.MapPath(PathUtils.ParsePath(request.Path));

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            var fileContent = await File.ReadAllTextAsync(
                path, cancellationToken);

            return new GetFileContentQueryVm { FileContent = fileContent };
        }
    }
}