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
            var filePath = $@"{request.Path}\{request.FileName}";

            await File.AppendAllTextAsync(
                filePath,
                request.ContentToAdd,
                cancellationToken);

            return Unit.Value;
        }
    }
}