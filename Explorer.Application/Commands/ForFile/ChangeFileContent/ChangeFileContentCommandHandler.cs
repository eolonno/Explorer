namespace Explorer.Application.Commands.ForFile.ChangeFileContent
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class ChangeFileContentCommandHandler
        : AsyncRequestHandler<ChangeFileContentCommand>
    {
        protected override async Task Handle(
            ChangeFileContentCommand request, CancellationToken cancellationToken)
        {
            var path =
                PathUtils.MapPath(PathUtils.ParsePath(request.Path));

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            await File.WriteAllTextAsync(
                path, request.NewContent, cancellationToken);
        }
    }
}