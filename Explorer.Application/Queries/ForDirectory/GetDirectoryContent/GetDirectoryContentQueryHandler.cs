namespace Explorer.Application.Queries.ForDirectory.GetDirectoryContent
{
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class GetDirectoryContentQueryHandler
        : IRequestHandler<GetDirectoryContentQuery, GetDirectoryContentQueryVm>
    {
        public async Task<GetDirectoryContentQueryVm> Handle(
            GetDirectoryContentQuery request, CancellationToken cancellationToken)
        {
            var path =
                PathUtils.MapPath(PathUtils.ParsePath(request.Path));

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }

            var directoryContent = await Task.Run(
                () => Directory
                        .GetDirectories(path)
                        .Union(Directory.GetFiles(path))
                        .OrderBy(x => x)
                        .Select(s => new string(s.Skip(path.Length).ToArray()))
                        .ToList(), cancellationToken);

            return new GetDirectoryContentQueryVm { DirectoryContent = directoryContent };
        }
    }
}