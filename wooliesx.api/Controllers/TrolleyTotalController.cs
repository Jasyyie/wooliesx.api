using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wooliesx.service.services;
using wooliesx.model.models;

namespace wooliesx.api.Controllers
{
    /// <summary>
    /// Controller to manage sort requests
    /// </summary>
    [Route("api/answers/[controller]")]
    [ApiController]
    public class TrolleyTotalController : Controller
    {
        private readonly IExercise3Service _exercise3Service;

        /// <summary>
        /// Dependency injection
        /// </summary>
        /// <param name="exercise3Service"></param>
        public TrolleyTotalController(IExercise3Service exercise3Service)
        {
            _exercise3Service = exercise3Service;
        }

        /// <summary>
        /// Get trolley total
        /// </summary>
        /// <param name="sortOption">High | Low | Ascending | Descending | Recommended</param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Request postRequest)
        {
            try
            {
                var response = await _exercise3Service.TrolleyTotal(postRequest);

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

