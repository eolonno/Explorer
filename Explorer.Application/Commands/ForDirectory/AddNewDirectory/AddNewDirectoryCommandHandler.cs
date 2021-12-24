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
            var pathToNewDirectory =
                Properties.Resources.BaseDirectory + request.DirectoryToAddTo.Replace("%2F", @"\");

            await Task.Run(
                () => Directory.CreateDirectory(pathToNewDirectory), cancellationToken);

            return Unit.Value;
        }
    }
}