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
            var path =
                Properties.Resources.BaseDirectory
                + request.Path.Replace("%2F", @"\");

            var pathToFile =
                path
                + @"\"
                + request.FileName;

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }

            if (string.IsNullOrEmpty(request.ContentToAdd))
            {
                await Task.Run(
                    () => File.Create(pathToFile), cancellationToken);
            }
            else
            {
                await using var stream = File.CreateText(pathToFile);
                await stream.WriteLineAsync(request.ContentToAdd);
            }

            return Unit.Value;
        }
    }
}