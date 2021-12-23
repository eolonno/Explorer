namespace Explorer.Application.Commands.ForFile.AppendContentToFile
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class AppendContentToFileCommandHandler
        : IRequestHandler<AppendContentToFileCommand>
    {
        public async Task<Unit> Handle(
            AppendContentToFileCommand request, CancellationToken cancellationToken)
        {
            var pathToFile = $@"{request.Path}\{request.FileName}";

            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException();
            }

            await File.AppendAllTextAsync(
                pathToFile, request.ContentToAdd, cancellationToken);

            return Unit.Value;
        }
    }
}