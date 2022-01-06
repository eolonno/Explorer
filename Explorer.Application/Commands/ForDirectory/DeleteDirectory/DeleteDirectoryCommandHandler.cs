﻿namespace Explorer.Application.Commands.ForDirectory.DeleteDirectory
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Explorer.Application.Utils;
    using MediatR;

    public class DeleteDirectoryCommandHandler
        : IRequestHandler<DeleteDirectoryCommand>
    {
        public async Task<Unit> Handle(
            DeleteDirectoryCommand request, CancellationToken cancellationToken)
        {
            var pathToDirectoryToDelete =
                PathUtils.MapPath(PathUtils.ParsePath(request.DirectoryToDelete));

            await Task.Run(
                () => Directory.Delete(pathToDirectoryToDelete), cancellationToken);

            return Unit.Value;
        }
    }
}