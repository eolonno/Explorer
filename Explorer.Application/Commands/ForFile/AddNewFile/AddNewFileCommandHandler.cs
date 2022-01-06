namespace Explorer.Application.Commands.ForFile.AddNewFile
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class AddNewFileCommandHandler
        : AsyncRequestHandler<AddNewFileCommand>
    {
        protected override async Task Handle(
            AddNewFileCommand request, CancellationToken cancellationToken)
        {
            var path =
                PathUtils.MapPath(PathUtils.ParsePath(request.Path));

            if (string.IsNullOrEmpty(request.ContentToAdd))
            {
                await Task.Run(
                    () => File.Create(path), cancellationToken);
            }
            else
            {
                await using var stream = File.CreateText(path);
                await stream.WriteLineAsync(request.ContentToAdd);
            }
        }
    }
}