using Microsoft.AspNetCore.Mvc;
using SystemImports.Api.Controllers.Base;

namespace SystemImports.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> ValidateUserAsync()
        {
            return await ExecuteTaskAsync(TestTaskMethod);
        }

        private async Task<string> TestTaskMethod()
        {
            return "Task Executed";
        }
    }
}
