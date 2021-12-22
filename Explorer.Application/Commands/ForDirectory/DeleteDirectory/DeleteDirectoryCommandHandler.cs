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
            await Task.Run(
                () => Directory.Delete(request.DirectoryToDelete), cancellationToken);

            return Unit.Value;
        }
    }
}