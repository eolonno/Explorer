namespace Explorer.Application.Commands.ForFile.AddNewFile
{
    using MediatR;

    public class AddNewFileCommand : IRequest
    {
        public string Path { get; set; }

        public string? ContentToAdd { get; set; }
    }
}