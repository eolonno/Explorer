namespace Explorer.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Explorer.Application.Commands.ForDirectory.AddNewDirectory;
    using Explorer.Application.Commands.ForDirectory.DeleteDirectory;
    using Explorer.Application.Queries.ForDirectory.GetDirectoryContent;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class DirectoryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetDirectoryContentQueryVm>> Get()
        {
            var query = new GetDirectoryContentQuery { Path = string.Empty };
            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpGet]
        [Route("{path}")]
        public async Task<ActionResult<GetDirectoryContentQueryVm>> Get(
            [FromRoute] string path)
        {
            var query = new GetDirectoryContentQuery { Path = path };
            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpPost]
        [Route("{path}")]
        public async Task<ActionResult> Create(
            [FromRoute] string path)
        {
            var command = new AddNewDirectoryCommand
            {
                DirectoryToAddTo = path,
            };

            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpDelete]
        [Route("{path}")]
        public async Task<ActionResult> Delete(
            [FromRoute] string path)
        {
            var command = new DeleteDirectoryCommand
            {
                DirectoryToDelete = path,
            };

            await this.Mediator.Send(command);

            return this.Ok();
        }
    }
}
