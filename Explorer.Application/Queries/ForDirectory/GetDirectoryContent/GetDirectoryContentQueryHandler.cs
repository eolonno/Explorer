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
            var path =
                Properties.Resources.BaseDirectory + request.Path.Replace("%2F", @"\");

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