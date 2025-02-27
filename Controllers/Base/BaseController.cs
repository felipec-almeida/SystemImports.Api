using Microsoft.AspNetCore.Mvc;

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
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { error = ex.Message }); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
