namespace Explorer.WebApi.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Explorer.Application.Commands.ForFile.AddNewFile;
    using Explorer.Application.Commands.ForFile.AppendContentToFile;
    using Explorer.Application.Commands.ForFile.ChangeFileContent;
    using Explorer.Application.Commands.ForFile.DeleteFile;
    using Explorer.Application.Queries.ForFile.GetFileContent;
    using Explorer.WebApi.Models;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class FileController : BaseController
    {
        private readonly IMapper mapper;

        public FileController(IMapper mapper) =>
            this.mapper = mapper;

        [HttpGet]
        [Route("{path}/{fileName}")]
        public async Task<ActionResult<GetFileContentQueryVm>> Get(
            [FromRoute] string path, [FromRoute] string fileName)
        {
            var query = new GetFileContentQuery
            {
                FileName = fileName,
                Path = path,
            };

            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpGet]
        [Route("ExplorerMainDirectory/{fileName}")]
        public async Task<ActionResult<GetFileContentQueryVm>> Get(
            [FromRoute] string fileName)
        {
            var query = new GetFileContentQuery
            {
                FileName = fileName,
                Path = string.Empty,
            };

            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpPost]
        [Route("{path}/{fileName}")]
        public async Task<ActionResult> Create(
            [FromRoute] string path, [FromRoute] string fileName, [FromBody] string contentToAdd)
        {
            var command = new AddNewFileCommand
            {
                Path = path,
                FileName = fileName,
                ContentToAdd = contentToAdd,
            };

            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpDelete]
        [Route("{path}/{fileName}")]
        public async Task<ActionResult> Delete(
            [FromRoute] string path, [FromRoute] string fileName)
        {
            var command = new DeleteFileCommand
            {
                Path = path,
                FileName = fileName,
            };

            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpPut]
        [Route("{path}/{fileName}")]
        public async Task<ActionResult> Edit(
            [FromRoute] bool isRewrite,
            [FromRoute] string path,
            [FromRoute] string fileName,
            [FromBody] string newContent)
        {
            var fileInfoDto = new EditFileContentDto
            {
                Path = path,
                FileName = fileName,
                NewContent = newContent,
            };

            if (isRewrite)
            {
                var command = this.mapper.Map<ChangeFileContentCommand>(fileInfoDto);
                await this.Mediator.Send(command);
            }
            else
            {
                var command = this.mapper.Map<AppendContentToFileCommand>(fileInfoDto);
                await this.Mediator.Send(command);
            }

            return this.Ok();
        }
    }
}
