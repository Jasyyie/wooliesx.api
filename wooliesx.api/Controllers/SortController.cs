using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wooliesx.service.services;

namespace wooliesx.api.Controllers
{
    /// <summary>
    /// Controller to manage sort requests
    /// </summary>
    [Route("api/answers/[controller]")]
    [ApiController]
    public class SortController : Controller
    {
        private readonly IExercise2Service _exercise2Service;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="exercise2Service"></param>
        public SortController(IExercise2Service exercise2Service)
        {
            _exercise2Service = exercise2Service;
        }

        /// <summary>
        /// Get sorted products
        /// </summary>
        /// <param name="sortOption">High | Low | Ascending | Descending | Recommended</param>
        [HttpGet]
        public async Task<IActionResult> Get(string sortOption)
        {
            try
            {
                var response = await _exercise2Service.SortProducts(sortOption);

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

