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
            await File.CreateText(
                $@"{request.Path}\{request.FileName}")
                .WriteLineAsync(request.NewContent);

            return Unit.Value;
        }
    }
}