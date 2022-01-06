namespace Explorer.Application.Commands.ForFile.AppendContentToFile
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class AppendContentToFileCommandHandler
        : IRequestHandler<AppendContentToFileCommand>
    {
        public async Task<Unit> Handle(
            AppendContentToFileCommand request, CancellationToken cancellationToken)
        {
            var path =
                PathUtils.MapPath(PathUtils.ParsePath(request.Path));

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            await File.AppendAllTextAsync(
                path, request.ContentToAdd, cancellationToken);

            return Unit.Value;
        }
    }
}