namespace Explorer.Application.Commands.ForFile.ChangeFileContent
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class ChangeFileContentCommandHandler
        : IRequestHandler<ChangeFileContentCommand>
    {
        public async Task<Unit> Handle(
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

            return Unit.Value;
        }
    }
}