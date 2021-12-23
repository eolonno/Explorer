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
            var pathToFile = $@"{request.Path}\{request.FileName}";

            await Task.Run(
                () => File.Delete(pathToFile), cancellationToken);

            return Unit.Value;
        }
    }
}