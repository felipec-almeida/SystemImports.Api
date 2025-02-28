using Microsoft.AspNetCore.Mvc;
using SystemImports.Api.Controllers.Base;
using SystemImports.Borders.Entities.Base;
using SystemImports.Borders.Entities.Users.Request;
using SystemImports.Borders.Entities.Users.Response;
using SystemImports.Borders.UseCases.Users;

namespace SystemImports.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : BaseController
    {
        private readonly IValidateUserUseCase _validateUserUseCase;

        public UserController(IValidateUserUseCase validateUserUseCase)
        {
            _validateUserUseCase = validateUserUseCase;
        }

        [HttpPost("validate-login")]
        [ProducesResponseType(401)]
        [ProducesResponseType(200, Type = typeof(UserLoginResponse))]
        [ProducesResponseType(400, Type = typeof(BaseResponseError))]
        [ProducesResponseType(500, Type = typeof(BaseResponseError))]
        public async Task<IActionResult> ValidateUserAsync([FromBody] UserLoginRequest request)
        {
            return await ExecuteTaskAsync(() => _validateUserUseCase.OnExecute(request));
        }
    }
}
