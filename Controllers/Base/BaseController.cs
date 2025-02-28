using Microsoft.AspNetCore.Mvc;
using SystemImports.Borders.Entities.Base;

namespace SystemImports.Api.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected async Task<IActionResult> ExecuteTaskAsync<T>(Func<Task<T>> task)
        {
            try
            {
                var result = await task();
                return StatusCode(200, result);
            }
            catch(UnauthorizedAccessException ex)
            {
                return StatusCode(401, new BaseResponseError { Error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new BaseResponseError { Error = ex.Message }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponseError { Error = ex.Message });
            }
        }
    }
}
