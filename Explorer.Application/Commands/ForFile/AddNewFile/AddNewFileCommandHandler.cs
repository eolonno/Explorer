namespace Explorer.Application.Commands.ForFile.AddNewFile
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class AddNewFileCommandHandler
        : IRequestHandler<AddNewFileCommand>
    {
        public async Task<Unit> Handle(
            AddNewFileCommand request, CancellationToken cancellationToken)
        {
            var filePath = $@"{request.Path}\{request.FileName}";

            if (string.IsNullOrEmpty(request.ContentToAdd))
            {
                await Task.Run(
                    () => File.Create(filePath), cancellationToken);
            }
            else
            {
                await using var stream = File.CreateText(filePath);
                await stream.WriteLineAsync(request.ContentToAdd);
            }

            return Unit.Value;
        }
    }
}