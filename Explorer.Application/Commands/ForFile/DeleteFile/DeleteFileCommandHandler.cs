namespace Explorer.Application.Commands.ForFile.DeleteFile
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class DeleteFileCommandHandler
        : IRequestHandler<DeleteFileCommand>
    {
        public async Task<Unit> Handle(
            DeleteFileCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(
                () => File.Delete($@"{request.Path}\{request.FileName}"), cancellationToken);

            return Unit.Value;
        }
    }
}