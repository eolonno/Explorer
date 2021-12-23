namespace Explorer.Application.Queries.ForDirectory.GetDirectoryContent
{
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetDirectoryContentQueryHandler
        : IRequestHandler<GetDirectoryContentQuery, GetDirectoryContentQueryVm>
    {
        public async Task<GetDirectoryContentQueryVm> Handle(
            GetDirectoryContentQuery request, CancellationToken cancellationToken)
        {
            if (!Directory.Exists(request.Path))
            {
                throw new DirectoryNotFoundException();
            }

            var directoryContent = await Task.Run(
                () => Directory
                .GetDirectories(request.Path)
                .Union(Directory.GetFiles(request.Path))
                .OrderBy(x => x)
                .ToList(), cancellationToken);

            return new GetDirectoryContentQueryVm { DirectoryContent = directoryContent };
        }
    }
}