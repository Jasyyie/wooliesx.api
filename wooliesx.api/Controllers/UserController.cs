using Microsoft.AspNetCore.Mvc;
using wooliesx.service.services;

namespace wooliesx.api.Controllers
{
    /// <summary>
    /// Controller to manage User
    /// </summary>
    [Route("api/answers/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IExercise1Service _exercise1Service;

        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="exercise1Service"></param>
        public UserController(IExercise1Service exercise1Service)
        {
            _exercise1Service = exercise1Service;
        }

        /// <summary>
        /// Get User
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _exercise1Service.GetUser();
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                // todo: exception logging & handling
            }
            return new BadRequestResult();
        }

    }
}
