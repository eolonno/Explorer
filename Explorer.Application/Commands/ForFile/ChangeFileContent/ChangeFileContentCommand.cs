namespace Explorer.Application.Commands.ForFile.ChangeFileContent
{
    using MediatR;

    public class ChangeFileContentCommand : IRequest
    {
        public string Path { get; set; }

        public string FileName { get; set; }

        public string NewContent { get; set; }
    }
}