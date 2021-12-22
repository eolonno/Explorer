namespace Explorer.Application.Commands.ForDirectory.AddNewDirectory
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class AddNewDirectoryCommandHandler
        : IRequestHandler<AddNewDirectoryCommand>
    {
        public async Task<Unit> Handle(
            AddNewDirectoryCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(
                () => Directory.CreateDirectory(request.DirectoryToAddTo), cancellationToken);

            return Unit.Value;
        }
    }
}