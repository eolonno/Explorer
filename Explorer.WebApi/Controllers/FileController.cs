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
        [Route("{*path}")]
        public async Task<ActionResult<GetFileContentQueryVm>> Get(
            [FromRoute] string path)
        {
            var query = new GetFileContentQuery { Path = path };

            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpPost]
        [Route("{*path}")]
        public async Task<ActionResult> Create(
            [FromRoute] string path, [FromBody] string contentToAdd)
        {
            var command = new AddNewFileCommand
            {
                Path = path,
                ContentToAdd = contentToAdd,
            };

            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpDelete]
        [Route("{*path}")]
        public async Task<ActionResult> Delete(
            [FromRoute] string path)
        {
            var command = new DeleteFileCommand { Path = path };

            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpPut]
        [Route("{isRewrite}/{*path}")]
        public async Task<ActionResult> Edit(
            [FromRoute] string path,
            [FromRoute] bool isRewrite,
            [FromBody] string newContent)
        {
            var fileInfoDto = new EditFileContentDto
            {
                Path = path,
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
