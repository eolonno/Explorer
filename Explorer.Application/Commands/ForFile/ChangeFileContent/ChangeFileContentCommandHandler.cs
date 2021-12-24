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
            var path =
                Properties.Resources.BaseDirectory
                + request.Path.Replace("%2F", @"\")
                + @"\"
                + request.FileName;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            await File.WriteAllTextAsync(
                path, request.NewContent, cancellationToken);

            return Unit.Value;
        }
    }
}