namespace Explorer.Application.Commands.ForDirectory.DeleteDirectory
{
    using MediatR;

    public class DeleteDirectoryCommand : IRequest
    {
        public string DirectoryToDelete { get; set; }
    }
}