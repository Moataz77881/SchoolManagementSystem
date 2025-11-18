using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Infrastructure.Response;

namespace SchoolManagementSystem.Helper
{
    public static class ActionResultResponseHandler
    {
        public static IActionResult ToActionResult(
            this ControllerBase controllerBase,
            ServiceResponse serviceResponse)
        {
            return serviceResponse.StatusCode switch
            {
                404 => controllerBase.NotFound(serviceResponse),
                400 => controllerBase.BadRequest(serviceResponse),
                401 => controllerBase.Unauthorized(serviceResponse),
                _ => controllerBase.Ok(serviceResponse)
            };
        }
    }
}
