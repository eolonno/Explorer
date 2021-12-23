namespace Explorer.Application.Commands.ForFile.ChangeFileContent
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class ChangeFileContentCommandHandler
        : IRequestHandler<ChangeFileContentCommand>
    {
        public async Task<Unit> Handle(
            ChangeFileContentCommand request, CancellationToken cancellationToken)
        {
            var pathToFile = $@"{request.Path}\{request.FileName}";

            if (!File.Exists(pathToFile))
            {
                throw new FileNotFoundException();
            }

            await File.WriteAllTextAsync(
                pathToFile, request.NewContent, cancellationToken);

            return Unit.Value;
        }
    }
}