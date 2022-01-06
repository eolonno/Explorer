namespace Explorer.Application.Commands.ForFile.AppendContentToFile
{
    using MediatR;

    public class AppendContentToFileCommand : IRequest
    {
        public string Path { get; set; }

        public string ContentToAdd { get; set; }
    }
}