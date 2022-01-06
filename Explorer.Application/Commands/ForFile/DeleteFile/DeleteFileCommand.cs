namespace Explorer.Application.Commands.ForFile.DeleteFile
{
    using MediatR;

    public class DeleteFileCommand : IRequest
    {
        public string Path { get; set; }
    }
}