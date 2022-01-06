namespace Explorer.Application.Commands.ForDirectory.AddNewDirectory
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class AddNewDirectoryCommandHandler
        : AsyncRequestHandler<AddNewDirectoryCommand>
    {
        protected override async Task Handle(
            AddNewDirectoryCommand request, CancellationToken cancellationToken)
        {
            var pathToNewDirectory =
                PathUtils.MapPath(PathUtils.ParsePath(request.DirectoryToAddTo));

            await Task.Run(
                () => Directory.CreateDirectory(pathToNewDirectory), cancellationToken);
        }
    }
}