namespace Explorer.Application.Queries.ForFile.GetFileContent
{
    using System;
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
            var pathToFile = $@"{request.Path}\{request.FileName}";

            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException();
            }

            var fileContent = await File.ReadAllTextAsync(
                    pathToFile, cancellationToken);

            return new GetFileContentQueryVm { FileContent = fileContent };
        }
    }
}