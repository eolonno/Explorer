namespace Explorer.Application.Commands.ForDirectory.DeleteDirectory
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class DeleteDirectoryCommandHandler
        : AsyncRequestHandler<DeleteDirectoryCommand>
    {
        protected override async Task Handle(
            DeleteDirectoryCommand request, CancellationToken cancellationToken)
        {
            var pathToDirectoryToDelete =
                PathUtils.MapPath(PathUtils.ParsePath(request.DirectoryToDelete));

            await Task.Run(
                () => Directory.Delete(pathToDirectoryToDelete), cancellationToken);
        }
    }
}