namespace Explorer.Application.Commands.ForDirectory.DeleteDirectory
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class DeleteDirectoryCommandHandler
        : IRequestHandler<DeleteDirectoryCommand>
    {
        public async Task<Unit> Handle(
            DeleteDirectoryCommand request, CancellationToken cancellationToken)
        {
            var pathToDirectoryToDelete =
                Properties.Resources.BaseDirectory + request.DirectoryToDelete.Replace("%2F", @"\");

            await Task.Run(
                () => Directory.Delete(pathToDirectoryToDelete), cancellationToken);

            return Unit.Value;
        }
    }
}