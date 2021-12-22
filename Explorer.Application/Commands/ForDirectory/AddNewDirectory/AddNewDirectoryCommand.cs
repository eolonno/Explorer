namespace Explorer.Application.Commands.ForDirectory.AddNewDirectory
{
    using MediatR;

    public class AddNewDirectoryCommand : IRequest
    {
        public string DirectoryToAddTo { get; set; }
    }
}