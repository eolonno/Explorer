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
            var path =
                Properties.Resources.BaseDirectory
                + request.Path.Replace("%2F", @"\")
                + @"\"
                + request.FileName;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            await Task.Run(
                () => File.Delete(path), cancellationToken);

            return Unit.Value;
        }
    }
}