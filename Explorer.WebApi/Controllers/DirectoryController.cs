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
        public async Task<ActionResult<GetDirectoryContentQueryVm>> Get(
            [FromBody] GetDirectoryContentQuery query)
        {
            var vm = await this.Mediator.Send(query);

            return this.Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(
            [FromBody] AddNewDirectoryCommand command)
        {
            await this.Mediator.Send(command);

            return this.Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(
            [FromBody] DeleteDirectoryCommand command)
        {
            await this.Mediator.Send(command);

            return this.Ok();
        }
    }
}
