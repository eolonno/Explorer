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
        public async Task<ActionResult<GetFileContentQueryVm>> Get(
            [FromBody] GetFileContentQuery query)
        {
            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] AddNewFileCommand command)
        {
            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(
            [FromBody] DeleteFileCommand command)
        {
            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit(
            [FromRoute] bool isRewrite, [FromBody] EditFileContentDto fileInfoDto)
        {
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
