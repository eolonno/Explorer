namespace Explorer.Application.Commands.ForFile.DeleteFile
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class DeleteFileCommandHandler
        : AsyncRequestHandler<DeleteFileCommand>
    {
        protected override async Task Handle(
            DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var path =
                PathUtils.MapPath(PathUtils.ParsePath(request.Path));

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            await Task.Run(
                () => File.Delete(path), cancellationToken);
        }
    }
}